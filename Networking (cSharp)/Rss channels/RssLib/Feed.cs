/**
 * Упрощенный вариант библитеки для анализа RSS-ленты новостей
 */

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Net;
using System.Globalization;

namespace RssLib
{
   public class Feed
   {
      public Channel Read(string url)
      {
         WebRequest request = WebRequest.Create(url);

         WebResponse response = request.GetResponse();
         XmlDocument doc = new XmlDocument();
         try
         {
            doc.Load(response.GetResponseStream());
            Channel channel = new Channel();
            XmlElement rssElement = doc["rss"];
            if (rssElement == null)
               return null;
            XmlElement channelElement = rssElement["channel"];

            if (channelElement != null)
            {
               // Прочитать лишь некоторые из имеющихся полей
               channel.Title = channelElement["title"].InnerText;
               channel.Link = channelElement["link"].InnerText;
               channel.Description = channelElement["description"].InnerText;
               channel.Culture = CultureInfo.CreateSpecificCulture(channelElement["language"].InnerText);
               channel.Items = new List<Item>();
               XmlNodeList itemElements = channelElement.GetElementsByTagName("item");
               foreach (Item item in from XmlElement itemElement in itemElements select new Item
                  {
                     Title = itemElement["title"].InnerText,
                     Link = itemElement["link"].InnerText,
                     Description = itemElement["description"].InnerText,
                     PubDate = itemElement["pubDate"].InnerText
                  })
               {
                  channel.Items.Add(item);
               }
            }
            return channel;
         }
         catch (XmlException)
         {
            return null;
         }
      }

      public void Write(Stream stream, Channel channel)
      {
         XmlWriter writer = XmlWriter.Create(stream);
         writer.WriteStartElement("rss");
         writer.WriteAttributeString("version", "2.0");
         writer.WriteStartElement("channel");
         writer.WriteElementString("title", channel.Title);
         writer.WriteElementString("link", channel.Link);
         writer.WriteElementString("description", channel.Description);
         writer.WriteElementString("language", channel.Culture.ToString());
         foreach (Item item in channel.Items)
         {
            writer.WriteStartElement("item");
            writer.WriteElementString("title", item.Title);
            writer.WriteElementString("link", item.Link);
            writer.WriteElementString("description", item.Description);
            writer.WriteElementString("pubDate", item.PubDate);
            writer.WriteEndElement();
         }

         writer.WriteEndElement();
         writer.WriteEndElement();

         writer.Flush();
      }
   }
}
