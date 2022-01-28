/**
 * Клиент OData-сервиса
 */

using System;
using System.Linq;
using ClientApp.FormulaServiceReference;

namespace ClientApp
{
   internal static class Program
   {
      private static readonly Container DataServiceContainer = new Container(new Uri("http://localhost:8750/odata"));

      private static void Main()
      {
         ReadSample();
         CreateRacer();
         UpdateSample();
      }

      private static void ReadSample() // Чтение
      {
         IQueryable<Racer> q = from racer in DataServiceContainer.Racer
                               where racer.FirstName.StartsWith("A")
                               orderby racer.Wins
                               select racer;
         foreach (Racer racer in q)
         {
            Console.WriteLine("{0} {1}", racer.FirstName, racer.LastName);
         }
      }

      private static void CreateRacer() // Добавление записи
      {
         DataServiceContainer.AddToRacer(new Racer
         {
            FirstName = "Valtteri",
            LastName = "Botas",
            Wins = 0,
            Starts = 19
         });

         /*DataServiceResponse response = */
         DataServiceContainer.SaveChanges();
      }

      private static void UpdateSample()  // Обновление записи
      {
         Racer racerToUpdate = (from racer in DataServiceContainer.Racer
                                where racer.FirstName == "Sebastian" && racer.LastName == "Vettel"
                                select racer).FirstOrDefault();
         if (racerToUpdate != null)
         {
            racerToUpdate.Starts = 120;
            racerToUpdate.Wins = 39;
            DataServiceContainer.UpdateObject(racerToUpdate);
            /*DataServiceResponse response = */
            DataServiceContainer.SaveChanges();
         }
      }
   }
}