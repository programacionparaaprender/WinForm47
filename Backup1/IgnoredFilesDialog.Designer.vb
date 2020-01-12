<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class IgnoredFilesDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IgnoredFilesDialog))
        Me.Label1 = New System.Windows.Forms.Label
        Me.extensionsTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.OkButton = New System.Windows.Forms.Button
        Me.MyCancelButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'extensionsTextBox
        '
        resources.ApplyResources(Me.extensionsTextBox, "extensionsTextBox")
        Me.extensionsTextBox.Name = "extensionsTextBox"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'OkButton
        '
        resources.ApplyResources(Me.OkButton, "OkButton")
        Me.OkButton.Name = "OkButton"
        '
        'MyCancelButton
        '
        resources.ApplyResources(Me.MyCancelButton, "MyCancelButton")
        Me.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.MyCancelButton.Name = "MyCancelButton"
        '
        'IgnoredFilesDialog
        '
        Me.AcceptButton = Me.OkButton
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.MyCancelButton
        Me.Controls.Add(Me.MyCancelButton)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.extensionsTextBox)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IgnoredFilesDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents extensionsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents MyCancelButton As System.Windows.Forms.Button
End Class
