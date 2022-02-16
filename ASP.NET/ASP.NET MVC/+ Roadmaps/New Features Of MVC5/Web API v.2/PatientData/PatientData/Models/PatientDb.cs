using MongoDB.Driver;

namespace PatientData.Models
{
   public static class PatientDb
   {
      public static MongoCollection<Patient> Open()
      {
         var client = new MongoClient("mongodb://dwinner:bboytronik1985@localhost");
         MongoServer server = client.GetServer();
         MongoDatabase db = server.GetDatabase("PatientDb");
         return db.GetCollection<Patient>("Patients");
      }
   }
}