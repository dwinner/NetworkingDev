using System;
using System.ComponentModel.DataAnnotations;
using Emso.WebUi.Models.ContactUs;
using Emso.WebUi.ViewModels.Metadata;

namespace Emso.WebUi.ViewModels
{
   /// <summary>
   ///    Person to contact
   /// </summary>
   [MetadataType(typeof (ContactPersonMetadata))]
   public sealed class ContactPersonViewModel
   {
      /// <summary>
      ///    First name
      /// </summary>
      public string FirstName { get; set; }

      /// <summary>
      ///    Last name
      /// </summary>
      public string LastName { get; set; }

      /// <summary>
      ///    Telephone number
      /// </summary>
      public string TelephoneNumber { get; set; }

      /// <summary>
      ///    Email
      /// </summary>
      public string Email { get; set; }

      /// <summary>
      ///    Birth date
      /// </summary>
      public DateTime BirthDate { get; set; }

      /// <summary>
      ///    CAndCppKnowledge of OOD
      /// </summary>
      public Rating CAndCppKnowledge { get; set; }

      /// <summary>
      ///    C# language level
      /// </summary>
      public Rating CSharpKnowledge { get; set; }

      /// <summary>
      ///    OOD Knowledge
      /// </summary>
      public Rating OodKnowledge { get; set; }

      /// <summary>
      ///    OOP knowledge
      /// </summary>
      public Rating OopKnowledge { get; set; }

      /// <summary>
      ///    Refactoring knowledge
      /// </summary>
      public Rating RefactoringKnowledge { get; set; }

      /// <summary>
      ///    Language
      /// </summary>
      public LanguageRating Language { get; set; }

      /// <summary>
      ///    Summary info
      /// </summary>
      public string SummaryInfo { get; set; }
   }
}