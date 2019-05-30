
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

namespace CRUDSystem
{
public class ClaseExcel
{

        public void ImportarExcel(string path, DataGridView Datagrid)
        {
            try
            {
                string stConexion = ("Provider=Microsoft.ACE.OLEDB.12.0;" + ("Data Source=" + (path + ";Extended Properties=\"Excel 12.0;Xml;HDR=YES;IMEX=2\";")));
                OleDbConnection cnConex = new OleDbConnection(stConexion);
                OleDbCommand Cmd = new OleDbCommand("Select * From [Hoja1$]");
                DataSet Ds = new DataSet();
                OleDbDataAdapter Da = new OleDbDataAdapter();
                DataTable Dt = new DataTable();
                cnConex.Open();
                Cmd.Connection = cnConex;
                Da.SelectCommand = Cmd;
                Da.Fill(Ds);
                Dt = Ds.Tables[0];
                Datagrid.Columns.Clear();
                Datagrid.DataSource = Dt;
                
            }
            catch (Exception ex)
            {
                //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Error");
            }
            //return true;
        }

        public void ImportExcellToDataGridView(string path, DataGridView Datagrid)
    {
        try
        {
            string stConexion = ("Provider=Microsoft.ACE.OLEDB.12.0;" + ("Data Source=" + (path + ";Extended Properties=\"Excel 12.0;Xml;HDR=YES;IMEX=2\";")));
            OleDbConnection cnConex = new OleDbConnection(stConexion);
            OleDbCommand Cmd = new OleDbCommand("Select * From [Hoja1$]");
            DataSet Ds = new DataSet();
            OleDbDataAdapter Da = new OleDbDataAdapter();
            DataTable Dt = new DataTable();
            cnConex.Open();
            Cmd.Connection = cnConex;
            Da.SelectCommand = Cmd;
            Da.Fill(Ds);
            Dt = Ds.Tables[0];
            Datagrid.Columns.Clear();
            Datagrid.DataSource = Dt;

            DataTable dt2 = new DataTable();
            DataColumn N = new DataColumn("N", Type.GetType("System.String"));
            DataColumn Directivo = new DataColumn("CAS/ CAP/    DIRECTIVO", Type.GetType("System.String"));
            DataColumn Dni = new DataColumn("Dni", Type.GetType("System.String"));
            DataColumn ApyNom = new DataColumn("Apellidos y Nombres", Type.GetType("System.String"));
            DataColumn Cargo = new DataColumn("Cargo", Type.GetType("System.String"));
            DataColumn Costos = new DataColumn("Centro de Costo", Type.GetType("System.String"));

            dt2.Columns.Add(N);
            dt2.Columns.Add(Directivo);
            dt2.Columns.Add(Dni);
            dt2.Columns.Add(ApyNom);
            dt2.Columns.Add(Cargo);
            dt2.Columns.Add(Costos);

            List<Entidad> lista = new List<Entidad>();
            for (int index = 0; index <= Dt.Rows.Count - 1; index++)
            {
                    DataRow row = Dt.Rows[index];
                if (index > 9 && index < 403)
                {
                    Entidad lis = new Entidad();
                        lis.N = row["F3"].ToString; //Dt.Rows[index].Item["F3"].ToString();
                    lis.Directivo = row["F4"].ToString;//Dt.Rows[index].Item("F4").ToString;
                        lis.Dni = row["F5"].ToString;//Dt.Rows[index].Item("F5").ToString;
                        lis.ApyNom = row["F6"].ToString;//Dt.Rows[index].Item("F6").ToString;
                        lis.Cargo = row["F7"].ToString;//Dt.Rows[index].Item("F7").ToString;
                        lis.Costos = row["F8"].ToString;//Dt.Rows[index].Item("F8").ToString;
                        lista.Add(lis);

                    DataRow dtrow = dt2.NewRow();
                    dtrow[0] = row["F3"];//Dt.Rows(index).Item("F3").ToString;
                        dtrow[1] = row["F4"];//Dt.Rows(index).Item("F4").ToString;
                        dtrow[2] = row["F5"];//Dt.Rows(index).Item("F5").ToString;
                        dtrow[3] = row["F6"];//Dt.Rows(index).Item("F6").ToString;
                        dtrow[4] = row["F7"];//Dt.Rows(index).Item("F7").ToString;
                        dtrow[5] = row["F8"];//Dt.Rows(index).Item("F8").ToString;
                        dt2.Rows.Add(dtrow);
                }
            }
            // Me.DataGridView2.DataSource = lista
            Datagrid.DataSource = dt2;
        }
        catch (Exception ex)
        {
            //Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Error");
        }
        //return true;
    }

    


    public void LlenarCliente(string path, DataGridView DataGridView2)
    {
    string cadena = ("Provider=Microsoft.ACE.OLEDB.12.0;" + ("Data Source=" + (path + ";Extended Properties=\"Excel 12.0;Xml;HDR=YES;IMEX=2\";")));

            Microsoft.Office.Interop.Excel.Application xlibro;

            //Microsoft.Office.Interop.Excel.Application xlibro;
            xlibro = new Microsoft.Office.Interop.Excel.Application();
            
            //xlibro = Microsoft.Office.Interop.Excel.Application.CreateObject("Excel.Application");

            xlibro.Workbooks.Open(path);
    // xlibro.Visible = True
    xlibro.Sheets["ABRIL 2019"].Select();


    
    DataTable dt = new DataTable();
    dt = (DataTable)DataGridView2.DataSource;

    
    int RANGO = 12;

            Microsoft.Office.Interop.Excel.Range Range;

    int index2 = 1;
    foreach (DataRow row in dt.Rows) 
    {
        xlibro.Range["D" + (RANGO + 1).ToString()].Select();
            Range = xlibro.Range["D" + (RANGO + 1).ToString()].EntireRow;
            Range.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, System.Type.Missing);


            xlibro.Range["C" + RANGO.ToString()].Value = index2.ToString();
            xlibro.Range["D" + RANGO.ToString()].Value = row["N"];
            RANGO += 1;
            index2 = index2 + 1;

            
        
    }

    xlibro.Visible = true;
}


    public void btnGuardar(DataGridView DataGridView2)
    {
        OpenFileDialog openFD = new OpenFileDialog();
        
            openFD.Title = "Seleccionar archivos";
            openFD.Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*";
            openFD.Multiselect = false;
            //withBlock.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop;
                string FileName = openFD.FileName;
                if (openFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LlenarCliente(FileName, DataGridView2);
                }
        
    }
}
}