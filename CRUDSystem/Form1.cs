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
    }
}
