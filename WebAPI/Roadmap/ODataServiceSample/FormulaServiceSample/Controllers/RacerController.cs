using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using FormulaServiceSample.Models;

namespace FormulaServiceSample.Controllers
{
   public class RacerController : ODataController
   {
      private readonly FormulaEntities _entities = new FormulaEntities();

      // GET odata/Racer
      [Queryable/*(PageSize = 10)*/]
      public IQueryable<Racer> GetRacer()
      {
         return _entities.Racers;
      }

      // GET odata/Racer(5)
      [Queryable]
      public SingleResult<Racer> GetRacer([FromODataUri] int key)
      {
         return SingleResult.Create(_entities.Racers.Where(racer => racer.Id == key));
      }

      // PUT odata/Racer(5)
      public async Task<IHttpActionResult> Put([FromODataUri] int key, Racer racer)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         if (key != racer.Id)
         {
            return BadRequest();
         }

         _entities.Entry(racer).State = EntityState.Modified;

         try
         {
            await _entities.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException)
         {
            if (!RacerExists(key))
            {
               return NotFound();
            }
            throw;
         }

         return Updated(racer);
      }

      // POST odata/Racer
      public async Task<IHttpActionResult> Post(Racer racer)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         _entities.Racers.Add(racer);
         await _entities.SaveChangesAsync();

         return Created(racer);
      }

      // PATCH odata/Racer(5)
      [AcceptVerbs("PATCH", "MERGE")]
      public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Racer> patch)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         Racer racer = await _entities.Racers.FindAsync(key);
         if (racer == null)
         {
            return NotFound();
         }

         patch.Patch(racer);

         try
         {
            await _entities.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException)
         {
            if (!RacerExists(key))
            {
               return NotFound();
            }
            throw;
         }

         return Updated(racer);
      }

      // DELETE odata/Racer(5)
      public async Task<IHttpActionResult> Delete([FromODataUri] int key)
      {
         Racer racer = await _entities.Racers.FindAsync(key);
         if (racer == null)
         {
            return NotFound();
         }

         _entities.Racers.Remove(racer);
         await _entities.SaveChangesAsync();

         return StatusCode(HttpStatusCode.NoContent);
      }

      // GET odata/Racer(5)/RaceResults
      [Queryable]
      public IQueryable<RaceResult> GetRaceResults([FromODataUri] int key)
      {
         return _entities.Racers.Where(m => m.Id == key).SelectMany(m => m.RaceResults);
      }

      // GET odata/Racer(5)/YearResults
      [Queryable]
      public IQueryable<YearResult> GetYearResults([FromODataUri] int key)
      {
         return _entities.Racers.Where(m => m.Id == key).SelectMany(m => m.YearResults);
      }

      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            _entities.Dispose();
         }
         base.Dispose(disposing);
      }

      private bool RacerExists(int key)
      {
         return _entities.Racers.Count(e => e.Id == key) > 0;
      }
   }
}