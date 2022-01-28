using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Books.Entities;
using Books.Web.DataContexts;

namespace Books.Web.Controllers
{
   [Authorize]
   public class BooksController : Controller
   {
      private readonly BooksDb _booksDb = new BooksDb();

      // GET: /Books/
      public async Task<ActionResult> Index()
      {
         return View(await _booksDb.Books.ToListAsync());
      }

      // GET: /Books/Details/5
      public async Task<ActionResult> Details(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         Book book = await _booksDb.Books.FindAsync(id);
         if (book == null)
         {
            return HttpNotFound();
         }
         return View(book);
      }

      // GET: /Books/Create
      public ActionResult Create()
      {
         return View();
      }

      // POST: /Books/Create
      // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
      // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Create([Bind(Include = "Id,Title,Category")] Book book)
      {
         if (ModelState.IsValid)
         {
            _booksDb.Books.Add(book);
            await _booksDb.SaveChangesAsync();
            return RedirectToAction("Index");
         }

         return View(book);
      }

      // GET: /Books/Edit/5
      public ActionResult Edit(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         Book book = _booksDb.Books.Find(id);
         if (book == null)
         {
            return HttpNotFound();
         }
         return View(book);
      }

      // POST: /Books/Edit/5
      // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
      // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Edit([Bind(Include = "Id,Title,Category")] Book book)
      {
         if (ModelState.IsValid)
         {
            _booksDb.Entry(book).State = EntityState.Modified;
            _booksDb.SaveChanges();
            return RedirectToAction("Index");
         }
         return View(book);
      }

      // GET: /Books/Delete/5
      public ActionResult Delete(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         Book book = _booksDb.Books.Find(id);
         if (book == null)
         {
            return HttpNotFound();
         }
         return View(book);
      }

      // POST: /Books/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public ActionResult DeleteConfirmed(int id)
      {
         Book book = _booksDb.Books.Find(id);
         _booksDb.Books.Remove(book);
         _booksDb.SaveChanges();
         return RedirectToAction("Index");
      }

      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            _booksDb.Dispose();
         }
         base.Dispose(disposing);
      }
   }
}