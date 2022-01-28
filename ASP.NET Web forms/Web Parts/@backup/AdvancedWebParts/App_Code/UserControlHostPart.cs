using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace APress.WebParts.Samples
{
    public class UserControlHostPart : WebPart
    {
        private bool _ControlUpdated = false;
        private string _CurrentUserControlPath = string.Empty;

        [WebBrowsable(true)]
        [Personalizable(PersonalizationScope.User)]
        public string CurrentUserControlPath
        {
            get { return _CurrentUserControlPath; }
            set 
            {
                if(!_CurrentUserControlPath.Equals(string.Empty))
                    _ControlUpdated = true;

                _CurrentUserControlPath = value; 
            }
        }

        private Label FallBackLabel = null;
        private Control CurrentControl = null;

        protected override void CreateChildControls()
        {
            // Label showing a default text if no control is loaded
            FallBackLabel = new Label();
            FallBackLabel.Text = "No control selected";
            FallBackLabel.EnableViewState = false;

            // If a user control is selected, you need to
            // load this control through Page.Load
            LoadSelectedControl();

            // Add the controls to the parent
            Controls.Add(FallBackLabel);
            if (CurrentControl != null)
                Controls.Add(CurrentControl);
        }

        private void LoadSelectedControl()
        {
            if (!_CurrentUserControlPath.Equals(string.Empty))
            {
                try
                {
                    CurrentControl = Page.LoadControl(_CurrentUserControlPath);
                }
                catch (Exception ex)
                {
                    FallBackLabel.Text = "Unable to load control: " + ex.Message;
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (_ControlUpdated)
            {
                // Remove the currently laoded control
                Controls.Remove(CurrentControl);
                LoadSelectedControl();
                Controls.Add(CurrentControl);
            }
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            if (CurrentControl != null)
                CurrentControl.RenderControl(writer);
            else
                FallBackLabel.RenderControl(writer);
        }
    }
}