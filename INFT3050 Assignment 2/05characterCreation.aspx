<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="05characterCreation.aspx.cs" Inherits="INFT3050_Assignment_2.WebForm13" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Character Creation</title>
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
            <li class="dropdown"><a class="dropbtn" href="#">Characters</a>
                <div class="dropdown-content">
                    <a href="06characterManagement.aspx">Manage Characters</a> 
                    <a href="13characterLevelling.aspx">Level Up Character</a>
                </div>
            </li>
            <li><a href="08challenges.aspx">Challenges</a></li>
            <li><a href="07hallOfFame.aspx">Hall of Fame</a></li>
            <li><a href="12exercise.aspx">Exercise</a></li>
            <li><a href="14logout.aspx">Logout</a> </li>
        </ul>
    </div>
    <!-- End Menu -->

    <!-- Character Creation -->
    <div style="margin: 10px;">
        <br />
        <asp:Label ID="lbl_characterName" runat="server" Text="Character Name"></asp:Label><br />
        <asp:TextBox ID="txt_characterName" runat="server"></asp:TextBox></br>
        </br>
        <asp:Label ID="lbl_characterType" runat="server" Text="Character Type"></asp:Label></br>
        <asp:DropDownList ID="characterTypes" runat="server" AppendDataBoundItems="True" DataSourceID="CharacterTypesData" DataTextField="characterName" DataValueField="characterId">
        </asp:DropDownList>
        <asp:SqlDataSource ID="CharacterTypesData" runat="server" ConnectionString="<%$ ConnectionStrings:INFT3050MitchellMcMaugh3185423ConnectionString1 %>" SelectCommand="SELECT [characterName], [characterId] FROM [Characters]"></asp:SqlDataSource>
        </br></br>
        <asp:Button ID="btn_createCharacter" runat="server" Text="Create Character" OnClick="btn_createCharacter_Click" />
    </div>
    <!-- End Character Creation -->

    </form>
</body>
</html>
