Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks


Public Class oArbol
    Private _text As String
    Private _id As Integer
    Private _children As List(Of oArbol)
    Private _eliminar As Boolean
    Public Sub New(ByVal text As String, ByVal id As Integer)
            Me.Text = text
        Me.Id = id
        Me.Eliminar = False
        Children = New List(Of oArbol)()
    End Sub

    Public Property Text As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property Children As List(Of oArbol)
        Get
            Return _children
        End Get
        Set(ByVal value As List(Of oArbol))
            _children = value
        End Set
    End Property

    Public Property Eliminar As Boolean
        Get
            Return _eliminar
        End Get
        Set(value As Boolean)
            _eliminar = value
        End Set
    End Property

    Public Function añadir(ByVal nombre_hijo As String, ByVal id_hijo As Integer, ByVal id_padre As Integer) As Boolean
        If Id = id_padre Then
            Dim hijo = New oArbol(nombre_hijo, id_hijo)
            Me.Children.Add(hijo)
            Console.WriteLine(Convert.ToString(nombre_hijo) & Convert.ToInt32(id_hijo) & " padre: " & Convert.ToString(id_padre))
            Return True
        Else

            For Each hijo As oArbol In Me.Children

                If hijo.añadir(nombre_hijo, id_hijo, id_padre) = True Then
                    Return True
                End If
            Next
        End If

        Return False
    End Function
End Class

