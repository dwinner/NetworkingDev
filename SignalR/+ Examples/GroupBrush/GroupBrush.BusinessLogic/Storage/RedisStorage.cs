using System.Collections.Generic;
using System.Linq;
using BookSleeve;
using GroupBrush.Entity;
using Newtonsoft.Json;

namespace GroupBrush.BusinessLogic.Storage
{
   public class RedisStorage : IMemStorage
   {
      private const string TransactionPrefix = "CanvasTransaction:";
      private const string ActionPrefix = "CanvasBrushAction:";
      private const string UsersPrefix = "CanvasUsers:";
      private const string UsernamesPrefix = "CanvasUsernames:";

      private readonly RedisConfiguration _redisConfiguration;
      private readonly Dictionary<int, string> _userNames;

      public RedisStorage(RedisConfiguration redisConfiguration)
      {
         _redisConfiguration = redisConfiguration;
         _userNames = new Dictionary<int, string>();
      }

      public CanvasBrushAction AddBrushAction(string aCanvasId, CanvasBrushAction aBrushData)
      {
         int transactionNumber;
         using (
            var redisConnection = new RedisConnection(_redisConfiguration.HostName, _redisConfiguration.Port,
               password: _redisConfiguration.Password))
         {
            redisConnection.Open();
            var incTask = redisConnection.Hashes.Increment(0, string.Format("{0}{1}", TransactionPrefix, aCanvasId),
               "transaction");
            transactionNumber = (int)incTask.Result;
         }

         aBrushData.Sequence = transactionNumber;
         var serializedData = JsonConvert.SerializeObject(aBrushData);

         using (
            var redisConnection = new RedisConnection(_redisConfiguration.HostName, _redisConfiguration.Port,
               password: _redisConfiguration.Password))
         {
            redisConnection.Open();
            redisConnection.Lists.AddLast(0, string.Format("{0}{1}", ActionPrefix, aCanvasId), serializedData);
         }

         return aBrushData;
      }

      public List<CanvasBrushAction> GetBrushActions(string aCanvasId, int currentPosition)
      {
         var actions = new List<CanvasBrushAction>();
         string[] storedActions;
         using (
            var redisConnection = new RedisConnection(_redisConfiguration.HostName, _redisConfiguration.Port,
               password: _redisConfiguration.Password))
         {
            redisConnection.Open();
            var rangeTask = redisConnection.Lists.RangeString(0, string.Format("{0}{1}", ActionPrefix, aCanvasId),
               currentPosition, int.MaxValue);
            storedActions = rangeTask.Result;
         }

         if (storedActions != null)
         {
            actions.AddRange(storedActions.Select(JsonConvert.DeserializeObject<CanvasBrushAction>));
            actions.Sort((a, b) => a.Sequence.CompareTo(b.Sequence));
         }

         return actions;
      }

      public List<string> GetCanvasUsers(string aCanvasId)
      {
         var uniqueList = new HashSet<string>();
         using (
            var redisConnection = new RedisConnection(_redisConfiguration.HostName, _redisConfiguration.Port,
               password: _redisConfiguration.Password))
         {
            redisConnection.Open();
            var getAllTask = redisConnection.Sets.GetAllString(0, string.Format("{0}{1}", UsersPrefix, aCanvasId));
            uniqueList.BatchAdd(getAllTask.Result);
         }

         return uniqueList.ToList();
      }

      public void AddUserToCanvas(string aCanvasId, string anId)
      {
         using (
            var redisConnection = new RedisConnection(_redisConfiguration.HostName, _redisConfiguration.Port,
               password: _redisConfiguration.Password))
         {
            redisConnection.Open();
            redisConnection.Sets.Add(0, string.Format("{0}{1}", UsersPrefix, aCanvasId), anId);
         }
      }

      public void RemoveUserFromCanvas(string aCanvasId, string anId)
      {
         using (
            var redisConnection = new RedisConnection(_redisConfiguration.HostName, _redisConfiguration.Port,
               password: _redisConfiguration.Password))
         {
            redisConnection.Open();
            redisConnection.Sets.Remove(0, string.Format("{0}{1}", UsersPrefix, aCanvasId), aCanvasId);
         }
      }

      public string GetUserName(int anId)
      {
         string userName;
         if (_userNames.ContainsKey(anId))
         {
            userName = _userNames[anId];
         }
         else
         {
            using (
               var redisConnection = new RedisConnection(_redisConfiguration.HostName, _redisConfiguration.Port,
                  password: _redisConfiguration.Password))
            {
               redisConnection.Open();
               var getTask = redisConnection.Strings.GetString(0, string.Format("{0}{1}", UsernamesPrefix, anId));
               userName = getTask.Result;
               _userNames[anId] = userName;
            }
         }

         return userName;
      }

      public void StoreUserName(int anId, string aUserName)
      {
         using (
            var redisConnection = new RedisConnection(_redisConfiguration.HostName, _redisConfiguration.Port,
               password: _redisConfiguration.Password))
         {
            redisConnection.Open();
            redisConnection.Strings.Set(0, string.Format("{0}{1}", UsernamesPrefix, anId), aUserName).Wait();
         }

         _userNames[anId] = aUserName;
      }
   }

   internal static class SetExtensions
   {
      public static void BatchAdd<T>(this ISet<T> aSet, IEnumerable<T> collToAdd)
      {
         foreach (var item in collToAdd)
         {
            aSet.Add(item);
         }
      }
   }
}