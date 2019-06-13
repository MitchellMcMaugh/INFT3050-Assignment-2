<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="17fighting.aspx.cs" Inherits="INFT3050_Assignment_2.WebForm17" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fight!</title>
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

    <!-- Your Character Information -->
    <div style="margin: 10px;">
        <asp:Label ID="lbl_yourCharacter" runat="server" Text="Your Character"></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="YourCharacterSQL0" DataTextField="userCharacterName" DataValueField="userCharacterName">
        </asp:DropDownList>
        <br />
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="YourCharacterSQL" Height="50px" Width="307px">
            <Fields>
                <asp:BoundField DataField="userCharacterName" HeaderText="Name" SortExpression="userCharacterName" />
                <asp:BoundField DataField="userCharacterLevel" HeaderText="Level" SortExpression="userCharacterLevel" />
                <asp:BoundField DataField="userCharacterStep" HeaderText="Step" SortExpression="userCharacterStep" />
            </Fields>
        </asp:DetailsView>
        <asp:SqlDataSource ID="YourCharacterSQL" runat="server" ConnectionString="<%$ ConnectionStrings:INFT3050MitchellMcMaugh3185423ConnectionString1 %>" SelectCommand="SELECT [userCharacterName], [userCharacterLevel], [userCharacterStep] FROM [UserCharacters] WHERE (([userId] = @userId) AND ([userCharacterName] = @userCharacterName))">
            <SelectParameters>
                <asp:ControlParameter ControlID="Label2" Name="userId" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="DropDownList1" Name="userCharacterName" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="YourCharacterSQL0" runat="server" ConnectionString="<%$ ConnectionStrings:INFT3050MitchellMcMaugh3185423ConnectionString1 %>" SelectCommand="SELECT [userCharacterName] FROM [UserCharacters] WHERE ([userId] = @userId)">
            <SelectParameters>
                <asp:ControlParameter ControlID="Label2" Name="userId" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        </br>
    </div>
    <!-- End Your Character Information -->

    <!-- Enemy Character Information -->
    <div style="margin: 10px;">
        <asp:Label ID="lbl_enemyCharacter" runat="server" Text="Enemy Character"></asp:Label></br>
        <br />
        <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" DataSourceID="EnemyCharacterSQL" Height="50px" Width="312px">
            <Fields>
                <asp:BoundField DataField="userCharacterName" HeaderText="Name" SortExpression="userCharacterName" />
                <asp:BoundField DataField="userCharacterLevel" HeaderText="Level" SortExpression="userCharacterLevel" />
                <asp:BoundField DataField="userCharacterStep" HeaderText="Step" SortExpression="userCharacterStep" />
            </Fields>
        </asp:DetailsView>
        <asp:SqlDataSource ID="EnemyCharacterSQL" runat="server" ConnectionString="<%$ ConnectionStrings:INFT3050MitchellMcMaugh3185423ConnectionString1 %>" SelectCommand="SELECT [userCharacterLevel], [userCharacterName], [userCharacterStep] FROM [UserCharacters] WHERE ([userCharacterId] = @userCharacterId)">
            <SelectParameters>
                <asp:ControlParameter ControlID="Label1" Name="userCharacterId" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Confirm Fight" />
    </div>
    <!-- End Fight Outcome -->

        <p>
        <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
        </p>

    </form>
</body>
</html>
