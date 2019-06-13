<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="07hallOfFame.aspx.cs" Inherits="INFT3050_Assignment_2.WebForm15" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hall of Fame</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css">
</head>
<body>
    <form id="form1" runat="server">

    <!-- Header -->
    <div>
        <h1 style="margin: 10px;">B.E.T.T.E.R</h1>
        <asp:Label ID="lbl_login" runat="server" Text="Label" CssClass="Login"></asp:Label>
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

    <!-- Hall of Fame Table -->
    <div style="margin: 10px;">
    
    </div>
    <!-- End Hall of Fame Table -->

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="userCharacterId" DataSourceID="HallOfFameDataSource">
            <Columns>
                <asp:BoundField DataField="userCharacterName" HeaderText="Name" SortExpression="userCharacterName" />
                <asp:BoundField DataField="dateEntered" HeaderText="Date Entered" SortExpression="dateEntered" />
                <asp:BoundField DataField="dateCreated" HeaderText="Date Created" SortExpression="dateCreated" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="HallOfFameDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:INFT3050MitchellMcMaugh3185423ConnectionString1 %>" SelectCommand="SELECT        HallOfFame.dateEntered, HallOfFame.userCharacterId, UserCharacters.userCharacterName, UserCharacters.userCharacterLevel, UserCharacters.userCharacterStep, UserCharacters.userCharacterExperience, 
                         UserCharacters.dateCreated
FROM            UserCharacters INNER JOIN
                         HallOfFame ON UserCharacters.userCharacterId = HallOfFame.userCharacterId"></asp:SqlDataSource>

    </form>
</body>
</html>
