namespace CRUDSystem
{
    partial class frmReporte
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TESTDataSet = new CRUDSystem.TESTDataSet();
            this.DetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DetailsTableAdapter = new CRUDSystem.TESTDataSetTableAdapters.DetailsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.TESTDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportViewer
            // 
            this.ReportViewer1.AllowDrop = true;
            this.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer1.DocumentMapCollapsed = true;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DetailsBindingSource;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.ReportViewer1.LocalReport.DisplayName = "Web Log Analysis";
            this.ReportViewer1.LocalReport.ReportEmbeddedResource = "CRUDSystem.Report1.rdlc";
            this.ReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer1.Name = "ReportViewer";
            this.ReportViewer1.Size = new System.Drawing.Size(812, 570);
            this.ReportViewer1.TabIndex = 0;
            // 
            // TESTDataSet
            // 
            this.TESTDataSet.DataSetName = "TESTDataSet";
            this.TESTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DetailsBindingSource
            // 
            this.DetailsBindingSource.DataMember = "Details";
            this.DetailsBindingSource.DataSource = this.TESTDataSet;
            // 
            // DetailsTableAdapter
            // 
            this.DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporte
            // 
            this.ClientSize = new System.Drawing.Size(812, 570);
            this.Controls.Add(this.ReportViewer1);
            this.Name = "frmReporte";
            this.Load += new System.EventHandler(this.frmReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TESTDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;

        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        private System.Windows.Forms.BindingSource DetailsBindingSource;
        private TESTDataSet TESTDataSet;
        private TESTDataSetTableAdapters.DetailsTableAdapter DetailsTableAdapter;
    }
}
