using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Events
{
   public partial class Default : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
      }

      public IEnumerable<EventDescription> GetEvents()
      {
         return EventCollection.Events;
      }
   }
}