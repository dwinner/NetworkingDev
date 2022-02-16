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
    public class CustomerNotesConsumer : WebPart
    {
        private Label NotesTextLabel;
        private TextBox NotesContentText;
        private Button UpdateNotesContent;

        protected override void CreateChildControls()
        {
            NotesTextLabel = new Label();
            NotesTextLabel.Text = DateTime.Now.ToString();

            NotesContentText = new TextBox();
            NotesContentText.TextMode = TextBoxMode.MultiLine;
            NotesContentText.Rows = 5;
            NotesContentText.Columns = 20;

            UpdateNotesContent = new Button();
            UpdateNotesContent.Text = "Update";
            UpdateNotesContent.Click += new EventHandler(UpdateNotesContent_Click);

            Controls.Add(NotesTextLabel);
            Controls.Add(NotesContentText);
            Controls.Add(UpdateNotesContent);
        }

        private bool UpdateFormTextBox = false;

        void UpdateNotesContent_Click(object sender, EventArgs e)
        {
            UpdateFormTextBox = true;
        }

        protected override void OnPreRender(EventArgs e)
        {
            // Don't forget to call base implementation
            base.OnPreRender(e);

            // Initialize control
            if (_NotesProvider != null)
            {
                if (UpdateFormTextBox)
                    _NotesProvider.Notes = NotesContentText.Text;
                else
                    NotesContentText.Text = _NotesProvider.Notes;

                NotesTextLabel.Text = _NotesProvider.SubmittedDate.ToShortDateString();
            }
        }

        private INotesContract _NotesProvider;

        [ConnectionConsumer("Customer Notes", "MyConsumerID")]
        public void InitializeProvider(INotesContract provider)
        {
            _NotesProvider = provider;
            if (UpdateFormTextBox)
                _NotesProvider.Notes = NotesContentText.Text;
        }

        #region Custom Verbs

        public override WebPartVerbCollection Verbs
        {
            get
            {
                WebPartVerb RefreshVerb = new WebPartVerb("Refresh", 
                                            new WebPartEventHandler(RefreshVerb_Click));
                RefreshVerb.Text = "Refresh Now";
                WebPartVerb[] NewVerbs = new WebPartVerb[] { RefreshVerb };

                WebPartVerbCollection vc = new WebPartVerbCollection(base.Verbs, NewVerbs);
                return vc;
            }
        }

        protected void RefreshVerb_Click(object sender, WebPartEventArgs e)
        {
            UpdateFormTextBox = true;
        }

        #endregion
    }
}