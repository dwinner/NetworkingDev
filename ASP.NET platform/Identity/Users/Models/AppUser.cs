using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Users.Models
{
   public class AppUser : IdentityUser
   {
      public Cities City { get; set; }
      public Countries Country { get; set; }

      public void SetCountryFromCity(Cities city)
      {
         switch (city)
         {
            case Cities.London:
               Country = Countries.Uk;
               break;
            case Cities.Paris:
               Country = Countries.France;
               break;
            case Cities.Chicago:
               Country = Countries.Usa;
               break;
            default:
               Country = Countries.None;
               break;
         }
      }
   }

   public enum Cities
   {
      [Display(Name = "Не выбрано")]
      None,

      [Display(Name = "Лондон")]
      London,

      [Display(Name = "Париж")]
      Paris,

      [Display(Name = "Чикаго")]
      Chicago
   }

   public enum Countries
   {
      [Display(Name = "Не выбрано")]
      None,

      [Display(Name = "Великобритания")]
      Uk,

      [Display(Name = "Франция")]
      France,

      [Display(Name = "США")]
      Usa
   }
}