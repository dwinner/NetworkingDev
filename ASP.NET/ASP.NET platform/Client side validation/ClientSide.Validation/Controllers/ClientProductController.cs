using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClientSide.Validation.Models;
using WebApi.Intro.Models;

// ReSharper disable MemberCanBePrivate.Global

namespace ClientSide.Validation.Controllers // Контроллер для поддержки проверки достоверности на стороне клиента
{
   [SuppressMessage("ReSharper", "UnusedMember.Global")]
   public class ClientProductController : ApiController
   {
      private readonly Repository _repo = new Repository();

      public string Get()
      {
         return "test";
      }

      // POST api/<controller>
      public HttpResponseMessage Post([FromBody] Product value)
      {
         HttpResponseMessage responseMessage;
         if (ModelState.IsValid)
         {
            _repo.Add(value);
            responseMessage = Request.CreateResponse(HttpStatusCode.OK,
               new ProductView
               {
                  ProductId = value.ProductId,
                  Category = value.Category,
                  Name = value.Name,
                  Price = value.Price
               });
         }
         else
         {
            var errors =
               ModelState.SelectMany(state => state.Value.Errors, (state, error) => error.ErrorMessage).ToList();
            responseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, errors);
         }

         return responseMessage;
      }
   }
}