Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmReporteNuevo



    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'ReportViewer1
    End Sub

    Private Sub frmReporteNuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SQL As String = "SELECT * from books"
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "NuevoReporte.rdlc"
        Dim ds As DataSetProductos = New DataSetProductos()
        ds = GetData(SQL)
        'Dim dsource As ReportDataSource = New ReportDataSource("DataSetProductos", ds.Tables(0))
        Dim dt As DataTable = Obtener_Tabla("Books")
        Dim dsource As ReportDataSource = New ReportDataSource("DataSetProductos", dt)
        ReportViewer1.LocalReport.DataSources.Add(dsource)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.RefreshReport()
    End Sub
    Private Function GetData(query As String) As DataSetProductos
        Dim cmd As New SqlCommand(query)
        Using con As New SqlConnection("Data Source=localhost;Initial Catalog=QuirkyBookProject;Persist Security Info=True;User ID=sa;Password=123")
            Using sda As New SqlDataAdapter()
                cmd.Connection = con

                sda.SelectCommand = cmd
                Using ds As New DataSetProductos()
                    sda.Fill(ds)
                    Return ds
                End Using
            End Using
        End Using
    End Function
    Private Function Obtener_Tabla(ByVal Name_tabla As String) As DataTable
        Try
            Dim dt As New DataTable
            Using cn As New SqlConnection()
                cn.ConnectionString = "Data Source=(local)\SQLEXPRESS;" &
                                      "Integrated Security=True;" &
                                      "Initial Catalog=QuirkyBookProject"
                cn.Open()
                Dim comando As New SqlCommand()
                comando.Connection = cn
                comando.CommandText = "SELECT * FROM " & "[" & Name_tabla & "]"
                dt.Load(comando.ExecuteReader())
                Return dt
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        Return Nothing
    End Function
    Private Function Obtener_Esquema_Tabla(ByVal Name_tabla As String) As ArrayList

        Try

            'Crear nueva conexión  
            Using cn As New SqlConnection()

                'Asignar la Cadena de conexión para la base SQL Server.  
                cn.ConnectionString = "Data Source=(local)\SQLEXPRESS;" &
                                      "Integrated Security=True;" &
                                      "Initial Catalog=QuirkyBookProject"

                ' abrir la conexión  
                cn.Open()

                ' Nuevo comando  
                Dim comando As New SqlCommand()

                ' Asignar la conexión al comand y la consulta sql  
                comando.Connection = cn
                comando.CommandText = "SELECT * FROM " & "[" & Name_tabla & "]"

                ' Inicializar y ejecutar el DataReader  
                Using SqlDataReader As SqlDataReader = comando.ExecuteReader()

                    'Recuperar el esquema de columna en un DataTable.  

                    Dim esquema As DataTable = SqlDataReader.GetSchemaTable()

                    Dim arrtemp As New ArrayList

                    'Recorrer los campos de la tabla  
                    For Each campo As DataRow In esquema.Rows

                        ' Agregar el nombre de la columna  

                        arrtemp.Add("Columna: " & campo(0).ToString())
                        arrtemp.Add("-------------------------------")

                        'Obtener las propiedades de cada campo  
                        For Each propiedad As DataColumn In esquema.Columns
                            'Mostrar el nombre y el valor del campo.  
                            arrtemp.Add("    " & propiedad.ColumnName & " = " &
                                                       campo(propiedad).ToString)
                        Next
                        arrtemp.Add("")
                    Next
                    ' retorna la colección con los datos  
                    Return arrtemp
                End Using
            End Using

            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        Return Nothing
    End Function
End Class