using BookModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksViews;

public class CreateModel : PageModel
{
   private readonly BooksContext _context;

   public CreateModel(BooksContext context) => _context = context;

   [BindProperty]
   public Book? Book { get; set; }

   public IActionResult OnGet() => Page();

   // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
   public async Task<IActionResult> OnPostAsync()
   {
      if (!ModelState.IsValid || Book is null)
      {
         return Page();
      }

      _context.Books.Add(Book);
      await _context.SaveChangesAsync().ConfigureAwait(false);

      return RedirectToPage("./Index");
   }
}