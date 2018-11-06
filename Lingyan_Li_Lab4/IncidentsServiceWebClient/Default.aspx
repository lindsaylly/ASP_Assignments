<%--Purpose: ASP.NET Lab4
Author: Lindsay
Date:July, 2018--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IncidentsServiceWebClient.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
</head>
<body>
   <form id="form1" runat="server">
        <div class="container">
            <div class="jumbotron bg-info">
                <h1>SportsPro</h1>
            </div>       
            <div>
                <asp:Label ID="Label1" runat="server" Text="CustomerID:"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlCustomers" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCustomers_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="The detail of the incident:"></asp:Label>
                <br />
                <asp:GridView ID="gvIncident" runat="server">
                </asp:GridView>
            </div>
        </div>
    </form>`   
</body>
</html>
