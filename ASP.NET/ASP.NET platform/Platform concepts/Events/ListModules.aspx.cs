using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Events
{
   public partial class ListModules : Page
   {
      public IEnumerable<ModuleDescription> GetModules()
      {
         HttpModuleCollection modules = Context.ApplicationInstance.Modules;
         return modules.AllKeys.OrderBy(k => k).Select(key => new ModuleDescription
         {
            Name = key,
            TypeName = modules[key].GetType().ToString()
         });
      }
   }

   public class ModuleDescription
   {
      public string Name { get; set; }

      public string TypeName { get; set; }
   }
}