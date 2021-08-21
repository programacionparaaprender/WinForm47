Imports System.IO

Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System

Public Class wfrmGenerarExcels
    Inherits System.Web.UI.Page

    Private letras As String() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            llenaGrid()

        End If

    End Sub

    Public Shared Sub SetSpreadsheetHeaderBold(ByVal excelFilePath As String)
        Using spreadsheetDocument As SpreadsheetDocument = SpreadsheetDocument.Open(excelFilePath, True)
            Dim workbookPart As WorkbookPart = spreadsheetDocument.WorkbookPart
            Dim worksheetPart As WorksheetPart = workbookPart.WorksheetParts.First()
            Dim sheetData As SheetData = worksheetPart.Worksheet.Elements(Of SheetData)().First()
            Dim stylesPart As WorkbookStylesPart = spreadsheetDocument.WorkbookPart.WorkbookStylesPart
            Dim font1 As DocumentFormat.OpenXml.Spreadsheet.Font = New DocumentFormat.OpenXml.Spreadsheet.Font(New Bold(), New FontSize() With {
            .Val = 11
        }, New Color() With {
            .Rgb = New HexBinaryValue() With {
                .Value = "000000"
            }
        }, New FontName() With {
            .Val = "Calibri"
        })
            stylesPart.Stylesheet.Fonts.Append(font1)
            stylesPart.Stylesheet.Save()
            Dim fontId As UInt32Value = Convert.ToUInt32(stylesPart.Stylesheet.Fonts.ChildElements.Count - 1)
            Dim cf As CellFormat = New CellFormat() With {
            .FontId = fontId,
            .FillId = 0,
            .BorderId = 0,
            .ApplyFont = True
        }
            stylesPart.Stylesheet.CellFormats.Append(cf)
            'Dim r As Row = sheetData.Elements(Of Row)().First(Of Row)()
            'Dim index1 As Integer = stylesPart.Stylesheet.CellFormats.ChildElements.Count - 1

            'For Each c As Cell In r.Elements(Of Cell)()
            '    c.StyleIndex = Convert.ToUInt32(index1)
            '    worksheetPart.Worksheet.Save()
            'Next

            'spreadsheetDocument.Close()
        End Using
    End Sub

    Public Function GenerateStyleSheet() As Stylesheet
        Return New Stylesheet(New DocumentFormat.OpenXml.Spreadsheet.Fonts(New DocumentFormat.OpenXml.Spreadsheet.Font(New FontSize() With {
        .Val = 11
    }, New Color() With {
        .Rgb = New HexBinaryValue() With {
            .Value = "000000"
        }
    }, New FontName() With {
        .Val = "Calibri"
    }), New Font(New Bold(), New FontSize() With {
        .Val = 11
    }, New Color() With {
        .Rgb = New HexBinaryValue() With {
            .Value = "000000"
        }
    }, New FontName() With {
        .Val = "Calibri"
    }), New Font(New Italic(), New FontSize() With {
        .Val = 11
    }, New Color() With {
        .Rgb = New HexBinaryValue() With {
            .Value = "000000"
        }
    }, New FontName() With {
        .Val = "Calibri"
    }), New Font(New FontSize() With {
        .Val = 18
    }, New Color() With {
        .Rgb = New HexBinaryValue() With {
            .Value = "000000"
        }
    }, New FontName() With {
        .Val = "Calibri"
    }), New Font(New Bold(), New FontSize() With {
        .Val = 18
    }, New Color() With {
        .Rgb = New HexBinaryValue() With {
            .Value = "000000"
        }
    }, New FontName() With {
        .Val = "Calibri"
    }), New Font(New Bold(), New FontSize() With {
        .Val = 11
    }, New Color() With {
        .Rgb = New HexBinaryValue() With {
            .Value = "FFFFFF"
        }
    }, New FontName() With {
        .Val = "Calibri"
    })), New Fills(New DocumentFormat.OpenXml.Spreadsheet.Fill(New DocumentFormat.OpenXml.Spreadsheet.PatternFill() With {
        .PatternType = PatternValues.None
    }), New DocumentFormat.OpenXml.Spreadsheet.Fill(New DocumentFormat.OpenXml.Spreadsheet.PatternFill() With {
        .PatternType = PatternValues.Gray125
    }), New DocumentFormat.OpenXml.Spreadsheet.Fill(New DocumentFormat.OpenXml.Spreadsheet.PatternFill(New DocumentFormat.OpenXml.Spreadsheet.ForegroundColor() With {
        .Rgb = New HexBinaryValue() With {
            .Value = "FFFFFF00"
        }
    }) With {
        .PatternType = PatternValues.Solid
    }), New DocumentFormat.OpenXml.Spreadsheet.Fill(New DocumentFormat.OpenXml.Spreadsheet.PatternFill(New DocumentFormat.OpenXml.Spreadsheet.ForegroundColor() With {
        .Rgb = New HexBinaryValue() With {
            .Value = "8EA9DB"
        }
    }) With {
        .PatternType = PatternValues.Solid
    })), New Borders(New Border(New DocumentFormat.OpenXml.Spreadsheet.LeftBorder(), New DocumentFormat.OpenXml.Spreadsheet.RightBorder(), New DocumentFormat.OpenXml.Spreadsheet.TopBorder(), New DocumentFormat.OpenXml.Spreadsheet.BottomBorder(), New DiagonalBorder()), New Border(New DocumentFormat.OpenXml.Spreadsheet.LeftBorder(New Color() With {
        .Auto = True
    }) With {
        .Style = BorderStyleValues.Thin
    }, New DocumentFormat.OpenXml.Spreadsheet.RightBorder(New Color() With {
        .Auto = True
    }) With {
        .Style = BorderStyleValues.Thin
    }, New DocumentFormat.OpenXml.Spreadsheet.TopBorder(New Color() With {
        .Auto = True
    }) With {
        .Style = BorderStyleValues.Thin
    }, New DocumentFormat.OpenXml.Spreadsheet.BottomBorder(New Color() With {
        .Auto = True
    }) With {
        .Style = BorderStyleValues.Thin
    }, New DiagonalBorder()), New Border(New DocumentFormat.OpenXml.Spreadsheet.LeftBorder(New Color() With {
        .Auto = True
    }) With {
        .Style = BorderStyleValues.None
    }, New DocumentFormat.OpenXml.Spreadsheet.RightBorder(New Color() With {
        .Auto = True
    }) With {
        .Style = BorderStyleValues.None
    }, New DocumentFormat.OpenXml.Spreadsheet.TopBorder(New Color() With {
        .Auto = True
    }) With {
        .Style = BorderStyleValues.None
    }, New DocumentFormat.OpenXml.Spreadsheet.BottomBorder(New Color() With {
        .Rgb = New HexBinaryValue() With {
            .Value = "70AD47"
        }
    }) With {
        .Style = BorderStyleValues.Thin
    }, New DiagonalBorder())), New CellFormats(New CellFormat() With {
        .FontId = 0,
        .FillId = 0,
        .BorderId = 0
    }, New CellFormat() With {
        .FontId = 1,
        .FillId = 0,
        .BorderId = 0,
        .ApplyFont = True
    }, New CellFormat() With {
        .FontId = 2,
        .FillId = 0,
        .BorderId = 0,
        .ApplyFont = True
    }, New CellFormat() With {
        .FontId = 3,
        .FillId = 0,
        .BorderId = 0,
        .ApplyFont = True
    }, New CellFormat() With {
        .FontId = 0,
        .FillId = 2,
        .BorderId = 0,
        .ApplyFill = True
    }, New CellFormat(New Alignment() With {
        .Horizontal = HorizontalAlignmentValues.Center,
        .Vertical = VerticalAlignmentValues.Center
    }) With {
        .FontId = 0,
        .FillId = 0,
        .BorderId = 0,
        .ApplyAlignment = True
    }, New CellFormat() With {
        .FontId = 0,
        .FillId = 0,
        .BorderId = 1,
        .ApplyBorder = True
    }, New CellFormat(New Alignment() With {
        .Horizontal = HorizontalAlignmentValues.Center,
        .Vertical = VerticalAlignmentValues.Center
    }) With {
        .FontId = 1,
        .FillId = 0,
        .BorderId = 0,
        .ApplyAlignment = True
    }, New CellFormat() With {
        .FontId = 4,
        .FillId = 0,
        .BorderId = 0,
        .ApplyFont = True
    }, New CellFormat(New Alignment() With {
        .Horizontal = HorizontalAlignmentValues.Center,
        .Vertical = VerticalAlignmentValues.Center
    }) With {
        .FontId = 0,
        .FillId = 0,
        .BorderId = 2,
        .ApplyFont = True
    }, New CellFormat(New Alignment() With {
        .Horizontal = HorizontalAlignmentValues.Center,
        .Vertical = VerticalAlignmentValues.Center
    }) With {
        .FontId = 5,
        .FillId = 3,
        .BorderId = 0,
        .ApplyAlignment = True
    }))
    End Function

    Private Sub Create(ByVal fileName As String)
        Dim ms As MemoryStream = New MemoryStream()
        Dim xl As SpreadsheetDocument = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook)
        Dim wbp As WorkbookPart = xl.AddWorkbookPart()
        Dim wsp As WorksheetPart = wbp.AddNewPart(Of WorksheetPart)()
        Dim wb As Workbook = New Workbook()
        Dim fv As FileVersion = New FileVersion()
        fv.ApplicationName = "Microsoft Office Excel"
        Dim ws As Worksheet = New Worksheet()
        Dim sd As SheetData = New SheetData()
        Dim r1 As Row = New Row() With {
            .RowIndex = CType(1UI, UInt32Value)
        }

        Dim indice As String = 0

        Dim dt As DataTable
        dt = crearData()

        'var workbookStylesPart = spreadsheetDocument.WorkbookPart.GetPartsOfType<WorkbookStylesPart>().First()
        Dim stylesPart As WorkbookStylesPart = xl.WorkbookPart.AddNewPart(Of WorkbookStylesPart)
        'Dim stylesPart As WorkbookStylesPart = wbp.WorkbookStylesPart.AddNewPart(Of WorkbookStylesPart)

        stylesPart.Stylesheet = GenerateStyleSheet()
        stylesPart.Stylesheet.Save()


        'Dim r As Row = sd.Elements(Of Row)().First(Of Row)()
        Dim index1 As Integer = stylesPart.Stylesheet.CellFormats.ChildElements.Count - 1


        For j As Integer = 0 To dt.Columns.Count - 1
            Dim celda As Cell = New Cell()
            Dim letra As String
            letra = letras(j) + Convert.ToString(indice + 1)
            celda.CellReference = letra
            celda.DataType = CellValues.String
            Dim valor As String
            Dim row As DataRow
            valor = dt.Columns(j).ColumnName

            'celda.DataType = CellValues.InlineString
            Dim temp As Row = New Row() With {
                    .RowIndex = CType(1UI, UInt32Value)
                }

            'celda.StyleIndex = Convert.ToUInt32(index1)


            celda.CellValue = New CellValue(valor)

            temp.Append(celda)

            sd.Append(temp)

        Next

        indice = indice + 1

        For i As Integer = 0 To dt.Rows.Count - 1
            For j As Integer = 0 To dt.Columns.Count - 1
                Dim celda As Cell = New Cell()
                Dim letra As String
                letra = letras(j) + Convert.ToString(indice + i + 1)
                celda.CellReference = letra
                celda.DataType = CellValues.String
                Dim valor As String
                Dim row As DataRow
                row = dt.Rows(i)
                valor = row.Item(j).ToString()
                celda.CellValue = New CellValue(valor)
                Dim temp As Row = New Row() With {
                    .RowIndex = CType(1UI, UInt32Value)
                }
                temp.Append(celda)
                sd.Append(temp)

            Next
        Next
        ws.Append(sd)

        'Dim c1 As Cell = New Cell()
        'c1.DataType = CellValues.String
        'c1.CellValue = New CellValue("some value")
        'r1.Append(c1)
        'Dim c2 As Cell = New Cell()
        'c2.CellReference = "C1"
        'c2.DataType = CellValues.String
        'c2.CellValue = New CellValue("other value")
        'r1.Append(c2)
        'sd.Append(r1)
        'Dim r2 As Row = New Row() With {
        '    .RowIndex = CType(2UI, UInt32Value)
        '}
        'Dim c3 As Cell = New Cell()
        'c3.DataType = CellValues.String
        'c3.CellValue = New CellValue("some string")
        'r2.Append(c3)
        'sd.Append(r2)
        'ws.Append(sd)


        wsp.Worksheet = ws
        wsp.Worksheet.Save()
        Dim sheets As Sheets = New Sheets()
        Dim sheet As Sheet = New Sheet()
        sheet.Name = "first sheet"
        sheet.SheetId = 1
        sheet.Id = wbp.GetIdOfPart(wsp)
        sheets.Append(sheet)
        wb.Append(fv)
        wb.Append(sheets)
        xl.WorkbookPart.Workbook = wb
        xl.WorkbookPart.Workbook.Save()
        xl.Close()
        Response.Clear()
        Dim binary As Byte() = ms.ToArray()
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", fileName))
        Response.BinaryWrite(binary)
        Response.[End]()
    End Sub
    'Private void exportar() 
    '{
    '    Response.Clear();
    '    Response.Buffer = true;
    '    Response.AddHeader("content-disposition", "attachment;filename="+txtNumer.Text+".xls");
    '    Response.Charset = "";
    '    Response.ContentType = "application/vnd.ms-excel";
    '     Using (StringWriter sw = New StringWriter())
    '      {
    '        HtmlTextWriter hw = New HtmlTextWriter(sw);

    '         To Export all pages
    '      GridView1.AllowPaging = false;
    '        this.llenaGrid();

    '       GridView1.HeaderRow.BackColor = Color.White;
    '        foreach (TableCell cell in GridView1.HeaderRow.Cells)
    '        {
    '            cell.BackColor = GridView1.HeaderStyle.BackColor;
    '        }
    '        foreach (GridViewRow row in GridView1.Rows)
    '       {
    '            row.BackColor = Color.White;
    '            foreach (TableCell cell in row.Cells)
    '            {
    '                If (row.RowIndex % 2 == 0)
    '                {
    '                    cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
    '                }
    '                Else
    '                {
    '                    cell.BackColor = GridView1.RowStyle.BackColor;
    '                }
    '                cell.CssClass = "textmode";
    '            }
    '        }

    '        GridView1.RenderControl(hw);

    '        style to format numbers to string
    '        String style = @"<style> .textmode { } </style>";
    '        Response.Write(style);
    '        Response.Output.Write(sw.ToString());
    '        Response.Flush();
    '        Response.End();
    '    }

    Private Function crearData() As DataTable
        Dim dt As New DataTable
        Dim dc As DataColumn

        dc = New DataColumn("Id", Type.GetType("System.String"))
        dt.Columns.Add(dc)

        dc = New DataColumn("Nombre", Type.GetType("System.String"))
        dt.Columns.Add(dc)
        dc = New DataColumn("Apellido", Type.GetType("System.String"))
        dt.Columns.Add(dc)

        For i As Integer = 0 To 20
            Dim dtRow As DataRow = dt.NewRow
            dtRow.Item("Id") = i.ToString()
            dtRow.Item("Nombre") = "Nombre" & i.ToString()
            dtRow.Item("Apellido") = "Apellido" & i.ToString()
            dt.Rows.Add(dtRow)
        Next
        Return dt
    End Function

    Private Sub llenaGrid()
        Me.grid1.AutoGenerateColumns = False
        Me.grid1.DataSource = crearData()
        Me.grid1.DataBind()
    End Sub

    Protected Form11 As New System.Web.UI.HtmlControls.HtmlForm

    Protected Sub btnExportToExcel_Click()
        Form11.Controls.Clear()
        Form11.Controls.Add(grid1)
        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
        Dim htWriter As HtmlTextWriter = New HtmlTextWriter(New System.IO.StringWriter(sb))
        Form11.RenderControl(htWriter)
        'Form11.Write(StringBuilder.ToString())
        'Form11.End()
        'Response.ClearContent()
        'Response.AppendHeader("content-disposition", "attachment; filename=Employees.xls")
        'Response.ContentType = "application/excel"
        'Dim stringWriter As System.IO.StringWriter = New System.IO.StringWriter()
        'Dim htw As HtmlTextWriter = New HtmlTextWriter(stringWriter)
        'grid1.HeaderRow.Style.Add("background-color", "#FFFFFF")

        'For Each tableCell As TableCell In grid1.HeaderRow.Cells
        '    tableCell.Style("background-color") = "#A55129"
        'Next

        'For Each gridViewRow As GridViewRow In grid1.Rows
        '    gridViewRow.BackColor = System.Drawing.Color.White

        '    For Each gridViewRowTableCell As TableCell In gridViewRow.Cells
        '        gridViewRowTableCell.Style("background-color") = "#FFF7E7"
        '    Next
        'Next

        'grid1.RenderControl(htw)
        'Response.Write(stringWriter.ToString())
        'Response.[End]()
    End Sub



    Private Sub ExportGridToExcel2()

        Response.Clear()
        Response.Buffer = True
        Response.ClearContent()
        Response.ClearHeaders()
        Response.Charset = ""
        Dim FileName As String
        FileName = "Vithal" + DateTime.Now + ".xls"
        Dim strwritter As StringWriter = New StringWriter()
        Dim htmltextwrtter As HtmlTextWriter = New HtmlTextWriter(strwritter)
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName)
        grid1.DataSource = crearData() '
        grid1.DataBind()
        grid1.GridLines = GridLines.Both
        grid1.HeaderStyle.Font.Bold = True
        grid1.AllowPaging = False
        'BindData()
        grid1.RenderControl(htmltextwrtter)
        Response.Write(strwritter.ToString())
        Response.End()

    End Sub

    Private Sub ExportGridToExcel()

        Response.Clear()
        Response.Buffer = True
        Response.ClearContent()
        Response.ClearHeaders()
        Response.Charset = ""
        Dim FileName As String
        FileName = "RepoToolMaint" + DateTime.Now + ".xls"
        Dim strwritter As StringWriter = New StringWriter()
        Dim htmltextwrtter As HtmlTextWriter = New HtmlTextWriter(strwritter)
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment:filename=" + FileName)
        Dim grid As GridView = New GridView()
        grid.DataSource = crearData() 'grid1.DataSource
        grid.DataBind()
        grid.GridLines = GridLines.Both
        grid.HeaderStyle.Font.Bold = True
        grid.RenderControl(htmltextwrtter)

        'grid1.GridLines = GridLines.Both
        'grid1.HeaderStyle.Font.Bold = True
        'grid1.RenderControl(htmltextwrtter)
        Response.Write(strwritter.ToString())
        Response.End()
    End Sub

    Protected Sub btnBotonGenerarExcelGrid_Click(sender As Object, e As EventArgs) Handles btnBotonGenerarExcelGrid.Click
        'xportGridToExcel()
        ExportGridToExcel2()
        'Create("RepoToolMaint.xlsx")
        'btnExportToExcel_Click()
    End Sub
End Class