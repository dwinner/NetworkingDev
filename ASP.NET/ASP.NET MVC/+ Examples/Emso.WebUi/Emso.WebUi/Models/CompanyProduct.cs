namespace Emso.WebUi.Models
{
   /// <summary>
   ///    Company product
   /// </summary>
   public sealed class CompanyProduct
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