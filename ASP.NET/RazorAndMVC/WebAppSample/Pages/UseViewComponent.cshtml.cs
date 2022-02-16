using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppSample.Pages;

public class UseViewComponentModel : PageModel
{
   public bool ShowEvents { get; set; }

   [BindProperty]
   public DateSelectionViewModel DateSelection { get; set; } = new();

   public IActionResult OnGet() => Page();

   public IActionResult OnPost()
   {
      ShowEvents = true;
      return Page();
   }
}

public class DateSelectionViewModel
{
   public DateTime From { get; set; } = DateTime.Today;

   public DateTime To { get; set; } = DateTime.Today.AddDays(20);
}