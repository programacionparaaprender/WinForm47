Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Configuration
Imports System.Data.OracleClient


Public Class frmDataGridViewOracle
    Private conexionString As String = ConfigurationManager.ConnectionStrings("DBConnectionOracle").ConnectionString()
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Public Sub Nuevo_Load() Handles Me.Load
        Dim conexion As New OracleConnection(conexionString)
        conexion.Open()
        MsgBox("Conectado oracle")
    End Sub
End Class