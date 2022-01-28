using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static TcpServerSample.CustomProtocol;

namespace TcpServerSample
{
   public sealed class SessionManager
   {
      private readonly ConcurrentDictionary<string, Dictionary<string, string>> _sessionData =
         new ConcurrentDictionary<string, Dictionary<string, string>>();

      private readonly ConcurrentDictionary<string, Session> _sessions =
         new ConcurrentDictionary<string, Session>();

      public string Create()
      {
         var sessionId = Guid.NewGuid().ToString();
         return _sessions.TryAdd(sessionId, new Session {SessionId = sessionId, LastAccessTime = DateTime.UtcNow})
            ? sessionId
            : string.Empty;
      }

      public void CleanupAll()
         =>
            _sessions
               .Where(session => session.Value.LastAccessTime + SessionTimeout >= DateTime.UtcNow)
               .Action(session => Cleanup(session.Key));

      private void Cleanup(string sessionId)
      {
         Dictionary<string, string> removed;
         if (_sessionData.TryRemove(sessionId, out removed))
         {
            WriteLine($"Removed {sessionId} from session data");
         }

         Session header;
         if (_sessions.TryRemove(sessionId, out header))
         {
            WriteLine($"Removed {sessionId} from sessions");
         }
      }

      private void SetData(string sessionId, string key, string value)
      {
         Dictionary<string, string> data;
         if (!_sessionData.TryGetValue(sessionId, out data))
         {
            data = new Dictionary<string, string> {{key, value}};
            _sessionData.TryAdd(sessionId, data);
         }
         else
         {
            string val;
            if (data.TryGetValue(key, out val))
            {
               data.Remove(key);
            }

            data.Add(key, value);
         }
      }

      public string GetData(string sessionId, string key)
      {
         Dictionary<string, string> data;
         string value;
         return _sessionData.TryGetValue(sessionId, out data)
            ? data.TryGetValue(key, out value) ? value : StatusNotFound
            : StatusNotFound;
      }

      public string ParseData(string sessionId, string requestAction)
      {
         var sessionData = requestAction.Split('=');
         if (sessionData.Length != 2)
         {
            return StatusUnknown;
         }

         var key = sessionData[0];
         var value = sessionData[1];
         SetData(sessionId, key, value);

         return $"{key}={value}";
      }

      public bool Touch(string sessionId)
      {
         Session oldHeader;
         if (!_sessions.TryGetValue(sessionId, out oldHeader))
         {
            return false;
         }

         var updatedHeader = oldHeader;
         updatedHeader.LastAccessTime = DateTime.UtcNow;
         _sessions.TryUpdate(sessionId, updatedHeader, oldHeader);

         return true;
      }
   }
}