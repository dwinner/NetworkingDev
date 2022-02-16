using System;
using System.Web.UI;

namespace CoreServerControls
{
   public partial class BrowserHistory : Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (!Page.IsPostBack)
            Page.Title = "Page 1";
      }

      protected void DefaultScriptManager_OnNavigate(object sender, HistoryEventArgs e)
      {
         DefWizard.ActiveStepIndex = e.State["DefWizard"] == null
            ? 0 // Восстанавливаем первоначальное состояние страницы
            : int.Parse(e.State["DefWizard"]);
         Page.Title = string.Format("Step {0}", (DefWizard.ActiveStepIndex + 1));
      }

      protected void DefWizard_OnActiveStepChanged(object sender, EventArgs e)
      {
         if (DefaultScriptManager.IsInAsyncPostBack && !DefaultScriptManager.IsNavigating)
         {
            var currentStep = DefWizard.ActiveStepIndex.ToString();
            DefaultScriptManager.AddHistoryPoint("DefWizard", DefWizard.ActiveStepIndex.ToString(),
               string.Format("Step {0}", (DefWizard.ActiveStepIndex + 1)));
         }
      }
   }
}