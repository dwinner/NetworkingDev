using System.Collections.Generic;

namespace PushNotifyApp.Models
{
   public class Proposal
   {
      public int Id { get; set; }

      public string Title { get; set; }

      public string Body { get; set; }
   }

   public class ProposalContext
   {
      private static ProposalContext _instance;
      private readonly List<Proposal> _proposals = new List<Proposal>();

      private ProposalContext()
      {         
      }

      public static ProposalContext Instance
      {
         get { return _instance ?? (_instance = new ProposalContext()); }
      }

      public IList<Proposal> Proposals
      {
         get { return _proposals; }
      }
   }
}