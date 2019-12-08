Imports System.Windows.Forms
Imports Entidades
Public Class frmTreeView

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim dt As New DataTable
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

        Dim lista As New List(Of Nodo)
        Dim lista2 As New List(Of Nodo)
        Dim lista3 As New List(Of Nodo)

        For Each row As DataRow In dt.Rows
            Dim nodo As New Nodo
            nodo.Id = row.Item("id")
            nodo.Name = row.Item("Name")
            nodo.IdPadre = row.Item("idpadre")
            lista.Add(nodo)
        Next

        lista2 = lista

        For Each Nodo1 As Nodo In lista
            For Each Nodo2 As Nodo In lista2
                If (Nodo1.Id = Nodo2.IdPadre) Then
                    Nodo1.Hijos.Add(Nodo2)
                    Nodo2.Eliminar = True
                End If
            Next
        Next

        For Each nodo1 As Nodo In lista
            If (nodo1.Eliminar = False) Then
                lista3.Add(nodo1)
            End If
        Next

        cargartreeview(lista3)

    End Sub

    Private Sub cargartreeview(ByVal lista As List(Of Nodo), ByVal padre As TreeNode)
        For Each Nodo1 As Nodo In lista
            Dim node As New TreeNode
            node.Tag = Nodo1.Id
            node.Text = Nodo1.Name
            cargartreeview(Nodo1.Hijos, node)
            padre.Nodes.Add(node)
        Next
    End Sub
    Private Sub cargartreeview(ByVal lista As List(Of Nodo))
        For Each Nodo1 As Nodo In lista
            Dim node As New TreeNode
            node.Tag = Nodo1.Id
            node.Text = Nodo1.Name
            cargartreeview(Nodo1.Hijos, node)
            TreeView1.Nodes.Add(node)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class