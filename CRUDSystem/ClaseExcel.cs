
using System.Data.OleDb;
using System.IO;
using Microsoft.Office.Interop;

namespace CRUDSystem
{
public class ClaseExcel
{

    public void ImportExcellToDataGridView(ref string path, DataGridView Datagrid)
    {
        try
        {
            string stConexion = ("Provider=Microsoft.ACE.OLEDB.12.0;" + ("Data Source=" + (path + ";Extended Properties=\"Excel 12.0;Xml;HDR=YES;IMEX=2\";")));
            OleDbConnection cnConex = new OleDbConnection(stConexion);
            OleDbCommand Cmd = new OleDbCommand("Select * From [ABRIL 2019$]");
            DataSet Ds = new DataSet();
            OleDbDataAdapter Da = new OleDbDataAdapter();
            DataTable Dt = new DataTable();
            cnConex.Open();
            Cmd.Connection = cnConex;
            Da.SelectCommand = Cmd;
            Da.Fill(Ds);
            Dt = Ds.Tables(0);
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

            List<EntidadSIS> lista = new List<EntidadSIS>();
            for (int index = 0; index <= Dt.Rows.Count - 1; index++)
            {
                if ((index > 9 & index < 403))
                {
                    EntidadSIS lis = new EntidadSIS();
                    lis.N = Dt.Rows(index).Item("F3").ToString;
                    lis.Directivo = Dt.Rows(index).Item("F4").ToString;
                    lis.Dni = Dt.Rows(index).Item("F5").ToString;
                    lis.ApyNom = Dt.Rows(index).Item("F6").ToString;
                    lis.Cargo = Dt.Rows(index).Item("F7").ToString;
                    lis.Costos = Dt.Rows(index).Item("F8").ToString;
                    lista.Add(lis);

                    DataRow dtrow = dt2.NewRow;
                    dtrow.Item(0) = Dt.Rows(index).Item("F3").ToString;
                    dtrow.Item(1) = Dt.Rows(index).Item("F4").ToString;
                    dtrow.Item(2) = Dt.Rows(index).Item("F5").ToString;
                    dtrow.Item(3) = Dt.Rows(index).Item("F6").ToString;
                    dtrow.Item(4) = Dt.Rows(index).Item("F7").ToString;
                    dtrow.Item(5) = Dt.Rows(index).Item("F8").ToString;
                    dt2.Rows.Add(dtrow);
                }
            }
            // Me.DataGridView2.DataSource = lista
            this.DataGridView2.DataSource = dt2;
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Error");
        }
        return true;
    }

    private void btnCargar()
    {
        OpenFileDialog openFD = new OpenFileDialog();
        {
            var withBlock = openFD;
            withBlock.Title = "Seleccionar archivos";
            withBlock.Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*";
            withBlock.Multiselect = false;
            withBlock.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop;
            if (withBlock.ShowDialog == Windows.Forms.DialogResult.OK)
                ImportExcellToDataGridView(ref withBlock.FileName, DataGridView1);
        }
    }


    public void LlenarCliente(string path, DataGridView DataGridView2)
{
    string cadena = ("Provider=Microsoft.ACE.OLEDB.12.0;" + ("Data Source=" + (path + ";Extended Properties=\"Excel 12.0;Xml;HDR=YES;IMEX=2\";")));



    Microsoft.Office.Interop.Excel.Application xlibro;
    xlibro = Interaction.CreateObject("Excel.Application");
    xlibro.Workbooks.Open(path);
    // xlibro.Visible = True
    xlibro.Sheets("ABRIL 2019").Select();


    
    DataTable dt = new DataTable();
    dt = (DataTable)this.DataGridView2.DataSource;

    
    int RANGO = 12;

    Excel.Range Range;

    int index2 = 1;
    foreach (DataRow row in dt.Rows) 
    {
        xlibro.Range("D" + (RANGO + 1).ToString()).Select();
            Range = xlibro.Range("D" + (RANGO + 1).ToString()).EntireRow;
            Range.Insert(Excel.XlInsertShiftDirection.xlShiftDown, System.Type.Missing);


            xlibro.Range("C" + RANGO.ToString()).Value = index2.ToString();
            xlibro.Range("D" + RANGO.ToString()).Value = row("N").ToString;
            RANGO += 1;
            index2 = index2 + 1;

            
        
    }

    xlibro.Visible = true;
}


    public void btnGuardar()
    {
        OpenFileDialog openFD = new OpenFileDialog();
        {
            var withBlock = openFD;
            withBlock.Title = "Seleccionar archivos";
            withBlock.Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*";
            withBlock.Multiselect = false;
            withBlock.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop;
            if (withBlock.ShowDialog == Windows.Forms.DialogResult.OK)
                LlenarCliente(withBlock.FileName, this.DataGridView2);
        }
    }
}
}