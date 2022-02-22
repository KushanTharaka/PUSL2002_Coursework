<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebMaster Charts.aspx.cs" Inherits="WEB_Project.WebMaster_Charts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Account Charts</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Common.css" />
</head>
<body>
    <form id="form1" runat="server">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

            <div class="navbar">
                <a href="WebMaster HomePage.aspx" style="font-family:Arial"><i class="fa fa-arrow-left" aria-hidden="true"></i> Back</a>
                <a href="Login Page.aspx" style="float:right;font-family:Arial"><i class="fa fa-fw fa-user"></i> Logout</a>
            </div>
        <br />
        <div>
            <h1 style="color:white;font-weight:bold;padding-left:41%">Account Details</h1>
            <div style="float:left;padding-left:100px;padding-top:5%">
                <asp:Chart ID="Chart1" runat="server">
                    <Series>
                        <asp:Series Name="Series1" ChartType="StackedColumn"></asp:Series>
                    </Series>
                    <Titles>
                        <asp:Title Docking="Bottom" Text="Farmer Accounts"></asp:Title>
                    </Titles>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
            <div style="float:right;padding-right:115px;padding-top:5%">
                <asp:Chart ID="Chart2" runat="server">
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <Titles>
                        <asp:Title Docking="Bottom" Text="Keels Accounts"></asp:Title>
                    </Titles>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
            <div style="float:right;padding-right:100px;padding-top:5%">
                <asp:Chart ID="Chart3" runat="server">
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <Titles>
                        <asp:Title Docking="Bottom" Text="DoA Accounts"></asp:Title>
                    </Titles>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
        </div>
    </form>
</body>
</html>
