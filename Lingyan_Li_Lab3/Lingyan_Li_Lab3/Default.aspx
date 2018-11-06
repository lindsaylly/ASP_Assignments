<%--Purpose: ASP.NET Lab3
Author: Lindsay
Date:July, 2018--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lingyan_Li_Lab3.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/site.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="jumbotron bg-info">
            <h1>SportsPro</h1>
        </div>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlTechID" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="TechID">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllTechnicians" TypeName="Lingyan_Li_Lab3.TechnicianDB"></asp:ObjectDataSource>
            <br />
            <br />
            <asp:GridView ID="gvIncident" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2">
                <Columns>
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" SortExpression="CustomerName" />
                    <asp:BoundField DataField="IncidentID" HeaderText="Incident ID" SortExpression="IncidentID" />
                    <asp:BoundField DataField="ProductCode" HeaderText="Product Code" SortExpression="ProductCode" />
                    <asp:BoundField DataField="TechID" HeaderText="Technician ID" SortExpression="TechID" />
                    <asp:BoundField DataField="DateOpened" HeaderText="Date Opened" SortExpression="DateOpened" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                </Columns>
                <EmptyDataTemplate>
                    There is no opened incident supporting by the technician.
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetOpenTechIncidents" TypeName="Lingyan_Li_Lab3.IncidentDB">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlTechID" Name="techID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
        </div>
    </form>
    </div>
</body>
<script src="Scripts/jquery-3.0.0.slim.min.js"></script>
<script src="Scripts/popper.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
</html>
