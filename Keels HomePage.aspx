<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Keels HomePage.aspx.cs" Inherits="WEB_Project.Keels_HomePage1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Keels Home Page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Common.css" />
    <style type="text/css">
        .auto-style1 {
            width: 80%;
            height: 600px;
        }
    </style>

</head>
<body>
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script>
        $(document).ready(function () {
            let srilanka = new google.maps.LatLng(7.8731, 80.7718);
            let mapCanvas = document.getElementById("map");
            let mapOptins = { center: srilanka, zoom: 8 };
            let map = new google.maps.Map(mapCanvas, mapOptins);

            let ordersDt = JSON.parse(document.getElementById("hflati").value);
            let buyingMarkerImgUrl = "icons8-marker-b-50.png";
            let notBuyingMarkerImgUrl = "icons8-marker-off-50.png";

            for (let i = 0; i < ordersDt.length; i++) {
                let marker = null;
                if (ordersDt[i].Status == null) {
                    marker = new google.maps.Marker({
                        position: {
                            lat: parseFloat(ordersDt[i].Latitude),
                            lng: parseFloat(ordersDt[i].Longitude)
                        },
                    });
                    marker.setMap(map);
                } else {

                    let customIco = ordersDt[i].Status == "Buying" ? buyingMarkerImgUrl : notBuyingMarkerImgUrl;

                    marker = new google.maps.Marker({
                        position: {
                            lat: parseFloat(ordersDt[i].Latitude),
                            lng: parseFloat(ordersDt[i].Longitude),
                            icon: customIco,
                        },
                    });
                    
                }
                marker.setMap(map);                
            }
        });


    </script>
    <form id="form1" runat="server">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

        <div class="navbar">
            <a class="active" href="Keels HomePage.aspx" style="font-family: Arial"><i class="fa fa-truck" aria-hidden="true"></i> Keels</a>
            <a href="Customer Messages.aspx" style="font-family: Arial"><i class="fa fa-comments-o" aria-hidden="true"></i> Messages</a>
            <a href="Keels Charts.aspx" style="font-family: Arial"><i class="fa fa-bar-chart" aria-hidden="true"></i> Reports</a>
            <a href="Login Page.aspx" style="font-family: Arial; float: right"><i class="fa fa-fw fa-user"></i> Logout</a>
        </div>
        <div style="padding-left: 15%">
            <br />
            <br />
            <div id="map" class="auto-style1"></div>
            <script>               

                function myMap() {
                    //let srilanka = new google.maps.LatLng(7.8731, 80.7718);
                    ////let mycenter = new google.maps.LatLng(6.9271, 79.8612);
                    //let mapCanvas = document.getElementById("map");
                    //let mapOptins = { center: srilanka, zoom: 8 };
                    //let map = new google.maps.Map(mapCanvas, mapOptins);

                    //let ordersDt = JSON.parse(document.getElementById("hflati").value);

                    //for (let i = 0; i < ordersDt.length; i++) {
                    //    let marker = new google.maps.Marker({
                    //        position: {
                    //            lat: parseFloat(ordersDt[i].Latitude),
                    //            lng: parseFloat(ordersDt[i].Longitude)
                    //        },
                    //    });
                    //    marker.setMap(map);
                    //}


                    //let infowindow = new google.maps.InfoWindow({

                    //    content: '<form action="Google Map.aspx" method="POST" enctype="multipart/form-data"><table><tr><td>Latitude:</td><td><input type="text" name="latval" id="latval" disabled value="' + mycenter.lat() + '" /><input type="hidden" name="lathid" value="' + mycenter.lat() + '" /></td></tr><tr><td>Longitude:</td><td><input type="text" name="lngval" id="lngval" disabled value="' + mycenter.lng() + '" /><tr><td><button type="submit">Submit</button></td></tr></table></form>'
                    //});
                    //google.maps.event.addListener(marker, 'click', function () {
                    //    infowindow.open(map, marker);
                    //});
                }
            </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAWH-XTux9pCrmqDoV6YM63Ex8FPrAQNLU&callback=myMap"></script>

    </div>
        <div style="padding-left:115px">
            <br />
            <br />
            <asp:GridView ID="Orders" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="Orders_SelectedIndexChanged" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="National_ID" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Latitude" HeaderText="Latitude" />
                    <asp:BoundField DataField="Longitude" HeaderText="Longitude" />
                    <asp:BoundField DataField="Selling" HeaderText="Type" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:ImageField DataImageUrlField="Image" HeaderText="Image">
                    </asp:ImageField>
                    <asp:BoundField DataField="Status" HeaderText="Status_is" />
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
    <br />
    <br />
    <div style="padding-left: 40%">
        <table>
            <tr>
                <td style="color: white; font-weight: bold">ID Number: </td>
                <td>
                    <asp:TextBox ID="nic" runat="server" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="color: white; font-weight: bold">Status: </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="stat" ForeColor="White">
                        <asp:ListItem>Buying</asp:ListItem>
                        <asp:ListItem>Not Buying</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" BackColor="#009933" BorderColor="White" Font-Bold="True" ForeColor="White" Height="30px" /></td>
            </tr>
        </table>   
    </div>
    <asp:HiddenField ID="hflati" runat="server" />
    </form>
</body>
</html>
