using System.Web.Configuration;
using Emso.WebUi.Infrastructure.Ifaces;

namespace Emso.WebUi.Infrastructure.Impl
{
   /// <summary>
   ///    The Web Config paging configuration implementation
   /// </summary>
   public class WebConfigPagingConfiguration : IPagingConfiguration
   {
      public WebConfigPagingConfiguration()
      {
         PageSize = int.Parse(WebConfigurationManager.AppSettings["PageSize"]);
      }

      /// <summary>
      ///    Page size
      /// </summary>
      public int PageSize { get; private set; }
   }
}