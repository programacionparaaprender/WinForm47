Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Reporting.WinForms

Public Class frmReporteNuevo2
    ' Application name to display in message boxes.
    Private m_appName As String = My.Application.Info.ProductName
    ' Default list of file name extensions to ignore.
    Private m_ignoredExtensions As String() = {".gif", ".jpg", ".png", ".dll", ".js", ".css"}
    ' A collection of LogFileEntry objects, to use as data for the report.
    Private m_logFileEntries As LogFileEntryCollection
    ' Path to folder containing log files.
    Private m_logFolderPath As String

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQL As String = "SELECT * from books"
        ReportViewer.ProcessingMode = ProcessingMode.Local
        ReportViewer.LocalReport.ReportPath = "NuevoReporte.rdlc"
        Dim ds As DataSetProductos = New DataSetProductos()
        ds = GetData(SQL)
        'Dim dsource As ReportDataSource = New ReportDataSource("DataSetProductos", ds.Tables(0))
        Dim dt As DataTable = Obtener_Tabla("Books")
        Dim dsource As ReportDataSource = New ReportDataSource("DataSetProductos", dt)
        ReportViewer.LocalReport.DataSources.Add(dsource)
        ReportViewer.LocalReport.Refresh()
        ReportViewer.RefreshReport()
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

    ''' <summary>
    ''' The drillthrough event handler.
    ''' </summary>
    ''' <remarks>This method supplies data for the drillthrough report.</remarks>
    Private Sub ReportViewer_Drillthrough(ByVal sender As Object, ByVal e As DrillthroughEventArgs) Handles ReportViewer.Drillthrough
        Dim report As LocalReport = e.Report
        report.DataSources.Add(New ReportDataSource("WebLogAnalyzer_LogFileEntry", Me.m_logFileEntries))
    End Sub

    ''' <summary>
    ''' Handler for Open Log Files menu command.
    ''' </summary>
    Private Sub OpenLogFilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Display the folder browser dialog.
        Me.FolderBrowserDialog.SelectedPath = Me.m_logFolderPath
        If (Me.FolderBrowserDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
            Try
                Me.m_logFolderPath = Me.FolderBrowserDialog.SelectedPath
                Me.Cursor = Cursors.WaitCursor
                ' Parse all log files in the selected folder.
                Me.m_logFileEntries = LogParser.ParseLogFileFolder(Me.m_logFolderPath, m_ignoredExtensions)
                Me.LogFileEntryBindingSource.DataSource = Me.m_logFileEntries
                ' Reinitialize the ReportViewer control with the new data.
                Me.ReportViewer.Reset()
                Me.ReportViewer.LocalReport.DisplayName = My.Resources.ReportDisplayName
                Me.ReportViewer.LocalReport.ReportEmbeddedResource = "WebLogAnalyzer.MainReport.rdlc"
                Me.ReportViewer.LocalReport.DataSources.Add(New ReportDataSource("WebLogAnalyzer_LogFileEntry", Me.LogFileEntryBindingSource))
                Me.ReportViewer.RefreshReport()
            Catch ex As IOException
                MessageBox.Show(ex.Message, m_appName)
            Catch ex As LogParserException
                MessageBox.Show(ex.Message, m_appName)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Handler for File > Exit menu command.
    ''' </summary>
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    ''' <summary>
    ''' Handler for View > Ignore Files menu command.
    ''' </summary>
    Private Sub IgnoreFilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dialog As New IgnoredFilesDialog()
        dialog.SetIgnoredExtensions(Me.m_ignoredExtensions)
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim extensions(dialog.IgnoredExtensions.Count) As String
            dialog.IgnoredExtensions.CopyTo(extensions, 0)
            Me.m_ignoredExtensions = extensions
        End If
    End Sub

    ''' <summary>
    ''' Handler for Show Document Map menu command.
    ''' </summary>
    Private Sub DocumentMapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.ReportViewer.DocumentMapCollapsed = Not Me.ReportViewer.DocumentMapCollapsed
    End Sub

    ''' <summary>
    ''' Handler for View menu Drop Down Opened event.
    ''' </summary>
    Private Sub ViewToolStripMenuItem_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.ReportViewer.LocalReport.GetDocumentMap() Is Nothing Then
            Me.DocumentMapToolStripMenuItem.Enabled = False
            Me.DocumentMapToolStripMenuItem.Checked = False
        Else
            Me.DocumentMapToolStripMenuItem.Enabled = True
            Me.DocumentMapToolStripMenuItem.Checked = Not Me.ReportViewer.DocumentMapCollapsed
        End If
    End Sub

    ''' <summary>
    ''' Handler for Help > About menu command.
    ''' </summary>
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Forms.AboutDialog.ShowDialog()
    End Sub
End Class
