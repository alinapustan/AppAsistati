<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Checkout.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Home Page</title>
    <link href="../Style/StyleSheet.css" rel="stylesheet" />
    <script src="../Scripts/UserValidation.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

        <div style="display: flex; justify-content: flex-end; align-items: flex-end;">
            Todays date is: 
            <asp:Label ID="lblday" runat="server"></asp:Label>
        </div>

        <div id="menu">
            <ul>
                <li class="active"><a href="<%: GetRouteUrl("HomeRoute",null)%>">Home</a></li>
                <li><a href="#">About</a></li>
                <li><a href="<%: GetRouteUrl("UsersListRoute",null)%>">UsersListMergeee</a> </li>
                <li><a href="#">Contact</a></li>
            </ul>
        </div>
        <br />
        <br />
        <div style="display: flex; justify-content: center; align-items: center;">
            <div>
                <h3>Please fill in with your data: </h3>
                <br />
                <asp:Table runat="server">
                    <asp:TableRow ID="getCNPRow" runat="server">
                        <asp:TableCell>
                            <asp:Label ID="lblGetCNP" runat="server" Text="CNP:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="TextBox3" runat="server" Width="145px" onkeypress="validateCNP()" onkeyup="validateCNP()" autocomplete="off"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblCNPValidation" runat="server"></asp:Label><br />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="getNameRow" runat="server">
                        <asp:TableCell>
                            <asp:Label ID="lblGetName" runat="server" Text="Name:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="TextBox1" runat="server" Width="145px" onkeypress="validateName()" onkeyup="validateName()" autocomplete="off"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblNameValidation" runat="server"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblGetSurname" runat="server" Text="Surname:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="TextBox2" runat="server" Width="145px" onkeypress="validateSurname()" onkeyup="validateSurname()" autocomplete="off"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblSurnameValidation" runat="server"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <p>
                    Your Birthday is: 
            <asp:Label ID="lblbday" runat="server"></asp:Label>
                    <asp:Button ID="Button2" runat="server" Text="Show Calendar" OnClick="Button2_Click" Height="23px" Width="117px" />
                    <asp:Calendar ID="Calendar1" runat="server" Visible="false" SelectionMode="DayWeekMonth" OnLoad="Calendar1_Load" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="235px" Width="298px">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
                </p>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Save personal data" OnClick="Button1_Click" Height="36px" Width="220px" CausesValidation="true"/>
                <br />
                <asp:Label ID="lblSuccess" runat="server" Text="save person outcome:" Visible="false"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="Button3" runat="server" Text="Check below to see you data:" OnClick="Button3_Click" Height="36px" Width="220px" />
                <div>
                    <asp:Label ID="lblCNP" runat="server" Text="CNP:" Visible="false"></asp:Label>
                    <br />
                    <asp:Label ID="lblName" runat="server" Text="Name:" Visible="false"></asp:Label>
                    <br />
                    <asp:Label ID="lblSurname" runat="server" Text="Surname:" Visible="false"></asp:Label><br />
                    <asp:Label ID="lblBirthday" runat="server" Text="Birthday:" Visible="false"></asp:Label>
                    <br />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
