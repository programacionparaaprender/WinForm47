
## instalar librerias dotnet
dotnet add package System.Data.Entity.Repository --version 2.0.0.1

dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package  Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.Office.Interop.Excel
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package EntityFramework 

dotnet add package System.Data.Sqlclient

### verificar vídeo
https://www.youtube.com/watch?v=jzhg3-9_17g


### reemplazar app.config por json
https://blog.bitscry.com/2017/05/30/appsettings-json-in-net-core-console-app/

revisar este
https://docs.microsoft.com/es-es/ef/core/miscellaneous/connection-strings

dotnet user-secrets set ConnectionStrings.MyDBConnectionString "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MyDb.mdf;Integrated Security=True"
dotnet ef dbcontext scaffold Name=ConnectionStrings.MyDBConnectionString Microsoft.EntityFrameworkCore.SqlServer


### remover por que no son compatibles
dotnet remove package Microsoft.Office.Interop.Excel
dotnet remove package System.Data.Entity.Repository


## realizar la migración
https://docs.microsoft.com/es-es/ef/core/cli/dotnet
para que funcione crear la base de datos con la extensión dentro de debug/netcoreappx.x/

dotnet ef dbcontext scaffold "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MyDb.mdf;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -o Models

dotnet ef migrations add InitialCreate
dotnet ef database update InitialCreate

### no funcionan

dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef

dotnet ef migrations add InitialCreate
dotnet ef migrations add initial --project ../WinFormsDotnet.csproj
#### connectionstring
quitar los demás context
    <add name="MyDBConnectionString2" connectionString="Data Source=BONE\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True"
      providerName="System.Data.SqlClient" />
    <add name="CRUDSystem.Properties.Settings.TESTConnectionString"
      connectionString="Data Source=BONE\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True"
      providerName="System.Data.SqlClient" />

dotnet ef database update 20201214123900_InitialCreate --connection MyDBConnectionString




Enable-Migrations -ProjectName CRUDSystem -ContextTypeName MyDBContext
Add-Migration Initial
Update-Database
agregue luego Books 
add-migration updateNameProperty
update-database
Al agregar MyDBInitializer  es el que tiene el seeder
update-database


## trabajar archivos excel


### bordes
https://stackoverflow.com/questions/52428732/vb-net-all-borders-around-excel-cells


### negrita
https://docs.microsoft.com/en-us/office/troubleshoot/excel/transfer-data-to-excel-from-vb


### alinear texto
https://stackoverflow.com/questions/28915252/align-excel-cell-to-center-vb-xlcenter-is-not-declared

### combinar celdas
https://stackoverflow.com/questions/2825698/merge-cell-in-excel

### aumentar ancho de celda
https://docs.microsoft.com/es-es/office/vba/api/excel.range.columnwidth

### aumentar tamaño de la fila
https://docs.microsoft.com/en-us/office/vba/api/excel.range.rowheight#:~:text=The%20RowHeight%20property%20sets%20the,of%20a%20range%20of%20cells.