using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Formatting;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;
using FreelanceUnique.Web.Model;
using FreelanceUnique.Web.Model.Edm;

namespace FreelanceUnique.Web.Svc
{
    [RoutePrefix("email")]
    public class UniqueEmailController : ApiController
    {
        private const string AdminRoleName = "admins";
        private const string AllRoles = "users, admins";

        private static readonly Regex EmailRegex = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private readonly UniqueEmailRepo _emailRepo = new UniqueEmailRepo();

        [Authorize(Roles = AdminRoleName)]
        [Route("all")]
        public IEnumerable<UniqueEmail> Get()
        {
            return _emailRepo.Emails;
        }

        [Authorize(Roles = AdminRoleName)]
        [Route("one/{emailId:int}")]
        public UniqueEmail Get(int emailId)
        {
            return _emailRepo.GetEmail(emailId);
        }

        [Authorize(Roles = AllRoles)]
        [Route("add")]
        public async Task<IHttpActionResult> Post([FromBody] FormDataCollection formData)
        {
            var hrEmail = formData["email"];

            var authUser = Membership.GetUser();
            if (authUser == null || authUser.ProviderUserKey == null)
                return BadRequest("Unknown user");

            var userKey = authUser.ProviderUserKey.ToString();
            Guid userId;
            if (!Guid.TryParse(userKey, out userId))
                return BadRequest();

            if (string.IsNullOrWhiteSpace(hrEmail))
                return Content(HttpStatusCode.BadRequest, "Пустой Email");

            hrEmail = hrEmail.Trim().ToLower();
            if (!EmailRegex.IsMatch(hrEmail))
                return Content(HttpStatusCode.BadRequest, "Неправильный формат Email");

            var pocoEmail = new UniqueEmail
            {
                EmailId = 0,
                UserId = userId,
                Email = hrEmail,
                AddDate = DateTime.Now
            };

            if (!_emailRepo.IsUnique(pocoEmail))
                return Content(HttpStatusCode.BadRequest,
                    string.Format("Человек с email {0} уже был добавлен. Продолжайте поиски", pocoEmail.Email));

            var successResult = await _emailRepo.SaveAsync(pocoEmail);

            return successResult
                ? (IHttpActionResult)
                    Ok(
                        string.Format(
                            "Человек с email {0} ещё не был добавлен в базу. Сохраните его контактную информацию в таблице",
                            pocoEmail.Email))
                : Content(HttpStatusCode.Conflict, "Обнаружен конфликт во время добавления");
        }

        [Authorize(Roles = AdminRoleName)]
        [Route("update")]
        public async Task<IHttpActionResult> Put(int emlId, [FromBody] string emailValue)
        {
            bool successUpdate = await _emailRepo.UpdateAsync(emlId, emailValue);
            if (successUpdate)
            {
                return Ok();
            }

            return BadRequest();
        }

        [Authorize(Roles = AdminRoleName)]
        [Route("del")]
        public async Task<IHttpActionResult> Delete(int emlId)
        {
            bool successdel = await _emailRepo.DeleteAsync(emlId);
            if (successdel)
            {
                return Ok();
            }

            return BadRequest();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _emailRepo.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}