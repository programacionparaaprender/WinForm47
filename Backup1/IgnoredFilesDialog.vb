Imports System.Collections.Specialized
Imports System.Globalization

''' <summary>
''' Displays a list of filename extensions and allows the user to edit it.
''' </summary>
Public Class IgnoredFilesDialog
    ' The list of filename extensions to ignore.
    Private m_ignoredExtensions As New StringCollection

    ''' <summary>
    ''' Gets or sets the list of filename extensions to ignore.
    ''' </summary>
    Public ReadOnly Property IgnoredExtensions() As StringCollection
        Get
            Return m_ignoredExtensions
        End Get
    End Property

    Public Sub SetIgnoredExtensions(ByVal extensions As String())
        Me.m_ignoredExtensions.Clear()
        Me.m_ignoredExtensions.AddRange(extensions)
    End Sub

    ''' <summary>
    ''' Initializes the dialog.
    ''' </summary>
    Private Sub IgnoredFilesDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim extensions(Me.m_ignoredExtensions.Count - 1) As String
        Me.m_ignoredExtensions.CopyTo(extensions, 0)
        Me.extensionsTextBox.Text = Join(extensions, ",")
    End Sub

    ''' <summary>
    ''' Handles the OK button click event.
    ''' </summary>
    Private Sub OkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkButton.Click
        ' The list of filename extensions to ignore.
        Dim extensions As New StringCollection
        ' Split the comma separated list into individual elements.
        Dim temp As String() = Me.extensionsTextBox.Text.Split(",")
        ' Loop through the array and add valid elements to the list of extensions.
        Dim i As Integer
        For i = 0 To temp.Length - 1
            Dim s As String = temp(i).Trim().ToLower(CultureInfo.CurrentCulture)
            If s.Length > 0 Then extensions.Add(s)
        Next
        Me.m_ignoredExtensions = extensions
        Me.DialogResult = Windows.Forms.DialogResult.OK
        ' Close the dialog.
        Me.Close()
    End Sub
End Class