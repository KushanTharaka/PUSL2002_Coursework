<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoA Acc Revoke Reinstate.aspx.cs" Inherits="WEB_Project.DoA_Acc_Revoke_Reinstate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DoA Revoke Reinstate</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Common.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

            <div class="navbar">
                <a class="active" href="WebMaster HomePage.aspx" style="font-family: Arial"><i class="fa fa-arrow-left" aria-hidden="true"></i> Back</a>
            </div>
            <br />
            <div>
                <h3 style="color:white;font-weight:bold">Select Account Type: 
                                            <asp:DropDownList ID="acctype" runat="server">
                                                <asp:ListItem Value="DoA">DoA Staff Accounts</asp:ListItem>
                                                <asp:ListItem Value="Farmer">Farmer Accounts</asp:ListItem>
                                                <asp:ListItem Value="Keels">Keells Staff Accounts</asp:ListItem>        
                                            </asp:DropDownList>
                    <asp:Button ID="typeacc" runat="server" Text="Ok" OnClick="typeacc_Click" BackColor="#009933" BorderColor="White" Font-Bold="True" ForeColor="White" Height="30px" />
                </h3>
            </div>
            <br />
            <div style="float: left;padding-left:50px">
                <h5 style="color:white;font-weight:bold">Active Accounts</h5>
                <asp:GridView ID="DoAAcc" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="DoAAcc_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="DoA_Id" HeaderText="DoA_Id" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                        <asp:BoundField DataField="Username" HeaderText="Username" />
                        <asp:BoundField DataField="Password" HeaderText="Password" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <br />
                <div id="rev3">
                    <table>
                        <tr>
                            <td style="color:white;font-weight:bold">Select to Revoke Account </td>
                            <td>
                                <asp:TextBox ID="txtD1ID" runat="server" /></td>
                            <td>
                                <asp:Button ID="btnDRevoke" runat="server" Text="Revoke" OnClick="btnDRevoke_Click" BackColor="#009933" BorderColor="White" Font-Bold="True" ForeColor="White" Height="30px" />
                            </td>
                            <td>
                                <asp:HiddenField ID="hfindex1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="float: right;padding-right:50px">
                <h5 style="color:white;font-weight:bold">Revoked Accounts</h5>
                <asp:GridView ID="DoARevAcc" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="DoARevAcc_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="DoA_Id" HeaderText="DoA_Id" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                        <asp:BoundField DataField="Username" HeaderText="Username" />
                        <asp:BoundField DataField="Password" HeaderText="Password" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <br />
                <div id="rein3">
                    <table>
                        <tr>
                            <td style="color:white;font-weight:bold">Select to Reinstate Account </td>
                            <td>
                                <asp:TextBox ID="txtD2ID" runat="server" /></td>
                            <td>
                                <asp:Button ID="btnDReinstate" runat="server" Text="Reinstate" OnClick="btnDReinstate_Click" BackColor="#009933" BorderColor="White" Font-Bold="True" ForeColor="White" Height="30px" />
                            </td>
                            <td>
                                <asp:HiddenField ID="hfindex" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
