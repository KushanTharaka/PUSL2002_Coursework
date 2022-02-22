<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="WEB_Project.Messages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Messages</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Common.css" />
    <style type="text/css">
        .auto-style1 {
            position: center;
            left: 50%;
            width: 371px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

            <div class="navbar">
                <a class="active" href="Farmer HomePage.aspx" style="font-family: Arial"><i class="fa fa-arrow-left" aria-hidden="true"></i> Back</a>
            </div>
            <br /><br /><br />
        <div>           
            <div style="position: absolute; top: 53%; left: 30%; transform: translate(-50%, -50%);background-color:#62bb46;height:400px;width:350px;border-radius:15px">
                <h2 style="font-weight:bold;padding-left:10%">  Write a Message</h2>
                <div style="padding-left:8%; padding-bottom:30%">
                
                <table style="border-collapse: separate; border-spacing: 20px;">
                    <tr>
                        <td style="font-weight:bold">Your Name:- </td>
                        <td><asp:TextBox ID="txtname" runat="server" ReadOnly="True" BorderColor="White" /></td>
                    </tr>
                    <tr>
                        <td style="font-weight:bold">Your NIC No:- </td>
                        <td><asp:TextBox ID="txtnic" runat="server" ReadOnly="True" BorderColor="White" /></td>
                    </tr>
                    <tr>
                        <td style="font-weight:bold">Message:- </td>
                        <td><asp:TextBox ID="txtmsg" runat="server" TextMode="MultiLine" BorderColor="White" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnautofill" runat="server" Text="Auto Fill" OnClick="btnautofill_Click" Font-Bold="True" BorderColor="White" Height="30px" />                          
                        </td>
                        <td><asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" Font-Bold="True" BorderColor="White" Height="30px" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Button ID="btnclr" runat="server" Text="Clear" OnClick="btnclr_Click" Font-Bold="True" BorderColor="White" Height="30px" /></td>
                    </tr>
                </table>
               </div>
            </div>
            <br /><br />
            <div style="float:right;padding-right:20%">
            <div>
                <h2 style="color:white;font-weight:bold">Messages You Sent</h2>
                <asp:GridView ID="Messagegv" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="Message_SelectedIndexChanged" AutoGenerateSelectButton="True" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                    <Columns>
                        <asp:BoundField DataField="National_Id" HeaderText="National ID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Message" HeaderText="Message" ItemStyle-Wrap="true" ItemStyle-Width="50px" />
                        <asp:BoundField DataField="Reply" HeaderText="Reply" ItemStyle-Wrap="true" ItemStyle-Width="50px" />
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
            </div>
            <div>
                <asp:HiddenField ID="indexrow" runat="server" />
            </div>
            <br /><br />
            <div>
                <table style="border-collapse: separate; border-spacing: 20px;">
                    <tr>
                        <td style="color:white;font-weight:bold">Sent Message:- </td>
                        <td><asp:TextBox ID="tfmsg" runat="server" TextMode="MultiLine" ReadOnly="true" Text="Select a Message"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="color:white;font-weight:bold">Message Reply:- </td>
                        <td><asp:TextBox ID="tfreply" runat="server" TextMode="MultiLine" ReadOnly="true" Text="Select a Message"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btndelete" Text="Delete Message" runat="server" OnClick="btndelete_Click" BackColor="#009933" BorderColor="White" Font-Bold="True" ForeColor="White" Height="30px" /></td>
                        <td><asp:Button ID="btnclear" Text="Clear Message" runat="server" OnClick="btnclear_Click" BackColor="#009933" BorderColor="White" Font-Bold="True" ForeColor="White" Height="30px" /></td>
                    </tr>
                </table>
            </div>
          </div>
        </div>
        <asp:HiddenField ID="hfuname" runat="server" />
    </form>
</body>
</html>
