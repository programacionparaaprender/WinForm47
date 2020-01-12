Imports System.IO
Imports Microsoft.Reporting.WinForms

Public Class MainForm
    ' Application name to display in message boxes.
    Private m_appName As String = My.Application.Info.ProductName
    ' Default list of file name extensions to ignore.
    Private m_ignoredExtensions As String() = {".gif", ".jpg", ".png", ".dll", ".js", ".css"}
    ' A collection of LogFileEntry objects, to use as data for the report.
    Private m_logFileEntries As LogFileEntryCollection
    ' Path to folder containing log files.
    Private m_logFolderPath As String

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Default location of log files
        Dim defaultDir As String = Environment.SystemDirectory + Path.DirectorySeparatorChar + _
                                   "Logfiles" + Path.DirectorySeparatorChar + "W3SVC1"
        ' If the default location exists then use it as the default in the folder browser dialog.
        If Directory.Exists(defaultDir) Then
            m_logFolderPath = defaultDir
        Else
            m_logFolderPath = ""
        End If
        Try
            Me.Cursor = Cursors.WaitCursor
            ' Parse the sample log file to use as default data for the report.
            Me.m_logFileEntries = LogParser.ParseLogFile("sample.log", m_ignoredExtensions)
            Me.LogFileEntryBindingSource.DataSource = m_logFileEntries
            ' Process and render the report.
            Me.ReportViewer.RefreshReport()
        Catch ex As IOException
            ' There is no harm if the sample log file cannot be loaded, so ignore the exception.
        Catch ex As LogParserException
            MessageBox.Show(ex.Message, m_appName)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

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
    Private Sub OpenLogFilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenLogFilesToolStripMenuItem.Click
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
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Handler for View > Ignore Files menu command.
    ''' </summary>
    Private Sub IgnoreFilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IgnoreFilesToolStripMenuItem.Click
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
    Private Sub DocumentMapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentMapToolStripMenuItem.Click
        Me.ReportViewer.DocumentMapCollapsed = Not Me.ReportViewer.DocumentMapCollapsed
    End Sub

    ''' <summary>
    ''' Handler for View menu Drop Down Opened event.
    ''' </summary>
    Private Sub ViewToolStripMenuItem_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewToolStripMenuItem.DropDownOpened
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
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        My.Forms.AboutDialog.ShowDialog()
    End Sub
End Class
