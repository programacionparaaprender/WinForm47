Imports System.IO
Imports System.Runtime.Serialization.Json
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services

Public Class GuardarImagen
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Try
            Dim strJson As String = New StreamReader(context.Request.InputStream).ReadToEnd()
            Dim base64 As String = strJson '"data:image/jpeg;base64,ba9867b6a86ba86b6a6ab6abaa====";

            '// Some known piece of information that will be in the above string
            Dim identifier As String = ";base64,"

            '// Find where it exists in the input string
            Dim dataIndex = base64.IndexOf(identifier)

            '// Take the portion after this identifier; that's the real base-64 portion
            Dim cleaned = base64.Substring(dataIndex + identifier.Length)

            ' Get the bytes
            Dim bytes As Byte() = Convert.FromBase64String(cleaned)
            If strJson IsNot Nothing Then
                context.Response.Write(strJson)
            Else
                context.Response.Write("No Data")
            End If

        Catch ex As Exception
            context.Response.Write("Error :" & ex.Message)
        End Try
    End Sub


    'Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
    '    Try
    '        Dim strJson As String = New StreamReader(context.Request.InputStream).ReadToEnd()
    '        Dim cadena As String = context.Request.QueryString("data")
    '        Dim objUsr As RegistroImagen = Deserialize(Of RegistroImagen)(strJson)

    '        If objUsr IsNot Nothing Then
    '            'context.Response.Write("Se guardo exitosamente")

    '            Dim bsObj = New RegistroImagen() With
    '            {
    '                .Data = objUsr.Data
    '            }

    '            Dim js = New DataContractJsonSerializer(GetType(ImageData))
    '            Dim msObj = New MemoryStream()
    '            js.WriteObject(msObj, bsObj)
    '            msObj.Position = 0
    '            Dim SR = New StreamReader(msObj)

    '            ' "{\"Description\":\"Share Knowledge\",\"Name\":\"C-sharpcorner\"}"  
    '            Dim json = SR.ReadToEnd()

    '            SR.Close()
    '            msObj.Close()

    '            context.Response.Write(json)
    '        Else
    '            context.Response.Write("No Data")
    '        End If

    '    Catch ex As Exception
    '        context.Response.Write("Error :" & ex.Message)
    '    End Try
    'End Sub

    Public Function Deserialize(Of T)(ByVal context As String) As T
        Dim jsonData As String = context
        Dim obj = CType(New JavaScriptSerializer().Deserialize(Of T)(jsonData), T)
        Return obj
    End Function

    Public Class RegistroImagen
        Private _data As String

        Public Property Data As String
            Get
                Return _data
            End Get
            Set(value As String)
                _data = value
            End Set
        End Property
    End Class

    Public Class ImageData
            Private _height As Long
            Private _width As Long
        'Uint8ClampedArray representing a one-dimensional array containing the data in the RGBA order, with integer values between 0 And 255 (inclusive).
        Private _data As Dictionary(Of String, Integer)
        Public Property Data As Dictionary(Of String, Integer)
                Get
                    Return _data
                End Get
                Set(value As Dictionary(Of String, Integer))
                    _data = value
                End Set
            End Property
            'Private _data As Long()
            'Public Property Data As Long()
            '    Get
            '        Return _data
            '    End Get
            '    Set(value As Long())
            '        _data = value
            '    End Set
            'End Property

            Public Property Height As Long
                Get
                    Return _height
                End Get
                Set(value As Long)
                    _height = value
                End Set
            End Property

            Public Property Width As Long
                Get
                    Return _width
                End Get
                Set(value As Long)
                    _width = value
                End Set
            End Property
        End Class
        Public Class AddValues

            Public _value1 As Integer

            Public _value2 As Integer

            Public Sub New()
                _value1 = 0
                _value2 = 0
            End Sub
            Public Property value1 As String
                Set(value As String)
                    _value1 = value
                End Set
                Get
                    Return _value1
                End Get
            End Property
            Public Property value2 As String
                Set(value As String)
                    _value2 = value
                End Set
                Get
                    Return _value2
                End Get
            End Property
        End Class


        Public Class userInfo
            Public _first_name As String
            Public _last_name As String
            Public _qualification As String
            Public _age As String

            Public Property first_name As String
                Set(value As String)
                    _first_name = value
                End Set
                Get
                    Return _first_name
                End Get
            End Property
            Public Property last_name As String
                Set(value As String)
                    _last_name = value
                End Set
                Get
                    Return _last_name
                End Get
            End Property
            Public Property qualification As String
                Set(value As String)
                    _qualification = value
                End Set
                Get
                    Return _qualification
                End Get
            End Property
            Public Property age As String
                Set(value As String)
                    _age = value
                End Set
                Get
                    Return _age
                End Get
            End Property
        End Class

        ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                Return False
            End Get
        End Property

    End Class