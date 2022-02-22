<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebMaster HomePage.aspx.cs" Inherits="WEB_Project.WebMaster_HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Common.css" />
    <script src="https://use.fontawesome.com/bd38d3102d.js"></script>
</head>
<body style="background-image:url('cracc.jpg');">
    <form id="form1" runat="server">
        <div>
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

            <div class="navbar">
                <a href="WebMaster HomePage.aspx" style="font-family:Arial"><i class="fa fa-fw fa-back"></i> Web Master</a>
                <a href="Login Page.aspx" style="float:right;font-family:Arial"><i class="fa fa-fw fa-user"></i> Logout</a>
            </div>
        </div>
        <div style="position: absolute; top: 53%; left: 50%; transform: translate(-50%, -50%);background-color:#62bb46;height:400px;width:350px;border-radius:15px">
            <div style="padding-left:30%;padding-top:20%; border-collapse: separate; border-spacing: 20px;">
                <br />
                <div style="padding-left:0px">
                    <asp:Button ID="btncreateacc" runat="server" Text="Create Account" OnClick="btncreateacc_Click" Font-Bold="True" Font-Size="15px" Height="40px" BorderColor="White" BackColor="white" /></div>
                <br /><br /><br />
                <div style="padding-right:30px">
                    <asp:Button ID="btnrevacc" runat="server" Text="Revoke and Reinstate" OnClick="btnrevacc_Click" Font-Bold="True" Font-Size="15px" Height="40px" BorderColor="White" BackColor="white" /></div>
                <br /><br /><br />
                <div>
                    <asp:Button ID="btnrep" runat="server" Text="Reports" Font-Bold="True" Font-Size="15px" Height="40px" BorderColor="White" BackColor="white" OnClick="btnrep_Click" /></div>
                <br />
            </div>
        </div>
    </form>
</body>
</html>
