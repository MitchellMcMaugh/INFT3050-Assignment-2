<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="06characterManagement.aspx.cs" Inherits="INFT3050_Assignment_2.WebForm14" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Character Management</title>
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

    <!-- Character Management Drop List -->
    <div>
        <div style="margin: 10px;">
        What character do you want to manage?</br>
        <!-- Backend coding will need to be done on this drop box so that when 'Create New Character' is selected it goes to the necessary page. -->
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="userCharacterId" DataSourceID="CharacterManagement" OnRowDeleted="GridView1_RowDeleted">
                <Columns>
                    <asp:BoundField DataField="userCharacterId" HeaderText="userCharacterId" InsertVisible="False" ReadOnly="True" SortExpression="userCharacterId" Visible="False" />
                    <asp:BoundField DataField="userCharacterName" HeaderText="Name" SortExpression="userCharacterName" />
                    <asp:BoundField DataField="userCharacterLevel" HeaderText="Level" SortExpression="userCharacterLevel" />
                    <asp:BoundField DataField="userCharacterStep" HeaderText="Step" SortExpression="userCharacterStep" />
                    <asp:BoundField DataField="userCharacterExperience" HeaderText="Experience" SortExpression="userCharacterExperience" />
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="CharacterManagement" runat="server" ConnectionString="<%$ ConnectionStrings:INFT3050MitchellMcMaugh3185423ConnectionString1 %>" SelectCommand="SELECT [userCharacterName], [userCharacterStep], [userCharacterLevel], [userCharacterExperience], [userCharacterId] FROM [UserCharacters] WHERE ([userId] = @userId)" DeleteCommand="DELETE FROM [UserCharacters] WHERE [userCharacterId] = @userCharacterId" InsertCommand="INSERT INTO [UserCharacters] ([userCharacterName], [userCharacterStep], [userCharacterLevel], [userCharacterExperience]) VALUES (@userCharacterName, @userCharacterStep, @userCharacterLevel, @userCharacterExperience)" UpdateCommand="UPDATE [UserCharacters] SET [userCharacterName] = @userCharacterName, [userCharacterStep] = @userCharacterStep, [userCharacterLevel] = @userCharacterLevel, [userCharacterExperience] = @userCharacterExperience WHERE [userCharacterId] = @userCharacterId">
                <DeleteParameters>
                    <asp:Parameter Name="userCharacterId" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="userCharacterName" Type="String" />
                    <asp:Parameter Name="userCharacterStep" Type="Int32" />
                    <asp:Parameter Name="userCharacterLevel" Type="Int32" />
                    <asp:Parameter Name="userCharacterExperience" Type="Int32" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="lbl_uIDHidden" Name="userId" PropertyName="Text" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="userCharacterName" Type="String" />
                    <asp:Parameter Name="userCharacterStep" Type="Int32" />
                    <asp:Parameter Name="userCharacterLevel" Type="Int32" />
                    <asp:Parameter Name="userCharacterExperience" Type="Int32" />
                    <asp:Parameter Name="userCharacterId" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Button ID="btn_createCharacter" runat="server" OnClick="Button1_Click" Text="Create Character" />
            <br />
            <br />
            <asp:Label ID="lbl_uIDHidden" runat="server" Visible="False"></asp:Label>
            </br>
    </div>
    <!-- End Character Management Drop List -->

    </form>
</body>
</html>
