Imports System.Collections.ObjectModel
Imports System.Net

''' <summary>
''' Records the details of a single web server access.
''' </summary>
Public Class LogFileEntry
    ' The page or file that was accessed.
    Private m_page As String
    ' The date and time of access.
    Private m_accessTime As Date
    ' The HTTP status code of the access.
    Private m_statusCode As Integer
    ''' <summary>
    ''' Constructs a new instance of LogFileEntry class.
    ''' </summary>
    ''' <param name="accessTime">The date and time of access.</param>
    ''' <param name="page">The page that was accessed.</param>
    ''' <param name="status">The HTTP status code of the access.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal accessTime As Date, ByVal page As String, _
                   ByVal status As Integer)
        Me.m_accessTime = accessTime
        Me.m_page = page
        Me.m_statusCode = status
    End Sub
    ''' <summary>
    ''' Date and time the web page was accessed.
    ''' </summary>
    ''' <value>Date and time of access.</value>
    Public ReadOnly Property AccessTime() As Date
        Get
            Return m_accessTime
        End Get
    End Property
    ''' <summary>
    ''' The web page or file that was accessed.
    ''' </summary>
    ''' <value>The web page or file accessed.</value>
    Public ReadOnly Property Page() As String
        Get
            Return m_page
        End Get
    End Property
    ''' <summary>
    ''' The HTTP status of the access.
    ''' </summary>
    ''' <value>HTTP status message.</value>
    Public ReadOnly Property StatusMessage() As String
        Get
            Select Case m_statusCode
                Case HttpStatusCode.OK
                    Return My.Resources.HttpCodeSucceeded
                Case HttpStatusCode.NotModified
                    Return My.Resources.HttpCodeNotModified
                Case HttpStatusCode.Unauthorized
                    Return My.Resources.HttpCodeUnauthorized
                Case HttpStatusCode.NotFound
                    Return My.Resources.HttpCodeNotFound
                Case HttpStatusCode.InternalServerError
                    Return My.Resources.HttpCodeInternalServerError
                Case Else
                    Return My.Resources.HttpCodeOther
            End Select
        End Get
    End Property
End Class

''' <summary>
''' Defines a LogFileEntry collection class.
''' </summary>
Public Class LogFileEntryCollection
    Inherits Collection(Of LogFileEntry)
End Class