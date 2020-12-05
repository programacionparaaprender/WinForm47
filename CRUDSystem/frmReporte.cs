using CRUDSystem.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CRUDSystem
{
    public partial class frmReporte : Form
    {
        private List<Detail> details;
        public frmReporte(List<Detail> details)
        {
            InitializeComponent();
            this.details = details;
        }
        public frmReporte()
        {
            InitializeComponent();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'TESTDataSet.Details' Puede moverla o quitarla según sea necesario.
            //this.DetailsTableAdapter.Fill(this.TESTDataSet.Details);
            //Limpiemos el DataSource del informe
            ReportViewer1.LocalReport.DataSources.Clear();
            //
            //Establezcamos los parámetros que enviaremos al reporte
            //recuerde que son dos para el titulo del reporte y para el nombre de la empresa
            //
            //ReportParameter[] parameters = new ReportParameter[2];
            //parameters[0] = new ReportParameter("parameterTitulo", Titulo);
            //parameters[1] = new ReportParameter("parameterEmpresa", Empresa);

            //
            //Establezcamos la lista como Datasource del informe
            //
            //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Invoice));
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", details));
            //
            //Enviemos la lista de parametros
            //
            //ReportViewer1.LocalReport.SetParameters(parameters);
            //
            //Hagamos un refresh al reportViewer
            //
            ReportViewer1.RefreshReport();
        }
    }
}
