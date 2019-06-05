using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CRUDSystem
{
    public partial class frmInforme : Form
    {
        private ClaseExcel excel;
        private Util util;
        public frmInforme()
        {
            
            InitializeComponent();
            excel = new ClaseExcel();
            util = new Util();
            List<Arbol> lista = util.añadir();
            foreach (NodoArbol node in util.añadirTreeView())
            {
                treeView1.Nodes.Add(node);
            }

        }

        private void BtnImportar_Click(object sender, EventArgs e)
        {

            var fileContent = string.Empty;
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            //openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                excel.ImportarExcel(filePath, dataGridView1);
                    
                }
            


            //OpenFileDialog openFD = new OpenFileDialog();

            //openFD.Title = "Seleccionar archivos";
            //openFD.Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*";
            //openFD.Multiselect = false;
            ////openFD.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop();
            //    String FileName = openFD.FileName;
            //    if (openFD.ShowDialog() == DialogResult.OK)
            //    {
            //        excel.ImportarExcel(FileName, dataGridView1);
            //    }

        }
    }
}
