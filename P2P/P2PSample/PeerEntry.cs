using System.Net.PeerToPeer;

namespace P2PSample
{
   public class PeerEntry
   {
      public PeerEntry()
      {
         
      }

      public PeerEntry(PeerName peerName, IPeerToPeerService serviceProxy, string displayString, bool buttonsEnabled)
      {
         PeerName = peerName;
         ServiceProxy = serviceProxy;
         DisplayString = displayString;
         ButtonsEnabled = buttonsEnabled;
      }

      public PeerName PeerName { get; set; }

      public IPeerToPeerService ServiceProxy { get; set; }

      public string DisplayString { get; set; }

      public bool ButtonsEnabled { get; set; }
   }
}