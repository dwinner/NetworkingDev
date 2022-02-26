using System.Threading.Tasks;

namespace WinAppChatClient.Services
{
   public interface IDialogService
   {
      Task ShowMessageAsync(string message);
   }
}