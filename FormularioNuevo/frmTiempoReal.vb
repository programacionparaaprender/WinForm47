Public Class frmTiempoReal
    Private dt As New DataTable
    'Dim d As New SetDataTable(AddressOf AddSource)
    Private Delegate Sub SetDataTable(ByVal dt As DataTable)
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Name", GetType(String))
        dt.Columns.Add("idpadre", GetType(Integer))

        Dim row1 As DataRow = dt.NewRow
        row1.Item("id") = 1
        row1.Item("Name") = "Indocin1"
        row1.Item("idpadre") = 0

        Dim row2 As DataRow = dt.NewRow
        row2.Item("id") = 2
        row2.Item("Name") = "Indocin2"
        row2.Item("idpadre") = 1

        Dim row3 As DataRow = dt.NewRow
        row3.Item("id") = 3
        row3.Item("Name") = "Indocin3"
        row3.Item("idpadre") = 2

        Dim row4 As DataRow = dt.NewRow
        row4.Item("id") = 4
        row4.Item("Name") = "Indocin4"
        row4.Item("idpadre") = 0

        Dim row5 As DataRow = dt.NewRow
        row5.Item("id") = 5
        row5.Item("Name") = "Indocin5"
        row5.Item("idpadre") = 4

        Dim row6 As DataRow = dt.NewRow
        row6.Item("id") = 6
        row6.Item("Name") = "Indocin6"
        row6.Item("idpadre") = 5


        dt.Rows.Add(row1)
        dt.Rows.Add(row2)
        dt.Rows.Add(row3)
        dt.Rows.Add(row4)
        dt.Rows.Add(row5)
        dt.Rows.Add(row6)

        Me.DGV1.DataSource = dt
        Me.DGV2.DataSource = dt
    End Sub

    Private Sub AddSource(ByVal dt As DataTable)
        If (Me.DGV1.InvokeRequired) Then
            Dim d As New SetDataTable(AddressOf AddSource)
            Me.Invoke(d, New Object() {dt})
        Else
            Me.DGV1.DataSource = dt

        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim row As DataRow = dt.NewRow
        Dim contador As Integer
        contador = dt.Rows.Count + 1
        row.Item("id") = contador
        row.Item("Name") = "Indocin" & contador.ToString()
        row.Item("idpadre") = dt.Rows.Count


        dt.Rows.Add(row)
        DGV2.DataSource = dt
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub
End Class