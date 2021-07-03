<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="HomeworkApp1.Orders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 128px;
        }
        .auto-style2 {
            margin-bottom: 0px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ORDER_ID" DataSourceID="MYSERVER" Height="242px" Width="645px">
                <Columns>
                    <asp:BoundField DataField="ORDER_ID" HeaderText="ORDER_ID" ReadOnly="True" SortExpression="ORDER_ID" />
                    <asp:BoundField DataField="ORDER_DATE" HeaderText="ORDER_DATE" SortExpression="ORDER_DATE" />
                    <asp:BoundField DataField="GAME_ID" HeaderText="GAME_ID" SortExpression="GAME_ID" />
                    <asp:BoundField DataField="NET_AMOUNT" HeaderText="NET_AMOUNT" SortExpression="NET_AMOUNT" />
                    <asp:BoundField DataField="DISCOUNT" HeaderText="DISCOUNT" SortExpression="DISCOUNT" />
                    <asp:BoundField DataField="GROSS_AMOUNT" HeaderText="GROSS_AMOUNT" SortExpression="GROSS_AMOUNT" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="MYSERVER" runat="server" ConnectionString="<%$ ConnectionStrings:Homework1ConnectionString %>" SelectCommand="SELECT [ORDER_ID], [ORDER_DATE], [GAME_ID], [NET_AMOUNT], [DISCOUNT], [GROSS_AMOUNT] FROM [ORDERS]"></asp:SqlDataSource>
            <br />
            Modify an Order:<br />
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <table class="auto-style1" border="1">
                <tr>
                    
                    <td>Game ID:</td>
                    <td>Net Amount:</td>
                    <td>Discount:</td>
                    <td class="auto-style1">Gross Amount:</td>
                </tr>
                <tr>
                    
                    <td>
                        <asp:TextBox ID="TextBoxGameID" runat="server" CssClass="auto-style2"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxNetAmount" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxDiscount" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBoxGrossAmount" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
            </table>
            <br />
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            <br />
            <asp:Button ID="ModifyButton" runat="server" Height="49px" Text="Modify" Width="108px" OnClick="ModifyButton_Click" />
            <br />
            ==============================================================================================================<br />
            Delete an Order:<br />
            <br />
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="DeleteButton" runat="server" Height="46px" OnClick="DeleteButton_Click" Text="Delete" Width="98px" />
        </div>
    </form>
</body>
</html>
