<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="16exerciseConfirmed.aspx.cs" Inherits="INFT3050_Assignment_2.WebForm16" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Steps Submitted</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css">
</head>
<body>
    <form id="form1" runat="server">

    <!-- Header -->
    <div>
        <h1 style="margin: 10px;">B.E.T.T.E.R</h1>
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

    <!-- Confirmation -->
    <div style="margin: 10px;">
        </br> Congratulations! You have gained [Exercise points] amount of points with your steps today!
    </div>
    <!-- End Confirmation -->

    </form>
</body>
</html>
