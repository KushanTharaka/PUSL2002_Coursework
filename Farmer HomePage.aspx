<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Farmer HomePage.aspx.cs" Inherits="WEB_Project.Farmer_s_HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Common.css" />
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAWH-XTux9pCrmqDoV6YM63Ex8FPrAQNLU&callback=map"></script>
    <script src="https://unpkg.com/location-picker/dist/location-picker.min.js"></script>
    <style type="text/css">
        #map {
            width: 50%;
            height: 480px;
        }
        .auto-style1 {
            height: 24px;
        }
        .auto-style2 {
            height: 68px;
        }
        .auto-style3 {
            float: left;
            width: 420px;
        }
        .auto-style4 {
            float: right;
            width: 320px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

        <div class="navbar">
            <a class="active" href="Farmer HomePage.aspx" style="font-family: Arial"><i class="fa fa-male" aria-hidden="true"></i> Farmer</a>
            <a href="Messages.aspx" style="font-family: Arial"><i class="fa fa-comments-o" aria-hidden="true"></i> Messages</a>
            <a href="Login Page.aspx" style="font-family: Arial; float: right;"><i class="fa fa-fw fa-user"></i> Logout</a>
        </div>
        <div>
            <br />
            <br />
            <br />
            <div id="map" style="float:left; padding-left:30px"></div>
            <br />
            <br />
            <p style="color:white;font-weight:bold;float:right">Current position: <span id="onIdlePositionView"></span></p>
            <script>
                // Get element references
                var confirmBtn = document.getElementById('confirmPosition');
                var onIdlePositionView = document.getElementById('onIdlePositionView');

                // Initialize locationPicker plugin
                var lp = new locationPicker('map', {
                    setCurrentPosition: true, // You can omit this, defaults to true
                }, {
                    zoom: 8 // You can set any google map options here, zoom defaults to 15
                });


                // Listen to map idle event, listening to idle event more accurate than listening to ondrag event
                google.maps.event.addListener(lp.map, 'idle', function (event) {
                    // Get current location and show it in HTML
                    var location = lp.getMarkerPosition();
                    onIdlePositionView.innerHTML = 'The chosen location is ' + location.lat + ',' + location.lng;
                    var lati = location.lat;
                    var longi = location.lng;
                    document.getElementById('<%=hflati.ClientID%>').value = lati;
                    document.getElementById('<%=hflongi.ClientID%>').value = longi;
                });
            </script>
            <div style="padding-right:80px">
                <div style="padding-right: 150px;" class="auto-style4">
                    <asp:HiddenField ID="hflati" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="hflongi" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="hfuname" runat="server" />
                    <table>
                        <tr>
                            <td style="color: white; font-weight: bold">Latitude: </td>
                            <td>
                                <asp:TextBox ID="tflati" runat="server" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="color: white; font-weight: bold">Longitude: </td>
                            <td>
                                <asp:TextBox ID="tflongi" runat="server" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="color: white; font-weight: bold">National ID: </td>
                            <td>
                                <asp:TextBox ID="tfnic" runat="server" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="color: white; font-weight: bold" class="auto-style1">Name: </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="tfname" runat="server" ReadOnly="True" Width="129px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="click" runat="server" Text="Get Location and Farmer Details" OnClick="click_Click" BackColor="#009933" BorderColor="White" Font-Bold="True" ForeColor="White" Height="30px" /></td>
                        </tr>
                    </table>
                    <br />
                    <table>
                        <tr>
                            <td style="color: white; font-weight: bold">What are you selling? </td>
                            <td>
                                <asp:RadioButtonList runat="server" ID="Type" ForeColor="White">
                                    <asp:ListItem>Vegetable</asp:ListItem>
                                    <asp:ListItem>Fruit</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: white; font-weight: bold" class="auto-style2">Description: </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="tfdescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: white; font-weight: bold">Insert an Image: </td>
                            <td>
                                <asp:FileUpload ID="imgup" runat="server" BorderColor="White" Font-Bold="True" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" BackColor="#009933" BorderColor="White" Font-Bold="True" ForeColor="White" Height="30px" /></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div style="padding-right:40%" class="auto-style3">
            <div>
                <br />
                <br />
                <br />
                <asp:GridView ID="Order" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateSelectButton="True" OnSelectedIndexChanged="Order_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="National_ID" HeaderText="ID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Latitude" HeaderText="Latitude" />
                        <asp:BoundField DataField="Longitude" HeaderText="Longitude" />
                        <asp:BoundField DataField="Selling" HeaderText="Type" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:ImageField DataImageUrlField="Image" HeaderText="Image">                      
                        </asp:ImageField>
                        <asp:BoundField DataField="Status" HeaderText="Status" />
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
                <br />
                <br />
                <table>
                    <tr>
                        <td style="color: white; font-weight: bold">Delete Order: </td>
                        <td><asp:TextBox ID="tfid" runat="server" ReadOnly="True"></asp:TextBox></td>
                        <td><asp:Button ID="btndelete" runat="server" Text="Delete Order" OnClick="btndelete_Click" BackColor="#009933" Font-Bold="True" ForeColor="White" Height="30px" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
