<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="04home.aspx.cs" Inherits="INFT3050_Assignment_2.WebForm12" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css">
</head>
<body>
    <form id="form1" runat="server">
    <!-- Header -->
    <div>
        <h1 style="margin: 10px; width: 224px;">B.E.T.T.E.R</h1>
        <asp:Label ID="Label1" runat="server" Text="Label" CssClass="Login"></asp:Label>
    </div>
    <!-- End Header -->

    <!-- Menu -->
    <div>
        <ul>
            <li><a class="active" href="04home.aspx">Home</a></li>
            <li class="dropdown">
                <a href="#" class="dropbtn">Characters</a>
                    <div class="dropdown-content">
                        <a href="06characterManagement.aspx">Manage Characters</a>
                        <a href="13characterLevelling.aspx">Level Up Character</a>
                    </div>
                <li><a href="08challenges.aspx">Challenges</a></li>
                <li><a href="07hallOfFame.aspx">Hall of Fame</a></li>
                <li><a href="12exercise.aspx">Exercise</a></li>
                <li><a href="14logout.aspx">Logout</a></li>
            </li>
        </ul>
    </div>
    <!-- End Menu -->

    <!-- About -->
    <div style="margin: 10px;">
        <br />Welcome to the NewU B.E.T.T.E.R website.<br /><br />
    </div>
    <!-- End About -->

    <!-- Battle History -->
    <div style= "padding-left: 10px";>
        </br> </br>

        <br />
        <asp:Label ID="lbl_hiddenLabel" runat="server" Text="Label" Visible="False"></asp:Label>
        </br>
    </div>
    <!-- End Battle History -->
    </form>
</body>
</html>
