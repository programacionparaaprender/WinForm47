namespace RssNewsReader
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panel1 = new System.Windows.Forms.Panel();
            this.showDescriptionsCheckBox = new System.Windows.Forms.CheckBox();
            this.FilterButton = new System.Windows.Forms.Button();
            this.PatternTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LoadButton = new System.Windows.Forms.Button();
            this.UrlComboBox = new System.Windows.Forms.ComboBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ChannelInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NewsItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChannelInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewsItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.showDescriptionsCheckBox);
            this.panel1.Controls.Add(this.FilterButton);
            this.panel1.Controls.Add(this.PatternTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LoadButton);
            this.panel1.Controls.Add(this.UrlComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 112);
            this.panel1.TabIndex = 0;
            // 
            // showDescriptionsCheckBox
            // 
            this.showDescriptionsCheckBox.AutoSize = true;
            this.showDescriptionsCheckBox.Location = new System.Drawing.Point(13, 83);
            this.showDescriptionsCheckBox.Name = "showDescriptionsCheckBox";
            this.showDescriptionsCheckBox.Size = new System.Drawing.Size(112, 17);
            this.showDescriptionsCheckBox.TabIndex = 5;
            this.showDescriptionsCheckBox.Text = "Show descriptions";
            this.showDescriptionsCheckBox.UseVisualStyleBackColor = true;
            this.showDescriptionsCheckBox.CheckedChanged += new System.EventHandler(this.showDescriptionsCheckBox_CheckedChanged);
            // 
            // FilterButton
            // 
            this.FilterButton.Location = new System.Drawing.Point(222, 54);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(75, 23);
            this.FilterButton.TabIndex = 4;
            this.FilterButton.Text = "Filter";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // PatternTextBox
            // 
            this.PatternTextBox.Location = new System.Drawing.Point(13, 56);
            this.PatternTextBox.Name = "PatternTextBox";
            this.PatternTextBox.Size = new System.Drawing.Size(202, 20);
            this.PatternTextBox.TabIndex = 3;
            this.PatternTextBox.Text = "*report*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Show only items that match this pattern:";
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(443, 12);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 1;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // UrlComboBox
            // 
            this.UrlComboBox.FormattingEnabled = true;
            this.UrlComboBox.Items.AddRange(new object[] {
            "http://msdn.microsoft.com/sql/rss.xml",
            "http://msdn.microsoft.com/rss.xml",
            "http://msdn.microsoft.com/vs2005/rss.xml"});
            this.UrlComboBox.Location = new System.Drawing.Point(13, 13);
            this.UrlComboBox.Name = "UrlComboBox";
            this.UrlComboBox.Size = new System.Drawing.Size(424, 21);
            this.UrlComboBox.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "RssNewsReader_ChannelInfo";
            reportDataSource1.Value = this.ChannelInfoBindingSource;
            reportDataSource2.Name = "RssNewsReader_NewsItem";
            reportDataSource2.Value = this.NewsItemBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.EnableHyperlinks = true;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "RssNewsReader.Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 112);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowToolBar = false;
            this.reportViewer1.Size = new System.Drawing.Size(529, 335);
            this.reportViewer1.TabIndex = 1;
            // 
            // ChannelInfoBindingSource
            // 
            this.ChannelInfoBindingSource.DataSource = typeof(RssNewsReader.ChannelInfo);
            // 
            // NewsItemBindingSource
            // 
            this.NewsItemBindingSource.DataSource = typeof(RssNewsReader.NewsItem);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 447);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "RSS News Reader";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChannelInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewsItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.ComboBox UrlComboBox;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.TextBox PatternTextBox;
        private System.Windows.Forms.CheckBox showDescriptionsCheckBox;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ChannelInfoBindingSource;
        private System.Windows.Forms.BindingSource NewsItemBindingSource;
    }
}

