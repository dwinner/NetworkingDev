using System;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;

namespace ApplicationServices
{
   public partial class Login : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (Page.IsPostBack || Membership.GetUser("test") != null)
            return;

         // Создаем пользователя
         MembershipCreateStatus createStatus;
         /*var membershipUser = */
         Membership.CreateUser("test", "test99!", "", "Why should you not panic?", "This is only a test.", true,
            out createStatus);
         if (createStatus != MembershipCreateStatus.Success)
         {
            info.InnerHtml = string.Format("Attempt to create user \"test\" failed with {0}", createStatus);
         }

         // Помещаем пользователя в хранилище ролей
         if (!Roles.RoleExists("Administrator"))
         {
            Roles.CreateRole("Administrator");
            Roles.AddUserToRole("test", "Administrator");
         }

         // Инициализируем параметры профиля
         var profileBase = ProfileBase.Create("test");
         profileBase["FirstName"] = "Tester";
         profileBase["LastName"] = "Smith";
         profileBase["CustomerCode"] = "540-SLJTE";
         profileBase.Save();
      }
   }
}