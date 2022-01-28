using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Apress.ExternalWebParts
{
    public class ExternalPart : WebPart
    {
        public ExternalPart()
        {
            this.ExportMode = WebPartExportMode.All;
        }

        private Label TestLabel;
        private TextBox TestTextBox;
        private Button TestButton;
        private ListBox TestList;

        protected override void CreateChildControls()
        {
            TestLabel = new Label();
            TestTextBox = new TextBox();
            TestButton = new Button();
            TestList = new ListBox();

            Controls.Add(TestLabel);
            Controls.Add(TestTextBox);
            Controls.Add(TestButton);
            Controls.Add(TestList);

            TestButton.Click += new EventHandler(TestButton_Click);
        }

        void TestButton_Click(object sender, EventArgs e)
        {
            TestList.Items.Add(TestTextBox.Text);
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            TestLabel.Text = "Enter value:";
            TestLabel.RenderControl(writer);
            writer.WriteBreak();
            TestTextBox.RenderControl(writer);
            writer.WriteBreak();
            TestButton.Text = "Add";
            TestButton.RenderControl(writer);
            writer.WriteBreak();
            TestList.RenderControl(writer);
        }
    }
}
