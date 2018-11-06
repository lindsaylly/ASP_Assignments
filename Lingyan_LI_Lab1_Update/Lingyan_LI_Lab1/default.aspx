<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Lingyan_LI_Lab1._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />    
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/site.css" rel="stylesheet" />   
</head>
<body>
    <div class="container">
        <div class="jumbotron">
                <img alt="logo" class="auto-style1 img-fluid" src="Images/logo.png" />
            <h1>Temperature converter</h1>
        </div>
        <main>
                <form id="form1" runat="server" class="form-horizontal" role="form">
                    <div class="row">
                        <div class="col-sm">
                    <div class="form-group">
                         <asp:Label ID="Label1" runat="server" class="control-label" Text="From"></asp:Label>
                            <asp:DropDownList ID="ddlFrom" runat="server" CssClass="form-control">
                                <asp:ListItem Selected="True">Celsius</asp:ListItem>
                                <asp:ListItem>Fahrenheit</asp:ListItem>
                                <asp:ListItem>Kelvin</asp:ListItem>
                            </asp:DropDownList>
                    </div>
                            </div>

                        <div class="col-sm">
                    <div class="form-group">
                         <asp:Label ID="Label2" runat="server" class="form-label" Text="To"></asp:Label>
                            <asp:DropDownList ID="ddlTo" runat="server" CssClass="form-control">
                            <asp:ListItem Selected="True">Fahrenheit</asp:ListItem>
                            <asp:ListItem>Celsius</asp:ListItem>
                            <asp:ListItem>Kelvin</asp:ListItem>
                            </asp:DropDownList>
                    </div>
                    </div>
                    </div>

                    <div class="row">
                        <div class="col-sm">
                    <div class="form-group">
                        <asp:Label ID="lblInputPrompt" runat="server" class="form-label" Text="Input temperature"></asp:Label>
                        <asp:TextBox ID="txtInput" CssClass="form-control" runat="server" CausesValidation="True"></asp:TextBox>
                        </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" class="text-danger" Display="Dynamic" ErrorMessage="The field is requited" ControlToValidate="txtInput"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RangeValidator ID="RangeValidator1" runat="server" class="text-danger" Display="Dynamic" ErrorMessage="Input should be between -1000 and 1000 " ControlToValidate="txtInput" MaximumValue="1000" MinimumValue="-1000" Type="Double"></asp:RangeValidator>
                        </div>
                        <div class="col-sm">
                    <div class="form-group">
                        <asp:Label ID="lblOutputPromt" runat="server" class="form-label" Text="Output temperature"></asp:Label>
                        <asp:TextBox ID="txtOutput" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                    </div>
                            </div>
                        </div>

                    <div class="form-group">
                        <div class="row"> 
                            <div class="col-sm">
                            <asp:Button ID="btnConvert" runat="server" CssClass="btn btn-success" Text="Convert" OnClick="btnConvert_Click" />
                                </div> 
                            <div class="col-sm">
                            <asp:Button ID="btnClear" runat="server" CssClass="btn btn-success" Text="Clear" OnClick="btnClear_Click" CausesValidation="False" />
                                </div>
                        </div>
                    </div>                
                </form>
                        
        </main>
    </div>
</body>
</html>
