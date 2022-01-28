using System;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(CommonModules.ModuleRegistration), "RegisterModules")]

namespace CommonModules
{   
   /// <summary>
   /// Программная регистрация модулей
   /// </summary>
   public class ModuleRegistration
   {
      public static void RegisterModules()
      {
         Type[] moduleTypes =
         {
            typeof (CommonModules.TimerModule),
            typeof (CommonModules.LogModule)
         };

         foreach (var moduleType in moduleTypes)
         {
            HttpApplication.RegisterModule(moduleType);
         }
      }
   }
}