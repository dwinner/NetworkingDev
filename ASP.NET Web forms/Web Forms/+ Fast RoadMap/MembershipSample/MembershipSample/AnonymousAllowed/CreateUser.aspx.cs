using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MembershipSample
{
  public partial class CreateUser : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

      MembershipCreateStatus status;
      MembershipUser user = Membership.CreateUser("Christian", "Pa$$w0rd", "christian@christiannagel.com", "was wann wo warum", "keine ahnung", true, out status);
    }
  }
}