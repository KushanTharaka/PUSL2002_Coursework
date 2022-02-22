<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create Account.aspx.cs" Inherits="WEB_Project.Create_Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Account</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Common.css" />
</head>
<body style="background-image:url('cracc.jpg')">
    <form id="form1" runat="server">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

        <div class="navbar">
            <a class="active" href="Intro Page.aspx" style="font-family: Arial"><i class="fa fa-arrow-left" aria-hidden="true"></i> Back</a>
            <a href="Login Page.aspx" style="float: right;font-family:Arial"><i class="fa fa-fw fa-user"></i> Login</a>
        </div>
        
        <div style="position:absolute;top:50%;left:50%;transform:translate(-50%, -50%);background-color:#62bb46;height:500px;border-radius:15px">
            <h2 style="font-weight:bold;padding-top:4px;padding-left:17%">Create Farmer Account</h2>
            <div style="padding-left:15%;padding-top:9%">
                
            <table style="border-collapse: separate; border-spacing: 7px;">
                <tr>
                    <td style="font-weight:bold">Name: 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="Name" BorderColor="White"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Name" ErrorMessage="Name Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight:bold">National_ID: 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="nic" BorderColor="White"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="nic" ErrorMessage="NIC Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight:bold">Gender: 
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
                    <td style="font-weight:bold">District: 
                    </td>
                    <td>
                        <asp:DropDownList ID="Location" runat="server">
                            <asp:ListItem Text="Select District" Value="select" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Ampara" Value="Ampara"></asp:ListItem>
                            <asp:ListItem Text="Anuradhapura" Value="Anuradhapura"></asp:ListItem>
                            <asp:ListItem Text="Badulla" Value="Badulla"></asp:ListItem>
                            <asp:ListItem Text="Batticaloa" Value="Batticaloa"></asp:ListItem>
                            <asp:ListItem Text="Colombo" Value="Colombo"></asp:ListItem>
                            <asp:ListItem Text="Galle" Value="Galle"></asp:ListItem>
                            <asp:ListItem Text="Gampaha" Value="Gampaha"></asp:ListItem>
                            <asp:ListItem Text="Hambantota" Value="Hambantota"></asp:ListItem>
                            <asp:ListItem Text="Jaffna" Value="Jaffna"></asp:ListItem>                        
                            <asp:ListItem Text="Kaluthara" Value="Kaluthara"></asp:ListItem>
                            <asp:ListItem Text="Kandy" Value="Kandy"></asp:ListItem>
                            <asp:ListItem Text="Kegalle" Value="Kegalle"></asp:ListItem>
                            <asp:ListItem Text="Kilinochchi" Value="Kilinochchi"></asp:ListItem>
                            <asp:ListItem Text="Kurunegla" Value="Kurunegala"></asp:ListItem>
                            <asp:ListItem Text="Mannar" Value="Mannar"></asp:ListItem>
                            <asp:ListItem Text="Matale" Value="Matale"></asp:ListItem>
                            <asp:ListItem Text="Matara" Value="Matara"></asp:ListItem>
                            <asp:ListItem Text="Moneragala" Value="Moneragala"></asp:ListItem>
                            <asp:ListItem Text="Mullaitivu" Value="Mullaitivu"></asp:ListItem>
                            <asp:ListItem Text="Nuwara Eliya" Value="Nuwara Eliya"></asp:ListItem>
                            <asp:ListItem Text="Polonnaruwa" Value="Polonnaruwa"></asp:ListItem>
                            <asp:ListItem Text="Puttalam" Value="Puttalam"></asp:ListItem>
                            <asp:ListItem Text="Ratnapura" Value="Ratnapura"></asp:ListItem>
                            <asp:ListItem Text="Trincomalee" Value="Trincomalee"></asp:ListItem>
                            <asp:ListItem Text="Vavuniya" Value="Vavuniya"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Location" ErrorMessage="District Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight:bold">Password: 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" BorderColor="White"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Password" ErrorMessage="Password Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button runat="server" ID="Submit" OnClick="Submit_Click" Text="Submit" BackColor="White" BorderColor="White" Font-Bold="True" ForeColor="Black" Height="30px" />
                    </td>
                </tr>
            </table>
            </div>
        </div>
    </form>
</body>
</html>
