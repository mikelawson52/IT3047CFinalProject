﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Ordering</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="frmOrderForm" runat="server">
        <div id="divHead" runat="server" class="jumbotron container bg-primary">

            <asp:Label ID="lbl" runat="server" Text="General Grocery Store" class="display-3"></asp:Label>
            <asp:Image ID="imgGroceries" runat="server" ImageUrl="App_Themes/DefaultTheme/Groceries.bmp" />
            <asp:Label ID="lblHeading2" runat="server" Text="Online Grocery Order Form" class="h1"></asp:Label><br />
            <br />
            <asp:Label ID="lblHeading3" runat="server" Text="PLEASE ENTER YOUR LOYALTY NUMBER AND SELECT YOUR STORE" CssClass="h2"></asp:Label><br />
            <div id="divBody" runat="server" class="form-group bg-secondary">
                <asp:Label ID="lblLoyaltyNumber" runat="server" Text="Loyalty Number " class="h2 "></asp:Label>
                <asp:TextBox ID="tbxLoyaltyNumber" runat="server" class="form-control"></asp:TextBox><br />
                <div id="divWarningLoyalty" runat="server" visible="false" class="alert-warning">
                    <asp:Label ID="lblLoyalty1" runat="server" Text="Please enter your loyalty number" Visible="false"></asp:Label>
                    <asp:Label ID="lblLoyalty2" runat="server" Text="Loyalty Number must contain only digits" Visible="false"></asp:Label>
                </div>
                <asp:Label ID="lblSelectStore" runat="server" Text="Store:" class="h2"></asp:Label>
                <asp:ListBox ID="lbxSelectStore" runat="server" class="form-control" Visible="True"></asp:ListBox>
                <div id="divWarningStore" runat="server" visible="false" class="alert-warning">
                    <asp:Label ID="lblWarningStore" runat="server" Text="You did not select a store!"></asp:Label>
                </div>
            </div>
            <asp:Button ID="btnSelect" runat="server" Text="Select" class="btn btn-dark btn-lg btn-block" OnClick="btnSelect_Click" /><br />
            <br />
            <div id="divBodyHidden" runat="server" class="form-group bg-secondary" visible="false">
                <asp:Label ID="lblSelectProduct" runat="server" Text="Product" class="h2"></asp:Label><asp:ListBox ID="lbxSelectProduct" runat="server" class="form-control"></asp:ListBox><br />
                <br />
                <asp:Label ID="lblSelectQuantity" runat="server" Text="Quantity" class="h2"></asp:Label><asp:TextBox ID="tbxSelectQuantity" runat="server" Text="" class="form-control"></asp:TextBox><br />
                <br />
                <asp:Button ID="btnSubmitOrder" runat="server" Text="Submit Order" class="btn btn-success btn-lg btn-block" OnClick="btnSubmitOrder_Click" />
            </div>
        </div>
    </form>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/popper.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>
