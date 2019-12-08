Imports Entidades

Public Class Nodo
    Private _id As Integer
    Private _Name As String
    Private _idPadre As Integer
    Private _hijos As New List(Of Nodo)
    Private _eliminar As Boolean = False
#Region "Métodos"

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property

    Public Property IdPadre As Integer
        Get
            Return _idPadre
        End Get
        Set(value As Integer)
            _idPadre = value
        End Set
    End Property

    Public Property Hijos As List(Of Nodo)
        Get
            Return _hijos
        End Get
        Set(value As List(Of Nodo))
            _hijos = value
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
#End Region

End Class
