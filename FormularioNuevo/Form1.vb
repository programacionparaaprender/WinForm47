Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Office.Interop
Imports Microsoft.VisualBasic


Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        Dim myFileDialog As New OpenFileDialog()
        'Dim xSheet As String = ""

        With myFileDialog
            .Filter = "Excel Files |*.xlsx"
            .Title = "Open File"
            .ShowDialog()
        End With
        If myFileDialog.FileName.ToString <> "" Then
            Dim ExcelFile As String = myFileDialog.FileName.ToString

            Dim ds As New DataSet
            Dim da As OleDbDataAdapter
            Dim dt As DataTable
            Dim conn As OleDbConnection

            conn = New OleDbConnection(
                              "Provider=Microsoft.ACE.OLEDB.12.0;" &
                              "data source=" & ExcelFile & "; " &
                             "Extended Properties='Excel 12.0 Xml;HDR=Yes'")

            Try
                'da = New OleDbDataAdapter("SELECT * FROM  [" & xSheet & "$]", conn)

                Dim part1 As String = "SELECT hoja1.A,hoja1.B,hoja2.E FROM [Hoja1$] As hoja1"
                Dim part2 As String = "inner join [Hoja2$] As hoja2 on hoja1.D=hoja2.D"
                Dim part3 As String = ""
                Dim part As String = part1 + part2
                da = New OleDbDataAdapter(part, conn)
                conn.Open()
                da.Fill(ds, "MyData")
                dt = ds.Tables("MyData")
                Me.dtgwTable.DataSource = ds
                Me.dtgwTable.DataMember = "MyData"
            Catch ex As Exception
                MsgBox("Inserte un nombre valido de la Hoja que desea importar", MsgBoxStyle.Information, "Informacion")
            Finally
                conn.Close()
            End Try
        End If
        'MsgBox("Se ha cargado la importacion correctamente", MsgBoxStyle.Information, "Importado con exito")
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportarExcel.Click
        Dim objConn As OleDbConnection
        Dim oleDA As OleDbDataAdapter
        Dim ds As DataSet

        Dim myFileDialog As New OpenFileDialog()
        'Dim xSheet As String = ""

        With myFileDialog
            .Filter = "Excel Files |*.xlsx"
            .Title = "Open File"
            .ShowDialog()
        End With
        If myFileDialog.FileName.ToString <> "" Then
            Dim FileName As String = myFileDialog.FileName.ToString
            Try
                'Create a OLEDB connection for Excel file 
                Dim connectionString As String = "Provider=Microsoft.ACE.Oledb.12.0;Data Source=" & FileName & ";Extended Properties=""Excel 12.0;HDR=YES;IMEX=1"""
                objConn = New OleDbConnection(connectionString)

                Dim part1 As String = "SELECT hoja1.A,hoja1.B,hoja2.E FROM [Hoja1$] As hoja1"
                Dim part2 As String = " inner join [Hoja2$] As hoja2 on hoja1.D=hoja2.D"
                Dim part3 As String = ""
                Dim part As String = part1 + part2

                oleDA = New OleDbDataAdapter(part, objConn)
                ds = New DataSet()
                'Fill the Data Set 
                oleDA.Fill(ds)
                'Set DataSource of DataGridView 
                Me.dtgwTable.DataSource = ds.Tables(0)
                ds.Dispose()
                oleDA.Dispose()
                objConn.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnGuardarDB_Click(sender As Object, e As EventArgs) Handles btnGuardarDB.Click
        Dim datatable As DataTable = dtgwTable.DataSource

        Try

            'Para la cadena de conexion te guias de este enlace http://www.connectionstrings.com/sql-server-2008
            Using conexion As New SqlConnection("Data Source=INSTANCIA_DE_TU_BD;Initial Catalog=TEST;User ID=TU_USUARIO;Password=TU_PASSWORD")

                'Recorremos el Datagridview
                For Each fila As DataRowView In dtgwTable.Rows


                    'Por ejemplo si tu datagridview posee 3 columnas, tendría la siguiente estructura
                    Dim cmd As New SqlCommand("insert into TUTABLA values(@parametro1,@parametro2,@parametro3)", conexion)
                    'El comando recibe los parametros, Columna 1
                    cmd.Parameters.Add("@parametro1", SqlDbType.VarChar, 20).Value = fila.Item(0).ToString()
                    'El comando recibe los parametros, Columna 2
                    cmd.Parameters.Add("@parametro2", SqlDbType.Int).Value = Convert.ToInt32(fila.Item(1).ToString())
                    'El comando recibe los parametros, Columna 3
                    cmd.Parameters.Add("@parametro3", SqlDbType.DateTime).Value = Convert.ToDateTime(fila.Item(2).ToString())

                    'Abrimos conexion
                    conexion.Open()

                    'Ejecutamos el comando
                    cmd.ExecuteNonQuery()

                    'Cerramos conexion
                    conexion.Close()

                Next

            End Using

        Catch ex As Exception
            'Anunciamos el error
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        llenarExcel(Me.dtgwTable)
    End Sub
    Function llenarExcel(ByVal ElGrid As DataGridView) As Boolean

        'Creamos las variables

        Dim exApp As New Microsoft.Office.Interop.Excel.Application

        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook

        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try

            'Añadimos el Libro al programa, y la hoja al libro

            exLibro = exApp.Workbooks.Add

            exHoja = exLibro.Worksheets.Add()

            ' ¿Cuantas columnas y cuantas filas?

            Dim NCol As Integer = ElGrid.ColumnCount

            Dim NRow As Integer = ElGrid.RowCount

            'Aqui recorremos todas las filas, y por cada fila todas las columnas

            'y vamos escribiendo.

            For i As Integer = 1 To NCol

                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString

            Next

            For Fila As Integer = 0 To NRow - 1

                For Col As Integer = 0 To NCol - 1

                    exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Item(Col, Fila).Value

                Next

            Next

            'Titulo en negrita, Alineado al centro y que el tamaño de la columna

            'se ajuste al texto

            exHoja.Rows.Item(1).Font.Bold = 1

            exHoja.Rows.Item(1).HorizontalAlignment = 3

            exHoja.Columns.AutoFit()

            'Aplicación visible

            exApp.Application.Visible = True

            exHoja = Nothing

            exLibro = Nothing

            exApp = Nothing

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")

            Return False

        End Try

        Return True

    End Function

End Class
