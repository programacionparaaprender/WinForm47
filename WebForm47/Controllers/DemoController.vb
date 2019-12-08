Imports System.Net
Imports System.Web.Http
'Imports System.Web.Mvc
<Route("demo")>
Public Class DemoController
    'Inherits Controller

    'Private ReadOnly _db As WorkoutContext

    'Public Sub New(ByVal db As WorkoutContext)
    '    _db = db
    'End Sub

    '<Route("")>
    '<Route("index")>
    '<Route("~/")>
    'Public Function Index() As IActionResult
    '    Return View()
    'End Function

    '<Route("demo1")>
    'Public Function Demo1() As IActionResult
    '    Return New JsonResult("Hello")
    'End Function

    '<Route("create2/{nombre}&{apellido}")>
    'Public Function Create2(ByVal nombre As String, ByVal apellido As String) As IActionResult
    '    Dim book As Book = New Book()
    '    book.Id = 0
    '    book.Name = nombre & apellido

    '    If ModelState.IsValid Then
    '        _db.Add(book)
    '        _db.SaveChanges()
    '    End If

    '    Dim cadena As String = JsonConvert.SerializeObject(book)
    '    Return New JsonResult(" " & cadena)
    'End Function

    '<Route("create/{name}")>
    'Public Function Create(ByVal name As String) As IActionResult
    '    Dim book As Book = New Book()
    '    book.Id = 0
    '    book.Name = name

    '    If ModelState.IsValid Then
    '        _db.Add(book)
    '        _db.SaveChanges()
    '    End If

    '    Dim cadena As String = JsonConvert.SerializeObject(book)
    '    Return New JsonResult(" " & cadena)
    'End Function

    '<Route("demo2/{fullName}")>
    'Public Function Demo2(ByVal fullName As String) As IActionResult
    '    Return New JsonResult("Hello " & fullName)
    'End Function

    '<Route("demo3")>
    'Public Function Demo3() As IActionResult
    '    Dim product = New Product() With {
    '        .Id = "p01",
    '        .Name = "name 1",
    '        .Price = 123
    '    }
    '    Return New JsonResult(product)
    'End Function

    '<Route("demo4")>
    'Public Function Demo4() As IActionResult
    '    Dim products = New List(Of Product)() From {
    '        New Product() With {
    '            .Id = "p01",
    '            .Name = "name 1",
    '            .Price = 123
    '        },
    '        New Product() With {
    '            .Id = "p02",
    '            .Name = "name 2",
    '            .Price = 456
    '        },
    '        New Product() With {
    '            .Id = "p03",
    '            .Name = "name 3",
    '            .Price = 789
    '        }
    '    }
    '    Return New JsonResult(products)
    'End Function
End Class

