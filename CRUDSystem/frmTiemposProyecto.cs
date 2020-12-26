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
            this.dataGridView1.DataSource = context.Details.ToList<Detail>();
            this.dataGridView2.DataSource = context.Details.ToList<Detail>();
            this.dataGridView3.DataSource = context.Details.ToList<Detail>();
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
    }
}
