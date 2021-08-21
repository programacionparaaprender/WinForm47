Public Class wfrmModalPopup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub OnSelectedIndexChanged(sender As Object, e As EventArgs)
        Dim message As String = "Selected Item: " & DropDownList1.SelectedItem.Text
        ScriptManager.RegisterClientScriptBlock(TryCast(sender, Control), Me.GetType(), "alert", "alert('" & message & "');", True)
    End Sub

End Class