<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TelephoneDirectory.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Green" Text="PhoneBook"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
            <asp:TextBox ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Contact No."></asp:Label>
                    </td>
                    <td>
            <asp:TextBox ID="txtContactNo" runat="server" MaxLength="10"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Location"></asp:Label>
                    </td>
                    <td>
            <asp:TextBox ID="txtLocation" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="ADD" />
                    </td>
                    <td>
            <asp:Button ID="btnUpdate" runat="server" Enabled="False" OnClick="btnUpdate_Click" Text="UPDATE" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gridBox" runat="server">
                            <Columns>
                                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="WebForm1.aspx?id={0}&amp;action=1" HeaderText="Delete" Text="Delete">
                                <ControlStyle ForeColor="Red" />
                                </asp:HyperLinkField>
                                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="WebForm1.aspx?id={0}&amp;action=2" HeaderText="Edit" Text="Edit">
                                <ControlStyle ForeColor="Green" />
                                </asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
