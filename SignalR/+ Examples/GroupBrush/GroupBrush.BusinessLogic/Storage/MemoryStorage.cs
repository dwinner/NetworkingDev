using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using GroupBrush.Entity;

namespace GroupBrush.BusinessLogic.Storage
{
   public class MemoryStorage : IMemStorage
   {
      private readonly ConcurrentDictionary<string, ConcurrentBag<CanvasBrushAction>> _canvasActions =
         new ConcurrentDictionary<string, ConcurrentBag<CanvasBrushAction>>();

      private readonly ConcurrentDictionary<string, int> _canvasTransactions = new ConcurrentDictionary<string, int>();

      private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, string>> _canvasUsers =
         new ConcurrentDictionary<string, ConcurrentDictionary<string, string>>();

      private readonly ConcurrentDictionary<int, string> _userNames = new ConcurrentDictionary<int, string>();

      public CanvasBrushAction AddBrushAction(string aCanvasId, CanvasBrushAction aBrushData)
      {
         if (!_canvasTransactions.ContainsKey(aCanvasId))
         {
            _canvasTransactions[aCanvasId] = 0;
         }

         var transactionNumber = /*_canvasTransactions[aCanvasId] =*/ _canvasTransactions[aCanvasId]++;
         if (!_canvasActions.ContainsKey(aCanvasId))
         {
            _canvasActions[aCanvasId] = new ConcurrentBag<CanvasBrushAction>();
         }

         aBrushData.Sequence = transactionNumber;
         _canvasActions[aCanvasId].Add(aBrushData);

         return aBrushData;
      }

      public List<CanvasBrushAction> GetBrushActions(string aCanvasId, int currentPosition)
      {
         var actions = new List<CanvasBrushAction>();
         if (_canvasActions.ContainsKey(aCanvasId))
         {
            var storedActions = _canvasActions[aCanvasId];
            actions.AddRange(storedActions.Where(action => action.Sequence >= currentPosition));
            actions.Sort((a, b) => a.Sequence.CompareTo(b.Sequence));
         }

         return actions;
      }

      public List<string> GetCanvasUsers(string aCanvasId)
      {
         var returnValue = new List<string>();
         if (_canvasUsers.ContainsKey(aCanvasId))
         {
            var uniqueList = new HashSet<string>();
            var users = _canvasUsers[aCanvasId];
            foreach (var user in users)
            {
               uniqueList.Add(user.Key);
            }

            returnValue = uniqueList.ToList();
         }

         return returnValue;
      }

      public void AddUserToCanvas(string aCanvasId, string anId)
      {
         if (!_canvasUsers.ContainsKey(aCanvasId))
         {
            _canvasUsers[aCanvasId] = new ConcurrentDictionary<string, string>();
         }

         var users = _canvasUsers[aCanvasId];
         if (!users.ContainsKey(anId))
         {
            users[anId] = anId;
         }
      }

      public void RemoveUserFromCanvas(string aCanvasId, string anId)
      {
         if (!_canvasUsers.ContainsKey(aCanvasId))
            return;

         var users = _canvasUsers[aCanvasId];
         if (users.ContainsKey(anId))
         {
            string tempValue;
            users.TryRemove(anId, out tempValue);
         }
      }

      public string GetUserName(int anId)
      {
         return _userNames.ContainsKey(anId) ? _userNames[anId] : null;
      }

      public void StoreUserName(int anId, string aUserName)
      {
         _userNames[anId] = aUserName;
      }
   }
}