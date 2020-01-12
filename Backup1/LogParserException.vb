Imports System.Runtime.Serialization

''' <summary>
''' The exception that is thrown when the log parser encounters a problem.
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Class LogParserException
    Inherits Exception
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
    Public Sub New(ByVal message As String, ByVal innerException As Exception)
        MyBase.New(message, innerException)
    End Sub
    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub
End Class