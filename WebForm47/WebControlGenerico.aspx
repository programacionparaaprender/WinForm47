<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebControlGenerico.aspx.vb" Inherits="WebForm47.WebControlGenerico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <input id="filename" name="filename" type="file" />
        <img src="" height="200" alt="Image preview...">
        <div>
        </div>
    </form>
    <div style="display:block;"><h2>Canvas</h2></div>
    <canvas id="micanvas" width="150" height="150" style="display:block"></canvas>
    
    <canvas id="mipintado" width="150" height="150" style="display:block; border:10px #ccc solid;"></canvas>
    <img id="otraimg" src="" width="150" height="150" style="display:block; border:10px #ccc solid;" />
    <!--<script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.0.js"></script>-->
    <!--https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.fileupload?view=netframework-4.7.2-->
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.9.0.js"></script>
    <script type="text/javascript">
        // Check for the various File API support.
        if (window.File && window.FileReader && window.FileList && window.Blob) {
            // Great success! All the File APIs are supported.
        } else {
            alert('The File APIs are not fully supported in this browser.');
        }

        function previewFile()
        {
            var preview = document.querySelector('img');
            var file = document.querySelector('input[type=file]').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
                var micanvas = document.getElementById("micanvas");
                var ctx = micanvas.getContext("2d");
                var miimagen = new Image();
                miimagen.src = reader.result;
                console.log(reader.result);
                miimagen.onload = function()
                {
                    /*
                     ImageData.data Read only
                    Is a Uint8ClampedArray representing a one-dimensional array containing the data in the RGBA order, with integer values between 0 and 255 (inclusive).
                    ImageData.height Read only
                    Is an unsigned long representing the actual height, in pixels, of the ImageData.
                    ImageData.width Read only
                    Is an unsigned long representing the actual width, in pixels, of the ImageData.
                     */
                    //console.log(miimagen.decode());
                    ctx.drawImage(miimagen, 0, 0, 150, 150);
                    var ImageData = ctx.getImageData(0, 0, 150, 150);
                    //console.log(ImageData.data);
                    //console.log(micanvas.toDataURL());

                    //const img = new Image();
                    //img.src = 'nebula.jpg';
                    //img.decode();

                    var RegistroImagen = {};
                    RegistroImagen.data = reader.result;

                    $.ajax({
                        url: "GuardarImagen.ashx",
                        type: "POST",
                        data: RegistroImagen.data,//JSON.stringify(RegistroImagen.data),//JSON.stringify(RegistroImagen),
                        dataType: "json",
                        contentType: "application/json",
                        success: function (result) {
                            //var json = JSON.stringify(result)
                            //alert(json);
                            
                            var mipintado = document.getElementById("mipintado");
                            var nuevaimg = new Image();
                            nuevaimg.src = result;//json.data;//reader.result;//micanvas.toDataURL();
                            var ctx2 = mipintado.getContext("2d");
                            ctx2.drawImage(nuevaimg, 0, 0, 150, 150);

                            var otraimg = document.getElementById("otraimg");
                            otraimg.src = result;//reader.result;
                            //var id2 = new ImageData(150, 150);//{};//ctx2.getImageData(0, 0, 150, 150);
                            
                        },
                        error: function (request, status, error) {
                            alert("Error: Could not delete" + error);
                        }
                    });
                    


                }

            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }
        document.getElementById('filename').addEventListener('change', previewFile, false);
    </script>
</body>
</html>
