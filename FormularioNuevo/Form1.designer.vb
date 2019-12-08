Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnImportarExcel = New System.Windows.Forms.Button()
        Me.lNombre = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.dtgwTable = New System.Windows.Forms.DataGridView()
        Me.btnGuardarDB = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dtgwTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnImportarExcel
        '
        Me.btnImportarExcel.Location = New System.Drawing.Point(12, 12)
        Me.btnImportarExcel.Name = "btnImportarExcel"
        Me.btnImportarExcel.Size = New System.Drawing.Size(148, 22)
        Me.btnImportarExcel.TabIndex = 0
        Me.btnImportarExcel.Text = "Importar Excel"
        Me.btnImportarExcel.UseVisualStyleBackColor = True
        '
        'lNombre
        '
        Me.lNombre.AutoSize = True
        Me.lNombre.Location = New System.Drawing.Point(182, 20)
        Me.lNombre.Name = "lNombre"
        Me.lNombre.Size = New System.Drawing.Size(73, 13)
        Me.lNombre.TabIndex = 1
        Me.lNombre.Text = "Nombre Excel"
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Location = New System.Drawing.Point(12, 61)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(148, 22)
        Me.btnExportarExcel.TabIndex = 2
        Me.btnExportarExcel.Text = "Exportar Excel"
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(172, 61)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(100, 20)
        Me.txtName.TabIndex = 3
        '
        'dtgwTable
        '
        Me.dtgwTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgwTable.Location = New System.Drawing.Point(12, 89)
        Me.dtgwTable.Name = "dtgwTable"
        Me.dtgwTable.Size = New System.Drawing.Size(346, 143)
        Me.dtgwTable.TabIndex = 4
        '
        'btnGuardarDB
        '
        Me.btnGuardarDB.Location = New System.Drawing.Point(12, 269)
        Me.btnGuardarDB.Name = "btnGuardarDB"
        Me.btnGuardarDB.Size = New System.Drawing.Size(129, 23)
        Me.btnGuardarDB.TabIndex = 5
        Me.btnGuardarDB.Text = "Guardar en BD"
        Me.btnGuardarDB.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 240)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Generar Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 316)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnGuardarDB)
        Me.Controls.Add(Me.dtgwTable)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.btnExportarExcel)
        Me.Controls.Add(Me.lNombre)
        Me.Controls.Add(Me.btnImportarExcel)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dtgwTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnImportarExcel As Button
    Friend WithEvents lNombre As Label
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents txtName As TextBox
    Friend WithEvents dtgwTable As DataGridView
    Friend WithEvents btnGuardarDB As Button
    Friend WithEvents Button1 As Button
End Class
