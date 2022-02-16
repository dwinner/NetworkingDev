namespace SportsStore.Web.Infrastructure.Abstract
{
   public interface IAuthProvider
   {
      bool Auth(string username, string password);
   }
}