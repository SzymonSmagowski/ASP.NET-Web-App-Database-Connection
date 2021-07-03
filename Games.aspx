<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="HomeworkApp1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 701px;
            height: 53px;
        }
        .auto-style3 {
            width: 104px;
            height: 25px;
        }
        .auto-style4 {
            height: 23px;
            width: 104px;
        }
        .auto-style5 {
            width: 87px;
            height: 25px;
        }
        .auto-style6 {
            height: 23px;
            width: 87px;
        }
        .auto-style10 {
            width: 68px;
            height: 25px;
        }
        .auto-style11 {
            height: 23px;
            width: 68px;
        }
        .auto-style12 {
            width: 89px;
            height: 25px;
        }
        .auto-style13 {
            height: 23px;
            width: 89px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" PageSize="100" DataKeyNames="GAME_ID" DataSourceID="MYSERVER" Height="271px" Width="684px">
                <Columns>
                    <asp:BoundField DataField="GAME_ID" HeaderText="GAME_ID" ReadOnly="True" SortExpression="GAME_ID" />
                    <asp:BoundField DataField="GAME_NAME" HeaderText="GAME_NAME" SortExpression="GAME_NAME" />
                    <asp:BoundField DataField="RELEASE_DATE" HeaderText="RELEASE_DATE" SortExpression="RELEASE_DATE" />
                    <asp:BoundField DataField="SCORE" HeaderText="SCORE" SortExpression="SCORE" />
                    <asp:BoundField DataField="PRICE" HeaderText="PRICE" SortExpression="PRICE" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="MYSERVER" runat="server" ConnectionString="<%$ ConnectionStrings:Homework1ConnectionString %>" SelectCommand="SELECT [GAME_ID], [GAME_NAME], [RELEASE_DATE], [SCORE], [PRICE] FROM [GAMES]"></asp:SqlDataSource>
            <br />
            Insert a game:<br />
            <br />
            Release Date:<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            <br />
            <br />
        </div>
    <table border="1" class="auto-style2">
        <tr>
            <td class="auto-style5">GAME ID</td>
            <td class="auto-style3">GAME NAME</td>
            <td class="auto-style10">SCORE</td>
            <td class="auto-style12">PRICE</td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:TextBox ID="GameID" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="GameName" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style11">
                <asp:TextBox ID="Score" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style13">
                <asp:TextBox ID="Price" runat="server"></asp:TextBox>
            </td>
        </tr>
       
    </table>
        <p>
            <asp:Button ID="SubmitButton" runat="server" Height="39px" Text="Submit" Width="103px" OnClick="Button1_Click" />
        </p>
        <p>
            ===========================================================================================================================</p>
        <p>
            <asp:Button ID="FilterButton" runat="server" Height="31px" OnClick="filteringButton_Click" Text="Filter" Width="99px" />
        </p>
        <p>
            <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
            <asp:Calendar ID="Calendar3" runat="server"></asp:Calendar>
        </p>
             <table border="1">
        <tr>
            <td class="auto-style5">Game seeker</td>
            <td class="auto-style3">Minimum score</td>
        </tr>
        <tr>
            <td class="auto-style6">
                
                <asp:TextBox ID="GameNameFilter" runat="server"></asp:TextBox>
                
            </td>
            <td class="auto-style4">
                
                <asp:TextBox ID="MinimumScoreFilter" runat="server"></asp:TextBox>
                
            </td>
            
        </tr>
       
    </table>
        <p>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="GAME_ID" DataSourceID="MYSERVER">
                <Columns>
                    <asp:BoundField DataField="GAME_ID" HeaderText="GAME_ID" ReadOnly="True" SortExpression="GAME_ID" />
                    <asp:BoundField DataField="GAME_NAME" HeaderText="GAME_NAME" SortExpression="GAME_NAME" />
                    <asp:BoundField DataField="RELEASE_DATE" HeaderText="RELEASE_DATE" SortExpression="RELEASE_DATE" />
                    <asp:BoundField DataField="SCORE" HeaderText="SCORE" SortExpression="SCORE" />
                    <asp:BoundField DataField="PRICE" HeaderText="PRICE" SortExpression="PRICE" />
                </Columns>
            </asp:GridView>
        </p>
        <p>
            ====================================================================================================================</p>
        <p>
            <asp:Button ID="BuyButton" runat="server" Height="44px" OnClick="BuyButton_Click" Text="Buy" Width="98px" />
        </p>
        <p>
            <asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
            </asp:DropDownList>
        </p>
        <p>
            &nbsp;</p>
    </form>
    </body>
</html>
