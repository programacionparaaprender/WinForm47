<%@ Page 
    Culture="es-PE"
    Title="" 
    Language="C#" 
    AutoEventWireup="true" 
    Async="true"
    CodeBehind="wfrmGridView.aspx.cs" 
    MasterPageFile="~/PaginaMaestra.Master" 
    Inherits="WebFormCsharp.wfrmGridView" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

    </style>
    <link href="Styless/Site.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.7.1.js"></script>
    <script language="javascript" type="text/javascript">
        function SelectAllCheckboxes(chk) {
            var totalRows = $("#<%=GridView2.ClientID %> tr").length;
            var selected = 0;
            $('#<%=GridView2.ClientID %>').find("input:checkbox").each(function () {
                if (this != chk) {
                    this.checked = chk.checked;
                    selected += 1;
                }
            });
        }
 
        function CheckedCheckboxes(chk) {
            if (chk.checked) {
                var totalRows = $('#<%=GridView2.ClientID %> :checkbox').length;
                var checked = $('#<%=GridView2.ClientID %> :checkbox:checked').length
                if (checked == (totalRows - 1)) {
                    $('#<%=GridView2.ClientID %>').find("input:checkbox").each(function () {
                        this.checked = true;
                    });
                }
                else {
                    $('#<%=GridView2.ClientID %>').find('input:checkbox:first').removeAttr('checked');
                }
            }
            else {
                $('#<%=GridView2.ClientID %>').find('input:checkbox:first').removeAttr('checked');
            }
        }     
        function GenerarReporte(menuiten)
        {
            alert("Funciona.");
        }
        
    </script>
    <script runat="server">

        void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            switch (e.Item.Text)
            {
                case "Crear":
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "window.open('wfrmCapturaGet.aspx?ID=" + ValueHiddenField.Value + "','_blank','status=1,toolbar=0,menubar=0,location=1,scrollbars=1,resizable=1,width=30,height=30');", true);
                    break;
            }
            Label1.Text = "You selected " + e.Item.Text + ".";
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="Name" DataValueField="DepartmentId"></asp:DropDownList>
    
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="spGetEmployeesByDepartmentId" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList2" DefaultValue="1" Name="DepartmentId" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="sp_GetDepartment" SelectCommandType="StoredProcedure"></asp:SqlDataSource>



    <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeId,DepartmentId" DataSourceID="SqlDataSource4">
        <Columns>
            <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" InsertVisible="False" ReadOnly="True" SortExpression="EmployeeId" />
            <asp:BoundField DataField="EmployeeName" HeaderText="EmployeeName" SortExpression="EmployeeName" />
            <asp:BoundField DataField="DepartmentId" HeaderText="DepartmentId" InsertVisible="False" ReadOnly="True" SortExpression="DepartmentId" />
            <asp:TemplateField HeaderText="DepartmentName" SortExpression="DepartmentName">
                <HeaderTemplate>

                </HeaderTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DepartmentName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("DepartmentName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                  
        </Columns>
        <HeaderStyle BackColor="#993333" ForeColor="White" />
        <RowStyle BackColor="#FF9900" ForeColor="#993333" />
    </asp:GridView>



    <asp:GridView 
        ID="GridView7" 
        runat="server" 
        AutoGenerateColumns="False" DataSourceID="SqlDataSource2" DataKeyNames="Id" OnRowDataBound="GridView7_RowDataBound" ShowFooter="True">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField 
                DataField="DateOfBirth" 
                HeaderText="DateOfBirth" 
                DataFormatString="{0:d}"
                SortExpression="DateOfBirth" />
            <asp:BoundField 
                DataField="AnnualSalary" 
                HeaderText="AnnualSalary"
                
                SortExpression="AnnualSalary" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
            <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" SortExpression="DepartmentName" />
            <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
            <asp:BoundField 
                DataField="Culture" 
                HeaderText="Culture" 
                ItemStyle-CssClass="DisplayNone"
                HeaderStyle-CssClass="DisplayNone"
                SortExpression="Culture" >
<HeaderStyle CssClass="DisplayNode"></HeaderStyle>

<ItemStyle CssClass="DisplayNone"></ItemStyle>
            </asp:BoundField>
        </Columns>

        <HeaderStyle BackColor="#993333" ForeColor="White" />
        <RowStyle BackColor="#FFCC00" ForeColor="#993333" />

        </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT * FROM [Employees]"></asp:SqlDataSource>



    <asp:GridView 
        ID="GridView6" 
        runat="server" 
        AutoGenerateColumns="False" 
        DataSourceID="XmlDataSource2">

        </asp:GridView>
    <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/Data/Countries2.xml" TransformFile="~/Data/CountriesXSLT.xslt"></asp:XmlDataSource>
    
  
    <asp:GridView 
        ID="GridView5" 
        runat="server" 
        AutoGenerateColumns="False" 
        DataSourceID="XmlDataSource1">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Continent" HeaderText="Continent" SortExpression="Continent" />
        </Columns>

        </asp:GridView>
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Data/Countries.xml"></asp:XmlDataSource>
    <asp:GridView 
        ID="GridView4" 
        runat="server" 
        AutoGenerateColumns="False" 
        DataKeyNames="Id" 
        DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:BoundField 
                    DataField="Id" 
                    HeaderText="Id" 
                    InsertVisible="False" 
                    ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            </Columns>

        </asp:GridView>
        
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllProducts" TypeName="WebFormCsharp.ProductDataAccessLayer"></asp:ObjectDataSource>
        


    <asp:Menu 
        ID="Menu1" 
        Orientation="Horizontal" 
        runat="server" 
        autopostback="false"
        OnMenuItemClick="Menu1_MenuItemClick" 
        OnMenuItemDataBound="Menu1_MenuItemDataBound">
        <Items>
            <asp:MenuItem Text="Crear" Value="Crear"></asp:MenuItem>
            <asp:MenuItem Text="Editar" Value="Editar"></asp:MenuItem>
            <asp:MenuItem Text="Eliminar" Value="Eliminar"></asp:MenuItem>
            <asp:MenuItem Text="Generar Reporte" Value="Generar Reporte"></asp:MenuItem>
        </Items>
    
    </asp:Menu>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:hiddenfield id="ValueHiddenField"
              value="123" 
              runat="server"/>
    <asp:GridView ID="GridView2" runat="server" OnRowCommand="GridView2_RowCommand" AutoGenerateColumns="False">
            <Columns>
                
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox 
                            ID="chkTodos" 
                            runat="server" 
                            onclick="javascript:SelectAllCheckboxes(this)"
                            />
                    </HeaderTemplate>
                    <ItemTemplate>
                           
                        <asp:CheckBox 
                            onclick="javascript:CheckedCheckboxes(this)"
                            ID="chbItem" 
                            runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
            </Columns>
        </asp:GridView>


    <asp:Button ID="Button1" runat="server" Text="Obtener reporte" OnClick="Button1_Click" />

    
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView3_RowCommand">
    <Columns>
        <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="150px" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button Text="Select" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id">
    </asp:DropDownList>    
    
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField 
                    DataField="Id" 
                    HeaderText="Id" 
                    InsertVisible="False" 
                    ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            </Columns>

        </asp:GridView>
        
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT [Id], [Name] FROM [Books]"></asp:SqlDataSource>



        
    


        




</asp:Content>

