<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersListPage.aspx.cs" Inherits="Checkout.UsersListPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="menu">
            <ul>
                <li><a href="<%: GetRouteUrl("HomeRoute",null)%>">Home</a></li>
                <li><a href="#">About</a></li>
                <li class="active"><a href="<%: GetRouteUrl("UsersListRoute",null)%>">Users List</a> </li>
                <li><a href="#">Contact</a></li>
            </ul>
        </div>
        <br />
        <br />
        <br />

        <div style="display: flex; justify-content: center; align-items: center;">
            <div>
                <asp:GridView ID="GridView1" runat="server" Height="181px" HorizontalAlign="Justify" Width="567px" AllowPaging="True" AllowSorting="True" BackColor="#CCFFFF" BorderColor="#9933FF" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#FF99FF" />
                </asp:GridView>
                <br />
                <asp:Label ID="Label" runat="server" Text="Number of persons in database: "></asp:Label>
                <asp:Label ID="NumberOfPersonsLbl" runat="server"></asp:Label>
            </div>
        </div>
        <br />
        <asp:Button ID="btnGoToCustomer" runat="server" Text="Goto first Customer" OnClick="btnGoToCustomer_Click" />
    </form>
</body>
</html>
