<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportMap.aspx.cs" Inherits="WEB_Project.ReportMap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ReportMap</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Common.css" />
    <style type="text/css">
        .auto-style1 {
            width: 80%;
            height: 550px;
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
            let buyingMarkerImgUrl = 'icons8-marker-b-50.png';
            let notBuyingMarkerImgUrl = 'icons8-marker-off-50.png';

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
            <a class="active" href="Intro Page" style="font-family: Arial"><i class="fa fa-arrow-left" aria-hidden="true"></i> Back</a>
            <a href="Reports.aspx" style="font-family: Arial"><i class="fa fa-bar-chart" aria-hidden="true"></i> Reports</a>
            <a href="Login Page.aspx" style="font-family: Arial; float: right;"><i class="fa fa-fw fa-user"></i> Login</a>
        </div>
        <br />
            
        <div style="padding-left: 15%">

            <div id="map" class="auto-style1"></div>
            <h4 style="color:white;font-weight:bold;padding-left:25%">Farmers who are selling Vegetables and Fruits</h4>
            </div>
            <script>               

                function myMap() {
                    
                }
            </script>
            <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAWH-XTux9pCrmqDoV6YM63Ex8FPrAQNLU&callback=myMap"></script>
            <asp:HiddenField ID="hflati" runat="server" />
    </form>

</body>
</html>
