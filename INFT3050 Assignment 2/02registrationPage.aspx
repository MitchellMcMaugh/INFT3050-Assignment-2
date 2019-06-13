<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="02registrationPage.aspx.cs" Inherits="INFT3050_Assignment_2.WebForm10" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
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
        Register a new account here.<br /><br />
    </div>

    <!-- Register Options -->
    <div style="margin: 10px;">
        
        <!-- Login -->
        <asp:Label ID="lblRegister_login" runat="server" Text="Login:"></asp:Label>
        <br />
        <asp:TextBox ID="txtRegister_login" runat="server" style="text-align: left" TabIndex="1"></asp:TextBox>
            <asp:RequiredFieldValidator id="loginValidator" runat="server"
                ControlToValidate="txtRegister_login"
                ErrorMessage="This is a required field."
                ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <br />

        <!-- First Name -->
        <asp:Label ID="lblRegister_firstName" runat="server" Text="First Name:"></asp:Label>
            <br />
        <asp:TextBox ID="txtRegister_firstName" runat="server" style="text-align: left" TabIndex="1"></asp:TextBox>
            <asp:RequiredFieldValidator id="firstNameValidator" runat="server"
                ControlToValidate="txtRegister_firstName"
                ErrorMessage="This is a required field."
                ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <br />

        <!-- Surname -->
        <asp:Label ID="lblRegister_surname" runat="server" Text="Surname:"></asp:Label>
            <br />
        <asp:TextBox ID="txtRegister_surname" runat="server" style="text-align: left" TabIndex="1"></asp:TextBox>
            <asp:RequiredFieldValidator id="surnameValidator" runat="server"
                ControlToValidate="txtRegister_surname"
                ErrorMessage="This is a required field."
                ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <br />

        <!-- Date Of Birth -->
        <asp:Label ID="lblRegister_dob" runat="server" Text="Date of birth:"></asp:Label>
            <br />
        <asp:TextBox ID="txtRegister_dob" runat="server" style="text-align: left" TabIndex="1" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator id="dobValidator" runat="server"
                ControlToValidate="txtRegister_dob"
                ErrorMessage="This is a required field."
                ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <br />

        <!-- E-Mail -->
        <asp:Label ID="lblRegister_email" runat="server" Text="E-mail:"></asp:Label>
            <br />
        <asp:TextBox ID="txtRegister_email" runat="server" style="text-align: left" TabIndex="1" TextMode="Email"></asp:TextBox>
            <asp:RequiredFieldValidator id="emailValidator" runat="server"
                ControlToValidate="txtRegister_email"
                ErrorMessage="This is a required field."
                ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <br />

        <!-- Password -->
        <asp:Label ID="lblRegister_password" runat="server" Text="Password:"></asp:Label>
            <br />
        <asp:TextBox ID="txtRegister_password" runat="server" style="text-align: left" TextMode="Password"></asp:TextBox>
            
            <asp:RequiredFieldValidator id="passwordValidator" runat="server"
                ControlToValidate="txtRegister_password"
                ErrorMessage="This is a required field."
                ForeColor="Red">
            </asp:RequiredFieldValidator>
            <br />
            <br />
        
        <!-- Confirm Password -->
        <asp:Label ID="lblRegister_passwordConfirm" runat="server" Text="Confirm Password:"></asp:Label>
            <br />
        <asp:TextBox ID="txtRegister_passwordConfirm" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator id="confirmPasswordValidator" runat="server"
                ControlToValidate="txtRegister_passwordConfirm"
                ErrorMessage="This is a required field."
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        
        <br />
        <br />
        <asp:Button ID="btn_register" runat="server" OnClick="btn_register_Click1" Text="Register" />
        <br />
        <br />
        <br />
    </div>
    <!-- End Register Options -->

    <!-- Login Instead -->
    <div style="margin: 10px;">
        Already have an account? Login <asp:HyperLink ID="hyp_Login" runat="server" NavigateUrl="~/03loginPage.aspx">here</asp:HyperLink>.
    </div>
    <!-- End Login Instead -->
    </form>
</body>
</html>
