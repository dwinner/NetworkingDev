using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TemplatedHelpers.Models
{
   [DisplayName("New person")]
   public class PersonMetadata
   {
      [HiddenInput(DisplayValue = false)]
      public int PersonId { get; set; }

      [DisplayName("First")]
      // ReSharper disable Mvc.TemplateNotResolved
      [UIHint("MultilineText")]
      // ReSharper restore Mvc.TemplateNotResolved
      public string FirstName { get; set; }

      [DisplayName("Last")]
      public string LastName { get; set; }

      [DisplayName("Birth date")]
      [DataType(DataType.Date)]
      public DateTime BirthDate { get; set; }      

      [DisplayName("Approved")]
      public bool IsApproved { get; set; }

      [UIHint("Enum")]
      public Role Role { get; set; }
   }
}