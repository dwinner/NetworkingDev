using System.Web.ModelBinding;
using System.Web.UI;
using Binding.Models;

namespace Binding
{
   public partial class Default : Page
   {
      public Person GetData([Form] Person person) => person;      
   }
}