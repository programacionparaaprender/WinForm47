<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="wfrmGridView.aspx.vb" Inherits="WebForm47.wfrmGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Check") %>' />

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Check") %>' Enabled="true" />
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Editar">
                    <EditItemTemplate>
                        <asp:button ID="TextBox1" runat="server" Text='<%# Bind("Editar") %>'  CommandName="cmdEdit" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Editar") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="Valor1" HeaderText="Valor1" />
                <asp:BoundField DataField="Valor2" HeaderText="Valor2" />
            </Columns>
        </asp:GridView>

        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
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
                        <asp:Button type="button" Text="Select" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            </Columns>
        </asp:GridView>
        <asp:DataGrid ID="DataGrid1" runat="server" DataSourceID="SqlDataSource1">
        </asp:DataGrid>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT * FROM [Books]"></asp:SqlDataSource>
        <br />

    </form>
</body>
</html>
