<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
                <%-- Loyalty Number input --%>
                <asp:Label ID="lblLoyaltyNumber" runat="server" Text="Loyalty Number " class="h2 "></asp:Label>
                <asp:TextBox ID="tbxLoyaltyNumber" runat="server" class="form-control"></asp:TextBox><br />
                <div id="divWarningLoyalty" runat="server" visible="true" class="alert-warning">
                    <asp:Label ID="lblLoyaltyWarningEmpty" runat="server" Text="Please enter your loyalty number" Visible="false"></asp:Label>
                    <asp:Label ID="lblLoyaltyWarningNaN" runat="server" Text="Loyalty Number must contain only digits" Visible="false"></asp:Label>
                    <asp:Label ID="lblLoyaltyWarningBadLoyaltyNum" runat="server" Text="Loyalty Number given does not exist or is not currently valid for online ordering" Visible="false"></asp:Label>
                </div>
                <%-- Select store input --%>
                <asp:Label ID="lblSelectStore" runat="server" Text="Store:" class="h2"></asp:Label>
                <asp:ListBox ID="lbxSelectStore" runat="server" class="form-control" Visible="True" AppendDataBoundItems="true"></asp:ListBox>
                <div id="divWarningStore" runat="server" class="alert-warning">
                    <asp:Label ID="lblWarningStore" runat="server" Visible="false" Text="You did not select a store!"></asp:Label>
                </div>
            </div>
            <asp:Button ID="btnSelect" runat="server" Text="Select" class="btn btn-dark btn-lg btn-block" OnClick="btnSelect_Click" /><br />
            <br />
            <%-- Body of selecting a product/quantity after selecting store/loyalty number --%>
            <div id="divBodyHidden" runat="server" class="form-group bg-secondary" visible="false">
                <%-- Product Select Input --%>
                <asp:Label ID="lblSelectProduct" runat="server" Text="Product" class="h2"></asp:Label>
                <asp:ListBox ID="lbxSelectProduct" runat="server" AppendDataBoundItems="true" class="form-control"></asp:ListBox>
                <asp:Label ID="lblWarningProduct" runat="server" Text="You must select a product to add it to your cart!" class="alert-warning" Visible="false"></asp:Label>
                <br />
                <br />
                <%-- Quantity Input --%>
                <asp:Label ID="lblSelectQuantity" runat="server" Text="Quantity" class="h2"></asp:Label>
                <asp:TextBox ID="tbxSelectQuantity" runat="server" Text="" class="form-control"></asp:TextBox>
                <asp:Label ID="lblWarningQuantityNaN" runat="server" Text="Your quantity must be a number with no decimals and not equal to 0." class="alert-warning" Visible="false"></asp:Label>
                <asp:Label ID="lblWarningQuantityEmpty" runat="server" Text="You must input a quantity" class="alert-warning" Visible="false"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btnAddProductToOrder" runat="server" Text="Add To Order" class="btn btn-success btn-lg btn-block" OnClick="btnAddProductToOrder_Click" />
                <%-- Shows the user what they have in their cart --%>
                <asp:Label ID="lblCurrentShoppingCart" runat="server" Text="" class=""></asp:Label>
                <br />
                <%-- Submit entire order to database --%>
                <asp:Button ID="btnSubmitOrder" runat="server" Text="Submit Order" class="btn btn-success btn-lg btn-block" OnClick="btnSubmitOrder_Click" />
            </div>
        </div>
    </form>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/popper.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>
