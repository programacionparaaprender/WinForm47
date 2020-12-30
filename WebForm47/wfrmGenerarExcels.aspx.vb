Imports System.IO

Public Class wfrmGenerarExcels
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            llenaGrid()

        End If

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

    Private Sub llenaGrid()
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
            dtRow.Item("Nombre") = "Nombre1: " & i.ToString()
            dtRow.Item("Apellido") = "Apellido2: " & i.ToString()
            dt.Rows.Add(dtRow)
        Next
        Me.grid1.AutoGenerateColumns = False
        Me.grid1.DataSource = dt
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
        grid.DataSource = grid1.DataSource
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
        'ExportGridToExcel()
        'ExportGridToExcel2()
        btnExportToExcel_Click()
    End Sub
End Class