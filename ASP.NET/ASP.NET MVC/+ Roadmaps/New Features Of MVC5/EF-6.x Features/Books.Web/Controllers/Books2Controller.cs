using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Books.Entities;
using Books.Web.DataContexts;

namespace Books.Web.Controllers
{
   public class Books2Controller : Controller
   {
      private readonly BooksDb _booksDb = new BooksDb();

      // GET: /Books2/
      public async Task<ActionResult> Index()
      {
         //List<Book> books = await _booksDb.Books.Where(book => book.Title == "Title").ToListAsync();
         return View(await _booksDb.Books.ToListAsync());
      }

      // GET: /Books2/Details/5
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

      // GET: /Books2/Create
      public ActionResult Create()
      {
         return View();
      }

      // POST: /Books2/Create
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

      // GET: /Books2/Edit/5
      public async Task<ActionResult> Edit(int? id)
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

      // POST: /Books2/Edit/5
      // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
      // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Category")] Book book)
      {
         if (ModelState.IsValid)
         {
            _booksDb.Entry(book).State = EntityState.Modified;
            await _booksDb.SaveChangesAsync();
            return RedirectToAction("Index");
         }
         return View(book);
      }

      // GET: /Books2/Delete/5
      public async Task<ActionResult> Delete(int? id)
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

      // POST: /Books2/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> DeleteConfirmed(int id)
      {
         Book book = await _booksDb.Books.FindAsync(id);
         _booksDb.Books.Remove(book);
         await _booksDb.SaveChangesAsync();
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