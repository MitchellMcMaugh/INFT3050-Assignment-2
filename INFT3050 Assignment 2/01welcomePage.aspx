<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="01welcomePage.aspx.cs" Inherits="INFT3050_Assignment_2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Better!</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css">
</head>
<body>
    <form id="form1" runat="server">
        <!-- Header -->
        <div>
            <h1 style="margin: 10px;">B.E.T.T.E.R</h1>
        </div>
        <!-- End Header -->

        <!-- About -->
        <div style="margin: 10px;">
        Welcome to&nbsp; Battling Elemental Titans Through Exercising Routines.<br />
        <br />
        Login or create an account to access this website and start having fun and getting healthy today!<br />
        </div>
        <!-- End About -->

        <!-- Login/ Register Buttons -->
        <div style="margin: 10px;">
        <asp:Button ID="btn_Login" runat="server" Text="Login" PostBackUrl="~/03loginPage.aspx" Height="30px" Width="100px" />
        </br>
        </br>
        <asp:Button ID="btn_Register" runat="server" Text="Register" PostBackUrl="~/02registrationPage.aspx" Height="30px" Width="100px" />
        </div>
        <!-- End Login/ Register Buttons -->

    </form>
</body>
</html>
