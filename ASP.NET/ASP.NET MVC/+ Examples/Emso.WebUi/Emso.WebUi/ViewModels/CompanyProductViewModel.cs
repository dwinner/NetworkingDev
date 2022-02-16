using System.ComponentModel.DataAnnotations;
using Emso.WebUi.ViewModels.Metadata;

namespace Emso.WebUi.ViewModels
{
   /// <summary>
   ///    Company product view model
   /// </summary>
   [MetadataType(typeof (CompanyProductMetadata))]
   public sealed class CompanyProductViewModel
   {
      /// <summary>
      ///    Product title
      /// </summary>
      public string Title { get; set; }

      /// <summary>
      ///    Product description
      /// </summary>
      public string Description { get; set; }

      /// <summary>
      ///    Image path for product
      /// </summary>
      public string ImagePath { get; set; }
   }
}