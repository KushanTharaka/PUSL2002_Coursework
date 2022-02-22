<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff Create Account.aspx.cs" Inherits="WEB_Project.Staff_Create_Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Account Creation</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Common.css" />
</head>
<body style="background-image:url('cracc.jpg')">
    <form id="form1" runat="server">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

        <div class="navbar">
            <a class="active" href="WebMaster HomePage.aspx" style="font-family: Arial"><i class="fa fa-arrow-left" aria-hidden="true"></i> Back</a>
            <a href="Login Page.aspx" style="float: right; font-family: Arial"><i class="fa fa-fw fa-user"></i> Logout</a>
        </div>
        <div style="position: absolute; top: 50%; left: 50%; transform: translate(-50%, -50%);background-color:#62bb46;height:500px;border-radius:15px">
            <h2 style="font-weight: bold;padding-top:6px;padding-left:20%">Create Staff Account</h2>
            <div style="padding-left: 15%; padding-top: 7%">
                <table>
                    <tr>
                        <td style="font-weight: bold">Name: 
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="Name" BorderColor="White"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Name" ErrorMessage="Name Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">Staff ID: 
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="id_no" BorderColor="White"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="id_no" ErrorMessage="Staff ID Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">Gender: 
                        </td>
                        <td>
                            <asp:RadioButtonList runat="server" ID="Gender">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Gender" ErrorMessage="Gender Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">Username: 
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="Username" BorderColor="White"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Username" ErrorMessage="Username Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">Password: 
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" BorderColor="White"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Password" ErrorMessage="Password Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:DropDownList ID="acctype" runat="server">
                                <asp:ListItem Value="Select">Select Account Type</asp:ListItem>
                                <asp:ListItem Value="Keels">Keels Staff Acccount</asp:ListItem>
                                <asp:ListItem Value="DoA">DoA Staff Acccount</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Account Type Required !!" ControlToValidate="acctype" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button runat="server" ID="Submit" Text="Submit" OnClick="Submit_Click" BorderColor="White" Font-Bold="True" Height="30px" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
