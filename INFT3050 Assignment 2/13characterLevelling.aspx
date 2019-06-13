<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="13characterLevelling.aspx.cs" Inherits="INFT3050_Assignment_2.WebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Character Levelling</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css">
</head>
<body>
    <form id="form1" runat="server">
    
    <!-- Header -->
    <div>
        <h1 style="margin: 10px;">B.E.T.T.E.R</h1>
        <asp:Label ID="lbl_userLogin" runat="server" Text="Label" CssClass="Login"></asp:Label>
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

    <!-- Character Select -->
    <div style="margin: 10px;">
        What character do you wish to level?<br /></br>
        <asp:DropDownList ID="characterListLevelling" runat="server" AppendDataBoundItems="True" DataSourceID="CharacterLevelDataSource" DataTextField="userCharacterName" DataValueField="userCharacterName" AutoPostBack="True">
        </asp:DropDownList>
        <asp:SqlDataSource ID="CharacterLevelDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:INFT3050MitchellMcMaugh3185423ConnectionString1 %>" SelectCommand="SELECT [userCharacterName], [userCharacterId] FROM [UserCharacters] WHERE (([userId] = @userId) AND ([userCharacterLevel] &lt;&gt; @userCharacterLevel))">
            <SelectParameters>
                <asp:ControlParameter ControlID="lbl_uIDHidden" Name="userId" PropertyName="Text" Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="userCharacterLevel" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        </br>
            <asp:Label ID="lbl_uIDHidden" runat="server" Visible="False"></asp:Label>
            </br>
    </div>
    <!-- End Character Select -->

    <!-- Point Allocation -->
    <div style="margin: 10px;">
        How many points do you wish to give your character. You have
        <asp:Label ID="lbl_points" runat="server"></asp:Label>
&nbsp;points available to spend.</br></br><asp:TextBox ID="txt_pointsToLevel" runat="server"></asp:TextBox>
         <br />
        <br />
         <asp:Button ID="btn_lvelUp" runat="server" Text="Level Up" OnClick="btn_lvelUp_Click" />
    </div>
    <!-- End Point Allocation -->

    </form>
</body>
</html>
