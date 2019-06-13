<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="12exercise.aspx.cs" Inherits="INFT3050_Assignment_2.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exercise</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css">
</head>
<body>
    <form id="form1" runat="server">
    
    <!-- Header -->
    <div>
        <h1 style="margin: 10px;">B.E.T.T.E.R</h1>
        <asp:Label ID="Label3" runat="server" Text="Label" CssClass="Login"></asp:Label>
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

    <!-- Exercise Input -->
    <div style="margin: 10px;">
        Enter your steps walked today. Enter your parental E-mail code to verify these steps.<br />
    </div>
    <div style="margin: 10px;">
        <asp:Label ID="lblSteps" runat="server" Text="Steps:"></asp:Label></br>
        <asp:TextBox ID="txtSteps" runat="server"></asp:TextBox></br></br>
        <asp:Label ID="lblStepsCode" runat="server" Text="E-mail Code:"></asp:Label></br>
        <asp:TextBox ID="txtStepsCode" runat="server"></asp:TextBox>

        </br>
        <br />
        <asp:Button ID="btn_sendCode" runat="server" OnClick="btn_sendCode_Click" Text="Send Code" />
        </br>
        </br>
        <asp:Button ID="btnSubmitSteps" runat="server" Text="Submit" OnClick="btnSubmitSteps_Click" Width="96px" />
    </div>
    <!-- End Exercise Input -->

    </form>
</body>
</html>
