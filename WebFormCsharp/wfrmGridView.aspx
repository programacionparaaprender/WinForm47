<%@ Page 
    EnableEventValidation="false"
    Title="" 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="wfrmGridView.aspx.cs" 
    MasterPageFile="~/PaginaMaestra.Master" 
    Inherits="WebFormCsharp.wfrmGridView" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Menu ID="Menu1" runat="server">
        <Items>
            <asp:MenuItem Text="Crear" Value="Crear" NavigateUrl="www.facebook.com" Target="blank" ></asp:MenuItem>
            <asp:MenuItem Text="Editar" Value="Editar"></asp:MenuItem>
            <asp:MenuItem Text="Eliminar" Value="Eliminar"></asp:MenuItem>
            <asp:MenuItem Text="Generar Reporte" Value="Generar Reporte"></asp:MenuItem>
        </Items>
    
    </asp:Menu>
    <asp:Button ID="Button1" runat="server" Text="Obtener reporte" OnClick="Button1_Click" />

    
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



        
    


        <asp:GridView ID="GridView2" runat="server" OnRowCommand="GridView2_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chbTodos" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox 
                            CommandArgument="<%# Container.DataItemIndex %>"
                            CommandName="chkbocCheck"
                            ID="chbItem" 
                            runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button Text="Select" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>



</asp:Content>

