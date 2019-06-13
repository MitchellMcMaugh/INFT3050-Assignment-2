<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="03loginPage.aspx.cs" Inherits="INFT3050_Assignment_2.WebForm11" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css">
</head>
<body>
    <form id="form1" runat="server">
    <!-- Header -->
    <div>
        <h1 style="margin: 10px;">B.E.T.T.E.R</h1>
    </div>
    <!-- End Header -->

    <div style="margin: 10px;">
        Login Here<br />
    </div>

    <!-- Login Options -->
    <div style="margin-left:10px;">
        <br />
        <asp:Label ID="lblLogin_email" runat="server" Text="E-mail:"></asp:Label>
        <br />
        <asp:TextBox ID="txtLogin_email" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblLogin_password" runat="server" Text="Password:"></asp:Label>
        <br />
        <asp:TextBox ID="txtLogin_password" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btn_Login2" runat="server" Text="Login" OnClick="btn_Login2_Click" />
        <br />
        <br />
    </div>
    <!-- End Login Options -->

    <!-- Register Instead -->
    <div style="margin-left:10px;">
        Don't have an account? Register <asp:HyperLink ID="hyp_Register" runat="server" NavigateUrl="~/02registrationPage.aspx">here</asp:HyperLink>.
    </div>
    <!-- End Register Instead -->

    </form>
</body>
</html>
