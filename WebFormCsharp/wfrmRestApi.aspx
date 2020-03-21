<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfrmRestApi.aspx.cs" Inherits="WebFormCsharp.wfrmRestApi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-1.7.1.js"></script>
    <!-- https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.updatepanel?view=netframework-3.5 -->
    <script type="text/javascript">
        const urlServicio = "http://www.programandoconrupert.com/ws/servicio-gatos.php";
        function dowork() {
            //alert("Hello");
            const val = 20;
            $.ajax({
                url: urlServicio,
                type: "GET",
                //data: { 'vals': val },
                //contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {
                    alert(result);
                },
                error: function (request, status, error) {
                    alert("Error: Could not delete");
                }
            });
            $.ajax({
                url: "/wfrmRestApi.aspx/Dowork",
                type: "POST",
                data: { 'vals': val },
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {
                    alert(result);
                },
                error: function (request, status, error) {
                    alert("Error: Could not delete");
                }
            });
            $.ajax({
                type: "POST",
                url: '/wfrmRestApi.aspx/TestMethod',
                data: '{message: "HAI" }',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    console.log(data);
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        XHTML
        <input type="button" onclick="dowork" id="boton" value="Cargar HTML externo">
        <div id="cargaexterna">Aquí se cargará el HTML externo</div>
    </form>
</body>
</html>
