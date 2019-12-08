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
    </form>
</body>
</html>
