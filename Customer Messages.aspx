<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer Messages.aspx.cs" Inherits="WEB_Project.Customer_Messages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Messages</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Common.css" />
</head>
<body style="background-image:url('cracc.jpg')">
    <form id="form1" runat="server">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

        <div class="navbar">
            <a class="active" href="Keels HomePage.aspx" style="font-family: Arial"><i class="fa fa-arrow-left" aria-hidden="true"></i> Back</a>
        </div>
        <asp:HiddenField ID="hfindex" runat="server" />
        <div style="position:absolute;left:40%">
            <div>
                <h4 style="color:white;font-weight:bold">Need to Reply</h4>
                <asp:GridView ID="gvreply" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvreply_SelectedIndexChanged" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
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
                
                <h4 style="color:white;font-weight:bold">Select a Message to Reply</h4>
                <table>
                    <tr>
                        <td style="background-color:white;"><asp:Label ID="lblmsg1" runat="server" Text="Select a Message"></asp:Label></td>
                        <td><asp:TextBox ID="txtrply1" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btnreply" Text="Reply" runat="server" OnClick="btnreply_Click"  BackColor="#009933" BorderColor="White" Font-Bold="True" ForeColor="White" Height="30px"/></td>
                    </tr>
                </table>
            </div>
            <br /><br />
            <div>
                <h4 style="color:white;font-weight:bold">Replied Messages</h4>
                <asp:GridView ID="gvnotreply" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvnotreply_SelectedIndexChanged" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
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
                
                <h4 style="color:white;font-weight:bold">Select a Message to Delete Reply</h4>
                <table>
                    <tr>
                        <td style="background-color:white;"><asp:Label ID="lblmsg" runat="server" Text="Select a Message"></asp:Label></td>
                        <td><asp:TextBox ID="txtrply" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btndelete" Text="Delete" runat="server" OnClick="btndelete_Click"  BackColor="#009933" BorderColor="White" Font-Bold="True" ForeColor="White" Height="30px" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
