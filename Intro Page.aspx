<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Intro Page.aspx.cs" Inherits="WEB_Project.Intro_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Intro Page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Common.css" />
</head>
<body style="background-image:url('introback.jpg')">
    <form id="form1" runat="server">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

        <div class="navbar">
            <a class="active" href="Intro Page.aspx" style="font-family: Arial"><i class="fa fa-home" aria-hidden="true"></i> Home</a>
            <a href="Reports.aspx" style="font-family: Arial"><i class="fa fa-bar-chart" aria-hidden="true"></i> Reports</a>
            <a href="ReportMap.aspx" style="font-family: Arial"><i class="fa fa-map-o" aria-hidden="true"></i> Map</a>
            <a href="Login Page.aspx" style="float: right;font-family:Arial"><i class="fa fa-fw fa-user"></i> Login</a>
        </div>
        <div>
        </div>
    </form>
</body>
</html>
