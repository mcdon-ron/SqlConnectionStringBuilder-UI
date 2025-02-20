using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace SqlConnectionStringBuilderUI
{
    public partial class MainForm : Form
    {
        private SqlConnctionStringBuilderModel model;

        public MainForm()
        {
            InitializeComponent();

            model = new SqlConnctionStringBuilderModel();
            pgBuilder.SelectedObject = model;
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cs = model.ConnectionString;
            try
            {
                using (var con = new SqlConnection(cs))
                {
                    con.Open();
                    MessageBox.Show("Test Connection Success", this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(model.ConnectionString);
        }

        private void copyXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(model.ConnectionStringXML);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                try
                {
                    model.ConnectionString = Clipboard.GetText();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), this.Text);
                }
                pgBuilder.Refresh();
            }
        }

        private void pasteXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                try
                {
                    model.ConnectionStringXML = Clipboard.GetText();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), this.Text);
                }
                pgBuilder.Refresh();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.Clear();
            pgBuilder.Refresh();
        }
    }
}
