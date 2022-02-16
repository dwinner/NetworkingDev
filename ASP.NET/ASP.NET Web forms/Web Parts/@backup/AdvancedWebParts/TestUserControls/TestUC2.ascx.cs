using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class TestUserControls_TestUC2 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void AddCommand_Click(object sender, EventArgs e)
    {
        ResultsText.Text = (Int32.Parse(FirstValue.Text) + Int32.Parse(SecondValue.Text)).ToString();
    }
    protected void SubCommand_Click(object sender, EventArgs e)
    {
        ResultsText.Text = (Int32.Parse(FirstValue.Text) - Int32.Parse(SecondValue.Text)).ToString();
    }
}
