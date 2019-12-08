<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTiempoReal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DGV1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdPadre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.DGV2 = New System.Windows.Forms.DataGridView()
        Me.Id2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Name2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdPadre2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Name, Me.IdPadre})
        Me.DGV1.Location = New System.Drawing.Point(12, 20)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.Size = New System.Drawing.Size(240, 150)
        Me.DGV1.TabIndex = 0
        '
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        '
        'Name
        '
        Me.Name.DataPropertyName = "Name"
        Me.Name.HeaderText = "Name"
        Me.Name.Name = "Name"
        '
        'IdPadre
        '
        Me.IdPadre.DataPropertyName = "IdPadre"
        Me.IdPadre.HeaderText = "IdPadre"
        Me.IdPadre.Name = "IdPadre"
        '
        'BackgroundWorker1
        '
        '
        'Button1
        '
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(267, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 38)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "+"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(590, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(43, 38)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "+"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(267, 78)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(43, 38)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "-"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(590, 78)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(43, 38)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "-"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'DGV2
        '
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id2, Me.Name2, Me.IdPadre2})
        Me.DGV2.Location = New System.Drawing.Point(327, 20)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.Size = New System.Drawing.Size(240, 150)
        Me.DGV2.TabIndex = 6
        '
        'Id2
        '
        Me.Id2.DataPropertyName = "Id"
        Me.Id2.HeaderText = "Id"
        Me.Id2.Name = "Id2"
        '
        'Name2
        '
        Me.Name2.DataPropertyName = "Name"
        Me.Name2.HeaderText = "Name"
        Me.Name2.Name = "Name2"
        '
        'IdPadre2
        '
        Me.IdPadre2.DataPropertyName = "IdPadre"
        Me.IdPadre2.HeaderText = "IdPadre"
        Me.IdPadre2.Name = "IdPadre2"
        '
        'frmTiempoReal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 450)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DGV1)
        'Me.Name = "frmTiempoReal"
        Me.Text = "FORMULARIO TIEMPO REAL"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGV1 As Windows.Forms.DataGridView
    Friend WithEvents BackgroundWorker1 As ComponentModel.BackgroundWorker
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents Button4 As Windows.Forms.Button
    Friend WithEvents Id As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Name As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdPadre As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGV2 As Windows.Forms.DataGridView
    Friend WithEvents Id2 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Name2 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdPadre2 As Windows.Forms.DataGridViewTextBoxColumn
End Class
