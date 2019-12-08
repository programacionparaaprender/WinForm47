Imports System.Windows.Forms
Public Class frmDialogos
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (Me.CheckForm(frmDialogoPrueba)) Then
            MsgBox("Ya esta abierto el dialogo.")
        Else
            Dim frm As New frmDialogoPrueba
            frm.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (Me.CheckForm(frmDialogoPrueba)) Then
            MsgBox("Ya esta abierto el dialogo.")
        Else
            Dim frm As New frmDialogoPrueba
            frm.Show()
        End If
    End Sub
    Public Function CheckForm(Form1 As Form) As Boolean
        CheckForm = False
        For Each f As Form In Application.OpenForms
            If (f.Name = Form1.Name) Then
                CheckForm = True
                Exit For
            End If
        Next
    End Function
End Class