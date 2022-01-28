using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;

namespace SyndicationService
{   
   [ServiceContract]
   [ServiceKnownType(typeof (Atom10FeedFormatter))]
   [ServiceKnownType(typeof (Rss20FeedFormatter))]
   public interface IFormulaFeed
   {
      [OperationContract]
      [WebGet(UriTemplate = "*", BodyStyle = WebMessageBodyStyle.Bare)]
      SyndicationFeedFormatter CreateFeed();      
   }
}