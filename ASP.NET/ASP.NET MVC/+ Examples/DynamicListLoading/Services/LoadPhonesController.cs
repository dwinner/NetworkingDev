using System.Linq;
using System.Web.Http;
using DynamicListLoading.Infrastructure;

namespace DynamicListLoading.Services
{
   [RoutePrefix("phones")]
   public class LoadPhonesController : ApiController
   {
      private const int PageSize = 8;
      private readonly PhoneRepository _repository = PhoneRepository.Instance;

      [Route("newItems/{page:int}")]
      public IHttpActionResult GetNewItems(int page)
      {
         var skipItems = page * PageSize;
         return Ok(_repository.Phones.OrderBy(phone => phone.Id).Skip(skipItems).Take(PageSize).ToList());
      }
   }
}