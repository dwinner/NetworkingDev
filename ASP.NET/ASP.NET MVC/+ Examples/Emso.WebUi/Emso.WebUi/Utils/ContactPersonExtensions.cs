using System.Text;
using Emso.WebUi.ViewModels;

namespace Emso.WebUi.Utils
{
   /// <summary>
   ///    Contact person extension methods
   /// </summary>
   public static class ContactPersonExtensions
   {
      /// <summary>
      ///    Generate the message body pattern
      /// </summary>
      /// <param name="person">Person</param>
      /// <returns>Message body pattern</returns>
      public static string GenerateMessageBody(this ContactPersonViewModel person)
      {
         var body = new StringBuilder();
         body.AppendLine(string.Format("First name - {0}", person.FirstName))
            .AppendLine(string.Format("Last name - {0}", person.LastName))
            .AppendLine(string.Format("Telephone number - {0}", person.TelephoneNumber))
            .AppendLine(string.Format("Email - {0}", person.Email))
            .AppendLine(string.Format("Birth date - {0:dd.mm.yyyy}", person.BirthDate))
            .AppendLine(string.Format("C/C++ level - {0}", person.CAndCppKnowledge.GetPercentStr()))
            .AppendLine(string.Format("C# level - {0}", person.CSharpKnowledge.GetPercentStr()))
            .AppendLine(string.Format("OOD level - {0}", person.OodKnowledge.GetPercentStr()))
            .AppendLine(string.Format("OOP level - {0}", person.OopKnowledge.GetPercentStr()))
            .AppendLine(string.Format("Refactoring - {0}", person.RefactoringKnowledge.GetPercentStr()))
            .AppendLine(string.Format("English level - {0}", person.Language))
            .AppendLine(string.Format("Summary information - {0}", person.SummaryInfo));

         return body.ToString();
      }
   }
}