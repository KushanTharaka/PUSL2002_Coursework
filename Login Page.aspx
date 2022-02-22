<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login Page.aspx.cs" Inherits="WEB_Project.Login_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Login Page.css" />
    <link rel="stylesheet" href="Common.css" />
</head>
<body style="background-image:url('loginpage.jpg')">
    <form id="form1" runat="server">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

        <div class="navbar">
            <a class="active" href="Intro Page.aspx" style="font-family: Arial"><i class="fa fa-arrow-left" aria-hidden="true"></i> Back</a>
            <a href="Reports.aspx" style="font-family: Arial"><i class="fa fa-bar-chart" aria-hidden="true"></i> Reports</a>
            <a href="Login Page.aspx" style="float: right; font-family: Arial"><i class="fa fa-fw fa-user"></i> Login</a>
        </div>
        <div style="position: absolute; top: 53%; left: 50%; transform: translate(-50%, -50%);background-color:#62bb46;height:400px;width:350px;border-radius:15px">
            <h2 style="font-weight:bold;padding-top:4px;padding-left:15%">Login..</h2> 
            <div style="padding-left:4%;padding-top:3%">
                <table style="border-collapse: separate; border-spacing: 20px;">
                    <tr>
                        <td style="font-weight: bold">Username:
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" BorderColor="White" />
                            <asp:RequiredFieldValidator ID="rfvUser" ErrorMessage="Please Enter Username" ControlToValidate="txtUserName" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">Password:
                        </td>
                        <td>
                            <asp:TextBox ID="txtPWD" runat="server" TextMode="Password" BorderColor="White" />
                            <asp:RequiredFieldValidator ID="rfvPWD" runat="server" ControlToValidate="txtPWD" ErrorMessage="Please Enter Password" ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:DropDownList ID="acctype" runat="server">
                                <asp:ListItem Value="Select">Select Account Type</asp:ListItem>
                                <asp:ListItem Value="Farmer">Farmer</asp:ListItem>
                                <asp:ListItem Value="Keels">Keells Staff Member</asp:ListItem>
                                <asp:ListItem Value="DoA">DoA Staff Member</asp:ListItem>
                                <asp:ListItem>WebMaster</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="acctype" ErrorMessage="Account Type Required !!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="submit" Font-Bold="True" BorderColor="White" Height="30px" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><a href="Create Account.aspx" style="font-weight: bold">Create an Account</a></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
