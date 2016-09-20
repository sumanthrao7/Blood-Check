<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="BloodCheck.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Blood check</title>
    <link href="content/css/bloodCheck.css" rel="stylesheet" />
    <link href="content/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body >
    <form id="form1"  runat="server">
        <div>
            <img style="margin-left:40%" src="content/images/bloodLogo.JPG" />
        </div>
        <div style="background-color:#ffe6e6; height:600px;" >
            <div  class="modal-body row">
                <div class="col-md-2" style="height:600px; background-color:#ff9999; margin-top: -14px;">
                    <div class="headerDiv" style="width: 240px;">
                        <h3 class="txt">SELECT AN OPTION</h3>
                    </div>
                
                <ul id="sideBar" style="list-style-type: none; ">
                  
                  <li><a class="abc" id="aDashBoard" href="Dashboard.aspx">Dashboard</a></li>
                  <li><a class="abc" id="aManage" href="Manage.aspx">Manage Inventory</a></li>

                </ul>
                    </div>
                <div class="col-md-8">
                    <div class="headerDiv" style="width:110%;margin-left:-15px; margin-right:-50px;  margin-top: -25px;">
                        <h3 class="txt">CURRENT BLOOD AVAILABILITY</h3>
                    </div>
                    <div runat="server" class="content">
                        <%=getInventoryDetails() %>
                    </div>
                </div>
                <div class="col-md-2" style="height:600px; background-color:#ff9999; margin-top: -14px;">
                    <div class="headerDiv" style="width:240px; margin-left:-15px;  ">
                        <h3 class="txt">NOTIFICATIONS</h3>
                    </div>
                    <div style="margin-top:10px;">
                        <%=getNotifications() %>
                    </div>

                </div>
             </div>
         </div>
    </form>
</body>
</html>
