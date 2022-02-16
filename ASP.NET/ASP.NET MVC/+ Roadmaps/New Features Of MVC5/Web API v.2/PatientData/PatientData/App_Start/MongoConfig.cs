using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PatientData.Models;

namespace PatientData
{
   public static class MongoConfig
   {
      public static void Seed()
      {
         MongoCollection<Patient> patients = PatientDb.Open();

         if (!patients.AsQueryable().Any(p => p.Name == "Scott"))
         {
            var data = new List<Patient>
            {
               new Patient
               {
                  Name = "Scott",
                  Ailments = new List<Ailment> {new Ailment {Name = "Crazy"}, new Ailment {Name = "Old"}},
                  Medications = new List<Medication> {new Medication {Name = "Aspirin", Doses = 2}}
               },
               new Patient
               {
                  Name = "Joy",
                  Ailments = new List<Ailment> {new Ailment {Name = "Crazy"}, new Ailment {Name = "Young"}},
                  Medications = new List<Medication> {new Medication {Name = "Aspirin", Doses = 2}}
               },
               new Patient
               {
                  Name = "Sarah",
                  Ailments = new List<Ailment> {new Ailment {Name = "Crazy"}, new Ailment {Name = "Youngest"}},
                  Medications = new List<Medication> {new Medication {Name = "Aspirin", Doses = 2}}
               }
            };

            patients.InsertBatch(data);
         }
      }
   }
}