using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Routing.Router
{
   public class CustomMessageFilter : MessageFilter
   {
      private readonly string _filterParam;

      public CustomMessageFilter(string filterParam)
      {
         _filterParam = filterParam;
      }

      public override bool Match(Message message)
      {
         return true;
      }

      public override bool Match(MessageBuffer buffer)
      {
         XPathExpression expr = XPathExpression.Compile(string.Format("////value == {0}", _filterParam));

         XPathNavigator navigator = buffer.CreateNavigator();
         return navigator.Matches(expr);
         //XDocument doc = await GetMessageEnvelope(buffer);
         //return Match(doc);
      }

      private bool Match(XDocument doc)
      {
         var @value = doc.Elements("value").SingleOrDefault(x => x.Value == "HelloA");
         if (@value != null)
         {
            string result = @value.Value;
            return true;
         }

         return false;
      }

      private async Task<XDocument> GetMessageEnvelope(MessageBuffer buffer)
      {
         using (var stream = new MemoryStream())
         {
            Message msg = buffer.CreateMessage();
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(stream);
            msg.WriteMessage(writer);
            await writer.FlushAsync();
            stream.Seek(0, SeekOrigin.Begin);
            XDocument doc = XDocument.Load(stream);

            return doc;
         }
      }
   }
}