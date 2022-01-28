/**
 * Return ATOM or RSS based on query string
 * rss -> http://localhost:8732/Design_Time_Addresses/SyndicationService/FormulaFeed/
 * atom -> http://localhost:8732/Design_Time_Addresses/SyndicationService/FormulaFeed/?format=atom
 */

using System;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Xml.Linq;
using Formula = FormulaEntities.FormulaEntities;

namespace SyndicationService
{
   public class FormulaFeed : IFormulaFeed
   {
      public SyndicationFeedFormatter CreateFeed()
      {
         DateTime fromDate = DateTime.Today - TimeSpan.FromDays(365);
         DateTime toDate = DateTime.Today;
         WebOperationContext context = WebOperationContext.Current;
         if (context == null)
            return null;

         string frm = context.IncomingRequest.UriTemplateMatch.QueryParameters["from"];
         string to = context.IncomingRequest.UriTemplateMatch.QueryParameters["to"];

         if (frm != null && to != null)
         {
            try
            {
               fromDate = DateTime.Parse(frm);
               toDate = DateTime.Parse(to);
            }
            catch (FormatException)
            {
               // Оставляем значения по-умолчанию
            }
         }

         // Создаем синдицируемый канал
         var feed = new SyndicationFeed
         {
            Generator = "Pro C# 4.0 Sample Feed Generator",
            Language = "en-us",
            LastUpdatedTime = new DateTimeOffset(DateTime.Now),
            Title = SyndicationContent.CreatePlaintextContent("Formula1 results")
         };

         feed.Categories.Add(new SyndicationCategory("Formula1"));
         feed.Authors.Add(
            new SyndicationPerson("web@christiannagel.com", "Christian Nagel", "http://www.christiannagel.com"));
         feed.Description = SyndicationContent.CreatePlaintextContent("Sample Formula 1");

         // Заполняем значения синдикации            
         using (var entities = new Formula(ConfigurationManager.ConnectionStrings["FormulaEntities"].ConnectionString))
         {
            var racers = (from racer in entities.Racers
                          from raceResult in racer.RaceResults
                          where raceResult.Race.Date > fromDate && raceResult.Race.Date < toDate && raceResult.Position == 1
                          orderby raceResult.Race.Date
                          select new
                          {
                             raceResult.Race.Circuit.Country,
                             raceResult.Race.Date,
                             Winner = racer.Firstname + " " + racer.Lastname
                          }).ToArray();

            feed.Items = racers.Select(race => new SyndicationItem
            {
               Title = SyndicationContent.CreatePlaintextContent(string.Format("G.P. {0}", race.Country)),
               Content = SyndicationContent.CreateXhtmlContent(
                  new XElement("p",
                     new XElement("h3", string.Format("{0}, {1}", race.Country, race.Date.ToShortDateString())),
                     new XElement("b", string.Format("Winner: {0}", race.Winner))).ToString())
            });

            // Определяем формат возвращаемых данных
            string format = context.IncomingRequest.UriTemplateMatch.QueryParameters["format"];
            return format == "atom"
               ? (SyndicationFeedFormatter)new Atom10FeedFormatter(feed)
               : new Rss20FeedFormatter(feed);
         }
      }
   }
}