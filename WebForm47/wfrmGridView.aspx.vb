Public Class wfrmGridView
    Inherits System.Web.UI.Page

    Public Sub New()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Dim dc As DataColumn
        dc = New DataColumn("Check", Type.GetType("System.Boolean"))
        dt.Columns.Add(dc)

        dc = New DataColumn("Editar", Type.GetType("System.String"))
        dt.Columns.Add(dc)

        dc = New DataColumn("Valor1", Type.GetType("System.String"))
        dt.Columns.Add(dc)
        dc = New DataColumn("Valor2", Type.GetType("System.String"))
        dt.Columns.Add(dc)

        For i As Integer = 0 To 20
            Dim dtRow As DataRow = dt.NewRow
            dtRow.Item("Check") = False
            dtRow.Item("Editar") = "Editar" & i.ToString()
            dtRow.Item("Valor1") = "Valor1: " & i.ToString()
            dtRow.Item("Valor2") = "Valor2: " & i.ToString()
            dt.Rows.Add(dtRow)
        Next

        Me.GridView1.AutoGenerateColumns = False
        Me.GridView1.DataSource = dt
        Me.GridView1.DataBind()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName = "cmdEdit") Then
            Dim Index As Integer = Convert.ToInt32(e.CommandArgument)

            '// Retrieve the row that contains the button clicked 
            '// by the user from the Rows collection.
            Dim row = GridView1.Rows(Index)
            'Response.Redirect(e.CommandArgument.ToString())
            Server.Transfer("WebVueJS.aspx")

        End If
    End Sub
End Class