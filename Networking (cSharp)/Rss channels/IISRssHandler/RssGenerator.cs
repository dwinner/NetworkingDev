/**
 * HTTP-обработчик для ленты новостей
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Globalization;
using System.Web;
using RssLib;

namespace IISRssHandler
{
   class RssGenerator : IHttpHandler
   {
      private readonly Feed _feed = new Feed();

      #region IHttpHandler Members

      public bool IsReusable
      {
         get { return true; }
      }

      public void ProcessRequest(HttpContext context)
      {
         context.Response.ContentType = "application/xml";
         CreateFeedContent(context.Response.OutputStream);
      }

      #endregion

      private void CreateFeedContent(Stream outStream)
      {
         Channel channel = GetFeedFromDb();
         _feed.Write(outStream, channel);
      }

      private static Channel GetFeedFromDb()
      {
         using (IDataReader reader = CreateDataSet().CreateDataReader())
         {
            Channel channel = new Channel
               {
                  Title = "Test Feed",
                  Link = "http://localhost",
                  Description = "A sample RSS generator",
                  Culture = CultureInfo.CurrentCulture,
                  Items = new List<Item>()
               };
            while (reader.Read())
            {
               Item item = new Item
                  {
                     Title = reader["title"] as string,
                     Link = reader["link"] as string,
                     PubDate = reader["pubDate"] as string,
                     Description = reader["description"] as string
                  };
               channel.Items.Add(item);
            }
            return channel;
         }
      }

      private static DataSet CreateDataSet()
      {
         // TODO: Получить информацию из базы данных и записать ее в DataSet
         DataSet dataSet = new DataSet();
         DataTable contentTable = new DataTable("ContentItems");
         dataSet.Tables.Add(contentTable);
         contentTable.Columns.AddRange(
             new[]
                {
                    new DataColumn("title", typeof(string)),
                    new DataColumn("link", typeof(string)),
                    new DataColumn("pubDate", typeof(string)),
                    new DataColumn("description", typeof(string))
                });
         contentTable.Rows.Add("Title 1", "http://example.com/link1",
            DateTime.UtcNow.ToString(CultureInfo.InvariantCulture), "Some sample content");
         contentTable.Rows.Add("Title 2", "http://example.com/link2",
            DateTime.UtcNow.ToString(CultureInfo.InvariantCulture), "Some more sample content");
         return dataSet;
      }

   }
}
