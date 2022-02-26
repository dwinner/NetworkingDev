namespace WinAppChatClient.Services
{
   public class UrlService
   {
      private const string BaseUri = "https://localhost:5001";

      public string ChatAddress => $"{BaseUri}/chat";

      public string GroupAddress => $"{BaseUri}/groupchat";
   }
}