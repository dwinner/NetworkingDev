using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using MongoDB.Bson;
using MongoDB.Driver;
using PatientData.Models;

namespace PatientData.Controllers
{
   [EnableCors("*", "*", "GET")]
   [Authorize]
   public class PatientsController : ApiController
   {
      private readonly MongoCollection<Patient> _patients;

      public PatientsController()
      {
         _patients = PatientDb.Open();
      }

      public IEnumerable<Patient> Get()
      {
         return _patients.FindAll();
      }

      public IHttpActionResult Get(string id)
      {
         Patient patient = _patients.FindOneById(ObjectId.Parse(id));
         return patient == null ? (IHttpActionResult) NotFound() : Ok(patient);
      }

      [Route("api/patients/{id}/medications")]
      public IHttpActionResult GetMedications(string id)
      {
         Patient patient = _patients.FindOneById(ObjectId.Parse(id));
         return patient == null ? (IHttpActionResult) NotFound() : Ok(patient.Medications);
      }
   }
}