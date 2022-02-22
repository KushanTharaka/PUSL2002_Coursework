<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Keels Charts.aspx.cs" Inherits="WEB_Project.Keels_Charts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Keels Charts</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Common.css" />
</head>
<body>
    <form id="form1" runat="server">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

        <div class="navbar">
            <a class="active" href="Keels HomePage.aspx" style="font-family: Arial"><i class="fa fa-arrow-left" aria-hidden="true"></i> Back</a>
        </div> 
        <br />
        <div>
            <h2 style="color:white;font-weight:bold;padding-left:43%">Farmer Reports</h2>
            <div style="float:left;padding-left:20%;padding-top:5%">
                <asp:Chart ID="BarChart" runat="server">
                    <Series>
                        <asp:Series Name="Series1" ChartType="StackedColumn"></asp:Series>
                    </Series>
                    <Titles>
                        <asp:Title Docking="Bottom" Text="What is Selling"></asp:Title>
                    </Titles>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
            <div style="float:right;padding-right:20%;padding-top:5%">
                <asp:Chart ID="PieChart" runat="server">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
                    </Series>
                    <Titles>
                        <asp:Title Docking="Bottom" Text="How many farmers placed orders"></asp:Title>
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
