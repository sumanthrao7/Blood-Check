<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="BloodCheck.Manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Blood check</title>
    <link href="content/css/bloodCheck.css" rel="stylesheet" />
    <link href="content/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
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
                <div class="col-md-8" style="align-content:center">
                    <div class="headerDiv" style="width:110%;margin-left:-15px; margin-right:-50px;  margin-top: -25px;">
                        <h3 class="txt">MANAGE INVENTORY</h3>
                    </div>
                    <div>
                        <table style="margin-top:10px">
                            <tr><td><h5><b>Select blood type </b></h5></td> <td> &nbsp<asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlList_SelectedIndexChanged" ID="ddlList" Width="100px" runat="server"></asp:DropDownList></td></tr>
                            <tr><td><h5>Available Units </h5></td><td><asp:Label ID="lblAvailable" runat="server" Text=""></asp:Label></td></tr>
                            <tr><td><h5>Enter Units: </h5></td><td><asp:TextBox ID="txtNewUnits" runat="server"></asp:TextBox></td></tr>
                            <tr><td><asp:Button ID="btnAdd" OnClick="btnAdd_Click" CssClass="btn btn-default" runat="server" Text="Add Units" /></td><td><asp:Button CssClass="btn btn-default" ID="btnDelete" OnClick="btnDelete_Click" runat="server" Text="Delete Units" /></td></tr>
                        </table>   
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
