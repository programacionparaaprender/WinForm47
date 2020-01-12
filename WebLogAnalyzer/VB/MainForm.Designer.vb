<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.LogFileEntryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenLogFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DocumentMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IgnoreFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        CType(Me.LogFileEntryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LogFileEntryBindingSource
        '
        Me.LogFileEntryBindingSource.DataSource = GetType(WebLogAnalyzer.LogFileEntry)
        '
        'ReportViewer
        '
        resources.ApplyResources(Me.ReportViewer, "ReportViewer")
        Me.ReportViewer.AllowDrop = True
        Me.ReportViewer.BackgroundImage = Global.WebLogAnalyzer.My.Resources.Resources.background
        Me.ReportViewer.DocumentMapCollapsed = True
        ReportDataSource1.Name = "WebLogAnalyzer_LogFileEntry"
        ReportDataSource1.Value = Me.LogFileEntryBindingSource
        Me.ReportViewer.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer.LocalReport.DisplayName = "Web Log Analysis"
        Me.ReportViewer.LocalReport.ReportEmbeddedResource = "WebLogAnalyzer.MainReport.rdlc"
        Me.ReportViewer.Name = "ReportViewer"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.HelpToolStripMenuItem})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenLogFilesToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        resources.ApplyResources(Me.FileToolStripMenuItem, "FileToolStripMenuItem")
        '
        'OpenLogFilesToolStripMenuItem
        '
        Me.OpenLogFilesToolStripMenuItem.Name = "OpenLogFilesToolStripMenuItem"
        resources.ApplyResources(Me.OpenLogFilesToolStripMenuItem, "OpenLogFilesToolStripMenuItem")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        resources.ApplyResources(Me.ExitToolStripMenuItem, "ExitToolStripMenuItem")
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DocumentMapToolStripMenuItem, Me.IgnoreFilesToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        resources.ApplyResources(Me.ViewToolStripMenuItem, "ViewToolStripMenuItem")
        '
        'DocumentMapToolStripMenuItem
        '
        Me.DocumentMapToolStripMenuItem.Name = "DocumentMapToolStripMenuItem"
        resources.ApplyResources(Me.DocumentMapToolStripMenuItem, "DocumentMapToolStripMenuItem")
        '
        'IgnoreFilesToolStripMenuItem
        '
        Me.IgnoreFilesToolStripMenuItem.Name = "IgnoreFilesToolStripMenuItem"
        resources.ApplyResources(Me.IgnoreFilesToolStripMenuItem, "IgnoreFilesToolStripMenuItem")
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        resources.ApplyResources(Me.HelpToolStripMenuItem, "HelpToolStripMenuItem")
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        resources.ApplyResources(Me.AboutToolStripMenuItem, "AboutToolStripMenuItem")
        '
        'FolderBrowserDialog
        '
        resources.ApplyResources(Me.FolderBrowserDialog, "FolderBrowserDialog")
        '
        'MainForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReportViewer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        CType(Me.LogFileEntryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenLogFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents DocumentMapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IgnoreFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogFileEntryBindingSource As System.Windows.Forms.BindingSource

End Class
