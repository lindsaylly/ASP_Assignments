<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Lingyan_Li_Lab2._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 300px;
            height: 200px;
        }
        .auto-style2 {
            color: #FF0066;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style2">Good Time Celebration Party</h1>
            <br />
            <img alt="party" class="auto-style1" src="Images/summerparty.jpg" /><br />
            <br />
            Pick prefered date from the calendar below and submit your vote.<br />
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender" BackColor="White" ForeColor="Black">
            </asp:Calendar>
            You picked:<asp:Label ID="lblPickedDate" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Vote" OnClick="btnSubmit_Click" Enabled="False" />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
