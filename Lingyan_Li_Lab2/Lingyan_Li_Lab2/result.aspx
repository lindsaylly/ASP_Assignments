<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="result.aspx.cs" Inherits="Lingyan_Li_Lab2.result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Current Voting Results</h1>
            <br />
            <asp:Label ID="lblDay1" runat="server" Text="Day 1:"></asp:Label>
            <asp:TextBox ID="txtDay1" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Day 2:"></asp:Label>
            <asp:TextBox ID="txtDay2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Day 3:"></asp:Label>
            <asp:TextBox ID="txtDay3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click" />
            <br />
        </div>
    </form>
</body>
</html>
