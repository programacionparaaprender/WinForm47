<%@ Page 

    Title="" 
    Language="C#" 
    AutoEventWireup="true" 
    Async="true"
    CodeBehind="wfrmGridView.aspx.cs" 
    MasterPageFile="~/PaginaMaestra.Master" 
    Inherits="WebFormCsharp.wfrmGridView" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

