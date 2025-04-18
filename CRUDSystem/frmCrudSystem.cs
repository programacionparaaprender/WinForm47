﻿using CRUDSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDSystem
{
    public partial class frmCrudSystem : Form
    {
        private MyDBContext context;

        public frmCrudSystem()
        {
            InitializeComponent();
            context = new MyDBContext();
            this.dataGridView1.DataSource = context.Details.ToList<Detail>();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {

            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =
                    (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Recorremos el DataGridView rellenando la hoja de trabajo

                int variable = 1;
                hoja_trabajo.Cells[variable, 1] = "Titulo 1";
                variable++;

                hoja_trabajo.Cells[variable, 1] = "Titulo 2";
                variable++;

                hoja_trabajo.Cells[variable, 1] = "Titulo 3";

                //combinar las celdas
                hoja_trabajo.Range["A1:F1"].Merge();
                hoja_trabajo.Range["A2:F2"].Merge();
                hoja_trabajo.Range["A3:F3"].Merge();

                hoja_trabajo.Range["A1:F1"].Font.Bold = true;
                hoja_trabajo.Range["A2:F2"].Font.Bold = true;
                hoja_trabajo.Range["A3:F3"].Font.Bold = true;


                hoja_trabajo.Range["A1:F1"].Font.Size = 20;
                hoja_trabajo.Range["A2:F2"].Font.Size = 20;
                hoja_trabajo.Range["A3:F3"].Font.Size = 20;


                variable++;

                

                for(int i = 0; i < this.dataGridView1.Columns.Count; i++)
                {
                    //hoja_trabajo.Cells[variable, 1] = "N°";
                    //hoja_trabajo.Cells[variable, 2] = "Name";
                    //hoja_trabajo.Cells[variable, 3] = "Lastname";
                    //hoja_trabajo.Cells[variable, 4] = "Age";
                    //hoja_trabajo.Cells[variable, 5] = "Address";
                    //hoja_trabajo.Cells[variable, 6] = "D.O.B.";
                    string Nombrecolumna;
                    Nombrecolumna = this.dataGridView1.Columns[i].Name.ToString();
                    hoja_trabajo.Cells[variable, i + 1] = Nombrecolumna;
                }



                hoja_trabajo.Range["A4:F4"].Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                hoja_trabajo.Range["A4:F4"].Font.Bold = true;
                hoja_trabajo.Range["A4:F4"].VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                hoja_trabajo.Range["A4:F4"].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                //aumentar tamaño de celda
                hoja_trabajo.Columns["F"].ColumnWidth = hoja_trabajo.Columns["F"].ColumnWidth * 2;
                hoja_trabajo.Rows[variable].RowHeight = hoja_trabajo.Rows[variable].RowHeight * 2;
                Microsoft.Office.Interop.Excel.Style style;

                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                    {
                        //this.dataGridView1.Rows[i].Cells[j].Style.BackColor;
                        //this.dataGridView1.Rows[i].DefaultCellStyle.BackColor;
                        //hoja_trabajo.Cells[i + 1, j + 1].Interior.Color
                        byte byteR = this.dataGridView1.Rows[i].Cells[j].Style.BackColor.R;
                        byte byteG = this.dataGridView1.Rows[i].Cells[j].Style.BackColor.G;
                        byte byteB = this.dataGridView1.Rows[i].Cells[j].Style.BackColor.B;
                        if (byteR == 0 && byteG == 0 && byteB == 0)
                        {
                            hoja_trabajo.Cells[i + 1, j + 1].Interior.Color = Color.White;

                        }
                        else
                        {
                            style = aplicacion.Application.ActiveWorkbook.Styles.Add("NewStyle" + Convert.ToString(i + 1) + Convert.ToString(j + 1));
                            //style.Font.Bold = true;
                            style.Interior.Color = this.dataGridView1.Rows[i].Cells[j].Style.BackColor;
                            hoja_trabajo.Cells[i + 1, j + 1].Style = "NewStyle"+ Convert.ToString(i + 1) + Convert.ToString(j + 1);

                        }


                        hoja_trabajo.Range["A"+Convert.ToString(i + 1 + variable) +":F"+Convert.ToString(i + 1 + variable)].Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        hoja_trabajo.Cells[i + 1 + variable, j + 1] = this.dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
        }

        private void TxtlName_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var detail = new Detail {
                Fname = this.txtfName.Text,
                Lname = this.txtlName.Text,
                Age = Convert.ToInt32(this.txtAge.Text),
                Address = this.txtAddress.Text,
                DOB = this.dtpDOB.Value };
            
            context.Details.Add(detail);
            context.SaveChanges();

            this.dataGridView1.DataSource = context.Details.ToList<Detail>();

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow dgvrow = this.dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(dgvrow.Cells[0].Value.ToString());
                Detail temp = context.Details.Find(id);
                context.Details.Remove(temp);
                context.SaveChanges();
                this.dataGridView1.DataSource = context.Details.ToList<Detail>();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow dgvrow = this.dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(dgvrow.Cells[0].Value.ToString());
                Detail detail = context.Details.Find(id);
                detail.Fname = this.txtfName.Text;
                detail.Lname = this.txtlName.Text;
                detail.Age = Convert.ToInt32(this.txtAge.Text);
                detail.Address = this.txtAddress.Text;
                detail.DOB = this.dtpDOB.Value;
                
                context.SaveChanges();
                this.dataGridView1.DataSource = context.Details.ToList<Detail>();
            }else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow dgvrow = this.dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(dgvrow.Cells[0].Value.ToString());
                Detail detail = context.Details.Find(id);
                this.txtfName.Text = detail.Fname;
                this.txtlName.Text = detail.Lname;
                this.txtAge.Text = detail.Age.ToString();
                this.txtAddress.Text = detail.Address;
                this.dtpDOB.Value = detail.DOB;
            }
        }

        private bool CheckForm(Form form)
        {
            bool valor = false;
            foreach (Form f in Application.OpenForms)
            {
                if(f.Name == form.Name)
                {
                    valor = true;
                    break;
                }
            }

            return valor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //http://joseluisgarciab.blogspot.com/2013/10/reportviewer-y-rdlc-ejemplo-facturacion.html
            frmReporte frmReporte;
            frmReporte= new frmReporte(context.Details.ToList<Detail>());
            if (!CheckForm(frmReporte))
                frmReporte.Show();
            else
                MessageBox.Show("Ya tiene abierto un reporte");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Ya se esta ejecutando un  mensaje worker");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(3000);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                panel1.Visible = false;
                MessageBox.Show("Se cancelo un mensaje worker");
            }
            else
            {
                MessageBox.Show("No se esta ejecutando un mensaje worker");
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void frmCrudSystem_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
