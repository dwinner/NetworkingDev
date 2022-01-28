using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebSocketSample
{
   /// <summary>
   ///    Обработчик конечной точки WebSocket'а
   /// </summary>
   public class WebSocketHandler : IHttpHandler
   {
      public void ProcessRequest(HttpContext context)
      {
         if (context.IsWebSocketRequest)
         {
            var chatUser = new ChatUser
            {
               UserName = context.Request.QueryString["name"]
            };
            ChatApp.AddUser(chatUser);
            context.AcceptWebSocketRequest(chatUser.HandleWebSocketAsync);
         }
      }

      public bool IsReusable
      {
         get { return false; }
      }
   }

   internal class ChatUser
   {
      private const int MaxMessageSize = 0x400;
      private readonly Encoding _defaultEncoding = Encoding.UTF8;
      private WebSocketContext _context;

      public string UserName { get; set; }

      public async Task HandleWebSocketAsync(WebSocketContext webSocketContext)
      {
         _context = webSocketContext;
         var receiveBuffer = new byte[MaxMessageSize];
         var socket = _context.WebSocket;

         while (socket.State == WebSocketState.Open)
         {
            var receiveResult =
               await socket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);

            switch (receiveResult.MessageType)
            {
               case WebSocketMessageType.Close:
                  await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                  break;

               case WebSocketMessageType.Binary:
                  await
                     socket.CloseAsync(WebSocketCloseStatus.InvalidMessageType, "Cannot accept binary frame",
                        CancellationToken.None);
                  break;

               case WebSocketMessageType.Text:
                  var receivedString = _defaultEncoding.GetString(receiveBuffer, 0, receiveResult.Count);
                  var echoString = string.Concat(UserName, " said: ", receivedString);
                  // var outputBuffer = new ArraySegment<byte>(_defaultEncoding.GetBytes(echoString));
                  ChatApp.BroadcastMessage(echoString);
                  break;

               default:
                  goto case WebSocketMessageType.Close;
            }
         }
      }

      public async Task SendMessage(string aMessage)
      {
         if (_context != null && _context.WebSocket.State == WebSocketState.Open)
         {
            var outputBuffer = new ArraySegment<byte>(_defaultEncoding.GetBytes(aMessage));
            await _context.WebSocket.SendAsync(outputBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
         }
      }
   }

   internal class ChatApp
   {
      static ChatApp()
      {
         ChatUsers = new List<ChatUser>();
      }

      public static IList<ChatUser> ChatUsers { get; set; }

      public static void AddUser(ChatUser chatUser)
      {
         ChatUsers.Add(chatUser);
         BroadcastMessage(string.Format("{0} joined the chat!", chatUser.UserName));
      }

      public static void BroadcastMessage(string message)
      {
         foreach (var user in ChatUsers)
         {
            var localUser = user;
            Task.Run(async () => { await localUser.SendMessage(message); });
         }
      }
   }
}