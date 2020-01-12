using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace RssNewsReader
{
    public partial class MainForm : Form
    {
        private string m_appName = "RSS News Reader";
        private bool m_reportDisplayed;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void SetReportParameters()
        {
            ReportParameter showDescParameter = new ReportParameter("ShowDescriptions", 
                this.showDescriptionsCheckBox.Checked ? "true" : "false");
            string pattern = this.PatternTextBox.Text.Trim();
            if (String.IsNullOrEmpty(pattern))
                pattern = "*";
            ReportParameter patternParameter = new ReportParameter("PatternToMatch", pattern);
            this.reportViewer1.LocalReport.SetParameters(
                      new ReportParameter[] { showDescParameter, patternParameter });
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            SetReportParameters();
            if (m_reportDisplayed)
                this.reportViewer1.RefreshReport();
        }

        private void showDescriptionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetReportParameters();
            if (m_reportDisplayed)
                this.reportViewer1.RefreshReport();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            string url = this.UrlComboBox.Text;
            if (String.IsNullOrEmpty(url))
                return;
            if (!url.StartsWith("http://"))
            {
                MessageBox.Show("Not a valid url", m_appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Uri uri = new Uri(url);

            RssNewsReader.FeedReader reader = new RssNewsReader.FeedReader(uri);
            Cursor previousCursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                reader.Load();
                this.NewsItemBindingSource.DataSource = reader.NewsItems;
                this.ChannelInfoBindingSource.DataSource = reader.ChannelInfo;
                SetReportParameters();
                this.reportViewer1.RefreshReport();
                m_reportDisplayed = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, m_appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                this.Cursor = previousCursor;
            }
        }
    }
}
