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
    public partial class frmTiemposProyecto : Form
    {
        private DataView dataview1;
        private DataView dataview2;
        private DataView dataview3;
        private DataView dataview4;
        private MyDBContext context;

        public frmTiemposProyecto()
        {
            InitializeComponent();
            context = new MyDBContext();
            this.dataGridView1.DataSource = context.Tablas.ToList<Tabla>();
            this.dataGridView2.DataSource = context.Procedimientos.ToList<Procedimiento>();
            //this.dataGridView3.DataSource = context.TablaProcedimientos.ToList<TablaProcedimiento>();
            this.dataGridView4.DataSource = context.Details.ToList<Detail>();
        }
   

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Debe colocar un procedimiento");
            }
            else
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var tabla = new Tabla
            {
                Name = this.txtfName.Text
            };

            context.Tablas.Add(tabla);
            context.SaveChanges();

            this.dataGridView1.DataSource = context.Tablas.ToList<Tabla>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var procedimiento = new Procedimiento
            {
                Name = this.textBox1.Text
            };
            context.Procedimientos.Add(procedimiento);
            context.SaveChanges();

            this.dataGridView2.DataSource = context.Procedimientos.ToList<Procedimiento>();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int NumeroDeFilaSeleccionada1 = 0;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    NumeroDeFilaSeleccionada1 = dataGridView1.CurrentRow.Index;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una tabla");
                    return;
                }

                int NumeroDeFilaSeleccionada2 = 0;

                if (dataGridView2.SelectedRows.Count > 0)
                {
                    NumeroDeFilaSeleccionada2 = dataGridView2.CurrentRow.Index;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un procedimiento");
                    return;
                }

                int id1;
                id1 = Convert.ToInt32(this.dataGridView1.Rows[NumeroDeFilaSeleccionada1].Cells[0].Value.ToString());
                int id2;
                id2 = Convert.ToInt32(this.dataGridView2.Rows[NumeroDeFilaSeleccionada2].Cells[0].Value.ToString());

                var tablaprocedimiento = new TablaProcedimiento
                {
                    TablaId = id1,
                    ProcedimientoId = id2
                };
                context.TablaProcedimientos.Add(tablaprocedimiento);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //this.dataGridView3.DataSource = context.TablaProcedimientos.ToList<TablaProcedimiento>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int NumeroDeFilaSeleccionada1 = 0;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                NumeroDeFilaSeleccionada1 = dataGridView1.CurrentRow.Index;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una tabla");
                return;
            }

            int NumeroDeFilaSeleccionada2 = 0;

            if (dataGridView2.SelectedRows.Count > 0)
            {
                NumeroDeFilaSeleccionada2 = dataGridView2.CurrentRow.Index;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un procedimiento");
                return;
            }

            int id1;
            id1 = Convert.ToInt32(this.dataGridView1.Rows[NumeroDeFilaSeleccionada1].Cells[0].Value.ToString());
            int id2;
            id2 = Convert.ToInt32(this.dataGridView2.Rows[NumeroDeFilaSeleccionada2].Cells[0].Value.ToString());

            TablaProcedimiento tablaprocedimiento = new TablaProcedimiento
            {
                TablaId = id1,
                ProcedimientoId = id2
            };
            context.TablaProcedimientos.Remove(tablaprocedimiento);
            context.SaveChanges();
            
        }
    }
}
