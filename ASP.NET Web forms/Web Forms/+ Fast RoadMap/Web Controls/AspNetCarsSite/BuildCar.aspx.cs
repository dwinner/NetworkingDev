using System;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void WizardId_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
       // Получить каждое значение
       string order = string.Format("{0}, yuor {1} {2} will arrive on {3}.",
                                    CarNameTextBoxId.Text,
                                    ListBoxId.SelectedValue,
                                    PickModelTextBoxId.Text,
                                    DeliveryDateCalendarId.SelectedDate.ToShortDateString());
       // Присвоить резульрирующую строку меню
       orderLabel.Text = order;
    }
}