using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       EnumerateControlsInPanel();
    }

   private void EnumerateControlsInPanel()
   {
      string theInfo = string.Format("<b>Does the panel have controls? {0}</b><br />",
                                     formPanel.HasControls());
      foreach (Control control in
         formPanel.Controls.Cast<Control>().Where(control => !ReferenceEquals(control.GetType(), typeof (LiteralControl))))
      {
         theInfo += "----------------------------------<br />";
         theInfo += string.Format("Control name? {0} <br />", control);
         theInfo += string.Format("Id? {0} <br />", control.ID);
         theInfo += string.Format("Control visible? {0} <br />", control.Visible);
         theInfo += string.Format("ViewState? {0} <br />", control.EnableViewState);
      }
      controlInfoLabel.Text = theInfo;
   }

   protected void addWidgetsButton_Click(object sender, EventArgs e)
   {
      for (int i = 0; i < 3; i++)
      {
         // Присвоить идентификатор, чтобы позднее можно было получить
         // текстовое значение с использованием входных данных формы
         TextBox textBox = new TextBox
            {
               ID = string.Format("newTextBox{0}", i)
            };
         formPanel.Controls.Add(textBox);
         EnumerateControlsInPanel();
      }
   }

   protected void deleteWidgetsButton_Click(object sender, EventArgs e)
   {
      // Очистить содержимое панели, затем заново перечислить элементы
      formPanel.Controls.Clear();
      EnumerateControlsInPanel();
   }
   
   protected void getTextDataButton_Click(object sender, EventArgs e)
   {
      /* Получить данные формы
      string textBoxValues = "<ul>";
      for (int i = 0; i < Request.Form.Count; i++)
      {
         textBoxValues += string.Format("<li>{0}</li>", Request.Form[i]);
      }
      textBoxValues += "</ul>";
      textBoxDataLabel.Text = textBoxValues;*/
      
      // Получить текстовые поля по имени
      string labelData = string.Format("<li>{0}</li>", Request.Form.Get("newTextBox0"));
      labelData += string.Format("<li>{0}</li>", Request.Form.Get("newTextBox1"));
      labelData += string.Format("<li>{0}</li>", Request.Form.Get("newTextBox2"));
      textBoxDataLabel.Text = labelData;
   }
}