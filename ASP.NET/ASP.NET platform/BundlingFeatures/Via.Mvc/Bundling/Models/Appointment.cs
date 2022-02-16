using System.ComponentModel.DataAnnotations;

namespace Bundling.Models
{
   public class Appointment
   {
      [Required]
      public string ClientName { get; set; }

      public bool TermsAccepted { get; set; }
   }
}