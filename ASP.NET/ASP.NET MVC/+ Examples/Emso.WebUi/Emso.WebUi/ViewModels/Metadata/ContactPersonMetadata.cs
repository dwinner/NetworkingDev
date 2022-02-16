using System;
using System.ComponentModel.DataAnnotations;
using Emso.WebUi.Models.ContactUs;
using Emso.WebUi.Properties;

namespace Emso.WebUi.ViewModels.Metadata
{
   public class ContactPersonMetadata
   {
      [Required(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "Contact_FirstNameRequired")]
      [DataType(DataType.Text, ErrorMessageResourceType = typeof (Resources),
         ErrorMessageResourceName = "Contact_FirstNameDataType")]
      [StringLength(20, MinimumLength = 3, ErrorMessageResourceType = typeof (Resources),
         ErrorMessageResourceName = "Contact_FirstNameRange")]
      [Display(ResourceType = typeof (Resources), Name = "Contact_FirstName")]
      public string FirstName { get; set; }

      [Required(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "Contact_LastNameRequired")]
      [DataType(DataType.Text, ErrorMessageResourceType = typeof (Resources),
         ErrorMessageResourceName = "Contact_LastNameDataType")]
      [StringLength(30, MinimumLength = 3, ErrorMessageResourceType = typeof (Resources),
         ErrorMessageResourceName = "Contact_LastNameRange")]
      [Display(ResourceType = typeof (Resources), Name = "Contact_LastName")]
      public string LastName { get; set; }

      [Required(ErrorMessageResourceType = typeof (Resources),
         ErrorMessageResourceName = "Contact_TelephoneNumberRequired")]
      [DataType(DataType.PhoneNumber, ErrorMessageResourceType = typeof (Resources),
         ErrorMessageResourceName = "Contact_TelephoneNumberDataType")]
      [Display(ResourceType = typeof (Resources), Name = "Contact_TelephoneNumber")]
      public string TelephoneNumber { get; set; }

      [Required(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "Contact_EmailRequired")]
      [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof (Resources),
         ErrorMessageResourceName = "Contact_EmailValidation")]
      [Display(ResourceType = typeof (Resources), Name = "Contact_Email")]
      public string Email { get; set; }

      [Required(ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = "Contact_BirthDateRequired")]
      [DataType(DataType.Date, ErrorMessageResourceType = typeof (Resources),
         ErrorMessageResourceName = "Contact_BirthDateDataType")]
      [Display(ResourceType = typeof (Resources), Name = "Contact_BirthDate")]
      public DateTime BirthDate { get; set; }

      [Required(ErrorMessageResourceType = typeof (Resources),
         ErrorMessageResourceName = "Contact_CAndCppKnowledgeRatingRequired")]
      [Display(ResourceType = typeof (Resources), Name = "Contact_CAndCppKnowledge")]
      public Rating CAndCppKnowledge { get; set; }

      [Required(ErrorMessageResourceType = typeof (Resources),
         ErrorMessageResourceName = "ContactPerson_CSharpLevelRequired")]
      [Display(ResourceType = typeof (Resources), Name = "ContactPerson_CSharpLanguageLevel")]
      public Rating CSharpKnowledge { get; set; }

      [Required(ErrorMessageResourceType = typeof (Resources),
         ErrorMessageResourceName = "ContactPerson_OodLevelRequired")]
      [Display(ResourceType = typeof (Resources), Name = "ContactPerson_OodKnowledgeLevel")]
      public Rating OodKnowledge { get; set; }

      [Required(ErrorMessageResourceType = typeof (Resources),
         ErrorMessageResourceName = "ContactPerson_OopKnowledgeRequired")]
      [Display(ResourceType = typeof (Resources), Name = "ContactPerson_OopKnowledgeLevel")]
      public Rating OopKnowledge { get; set; }

      [Required(ErrorMessageResourceType = typeof (Resources),
         ErrorMessageResourceName = "ContactPerson_RefactoringKnowledgeRequired")]
      [Display(ResourceType = typeof (Resources), Name = "ContactPerson_RefactoringKnowledgeLevel")]
      public Rating RefactoringKnowledge { get; set; }

      [Required(ErrorMessageResourceType = typeof (Resources),
         ErrorMessageResourceName = "Contact_LanguageRatingRequired")]
      [Display(ResourceType = typeof (Resources), Name = "Contact_Language")]
      public LanguageRating Language { get; set; }

      [DataType(DataType.MultilineText)]
      // ReSharper disable Mvc.TemplateNotResolved
      [UIHint("MultilineText")]
      // ReSharper restore Mvc.TemplateNotResolved
      [Display(ResourceType = typeof (Resources), Name = "Contact_SummaryInfo")]
      public string SummaryInfo { get; set; }
   }
}