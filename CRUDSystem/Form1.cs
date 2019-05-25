using CRUDSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDSystem
{
    public partial class Form1 : Form
    {
        private MyDBContext context;

        public Form1()
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
                for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                    {
                        hoja_trabajo.Cells[i + 1, j + 1] = this.dataGridView1.Rows[i].Cells[j].Value.ToString();
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
    }
}
