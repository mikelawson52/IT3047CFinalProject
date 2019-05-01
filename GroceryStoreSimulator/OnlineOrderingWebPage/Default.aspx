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
        <div id="divContent" runat="server" class="jumbotron container bg-light">
            <div id="divHead" runat="server" class="row">
                <asp:Image ID="imgGroceries1" runat="server" ImageUrl="App_Themes/DefaultTheme/Groceries.bmp" CssClass="col-sm-1" />
                <asp:Label ID="lblHeading1" runat="server" Text="General Grocery Store" CssClass="display-2 text-center text-primary col-sm-10 "></asp:Label>
                <asp:Image ID="imgGroceries2" runat="server" ImageUrl="App_Themes/DefaultTheme/Groceries.bmp" CssClass="col-sm-1" />
                <br />
            </div>
            <asp:Label ID="lblHeading2" runat="server" Text="Online Grocery Order Form" CssClass=" display-4 text-center text-dark"></asp:Label>
            <br />
            <hr />
            <div id="divBody" runat="server" class="form-group bg-light">
                <asp:Label ID="lblHeading3" runat="server" Text="ENTER YOUR LOYALTY NUMBER AND SELECT YOUR STORE" CssClass=" bg-light text-primary align-content-sm-center h1"></asp:Label>
                <div id="divRow1" runat="server" class="row">
                    <%-- Loyalty Number input --%>
                    <div id="divLoyaltyNumber" runat="server" class="col-sm-5">
                        <asp:Label ID="lblLoyaltyNumber" runat="server" Text="Loyalty Number: " CssClass="h2 text-dark"></asp:Label>
                        <asp:TextBox ID="tbxLoyaltyNumber" runat="server" CssClass="form-control"></asp:TextBox>
                        <div id="divWarningLoyalty" runat="server" visible="true" class="alert-warning">
                            <asp:Label ID="lblLoyaltyWarningEmpty" runat="server" Text="Please enter your loyalty number" Visible="false"></asp:Label>
                            <asp:Label ID="lblLoyaltyWarningNaN" runat="server" Text="Loyalty Number must contain only digits" Visible="false"></asp:Label>
                            <asp:Label ID="lblLoyaltyWarningBadLoyaltyNum" runat="server" Text="Loyalty Number given does not exist or is not currently valid for online ordering" Visible="false"></asp:Label>
                        </div>
                    </div>
                    <%-- Select store input --%>
                    <div id="divSelectedStore" runat="server" class="col-sm-7">
                        <asp:Label ID="lblSelectStore" runat="server" Text="Store: " CssClass="h2 text-dark"></asp:Label>
                        <asp:ListBox ID="lbxSelectStore" runat="server" CssClass="form-control" Visible="True" AppendDataBoundItems="true"></asp:ListBox>
                        <div id="divWarningStore" runat="server" class="alert-warning">
                            <asp:Label ID="lblWarningStore" runat="server" Visible="false" Text="Plese select a store"></asp:Label>
                        </div>
                    </div>
                </div>
                <br id="break1" runat="server" />
                <br id="break2" runat="server" />
                <asp:Button ID="btnSelect" runat="server" Text="Select" CssClass="btn btn-dark btn-lg btn-block" OnClick="btnSelect_Click" />
                <br />
                <br />
                <%-- Body of selecting a product/quantity after selecting store/loyalty number --%>
                <div id="divBodyHidden" runat="server" class="form-group bg-light" visible="false">
                    <div id="divRow2" runat="server" class="row">
                        <%-- Product Select Input --%>
                        <div id="divSelectedProduct" runat="server" class="col-sm-8">
                            <asp:Label ID="lblSelectProduct" runat="server" Text="Product:" CssClass="h2 text-dark"></asp:Label>
                            <asp:ListBox ID="lbxSelectProduct" runat="server" AppendDataBoundItems="true" CssClass="form-control"></asp:ListBox>
                            <asp:Label ID="lblWarningProduct" runat="server" Text="You must select a product to add it to your cart!" CssClass="alert-warning" Visible="false"></asp:Label>
                            <br />
                            <br />
                        </div>
                        <%-- Quantity Input --%>
                        <div id="divSelectedQuantity" runat="server" class="col-sm-4">
                            <asp:Label ID="lblSelectQuantity" runat="server" Text="Quantity:" CssClass="h2 text-dark"></asp:Label>
                            <asp:TextBox ID="tbxSelectQuantity" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                            <asp:Label ID="lblWarningQuantityNaN" runat="server" Text="Your quantity must be a number with no decimals and not equal to or less than 0." CssClass="alert-warning" Visible="false"></asp:Label>
                            <asp:Label ID="lblWarningQuantityEmpty" runat="server" Text="You must input a quantity to add a product to your cart!" CssClass="alert-warning" Visible="false"></asp:Label>
                            <br />
                            <br />
                        </div>
                    </div>
                    <asp:Button ID="btnAddProductToOrder" runat="server" Text="Add" CssClass="btn btn-dark btn-block btn-lg " OnClick="btnAddProductToOrder_Click" />
                    <asp:Button ID="btnResetOrder" runat="server" Text="Clear Cart" CssClass="btn btn-dark btn-block btn-lg" OnClick="btnResetOrder_Click" />
                    <br />
                    <br />
                    <%-- Shows the user what they have in their cart --%>
                    <div id="divCurrentShoppingCart" runat="server" class="card text-white border-dark bg-info h2">
                        <asp:Label ID="lblShoppingCart" runat="server" Text="Shopping Cart" CssClass="card-header display-4 text-center text-white"></asp:Label>
                        <asp:Label ID="lblCurrentShoppingCart" runat="server" Text="" CssClass="font-italic h2"></asp:Label>
                        <br />
                        <br />
                    </div>
                    <div id="divWarning" class="alert-warning">
                        <asp:Label ID="lblWarningEmptyCart" runat="server" Text="You must have items in your cart to submit an order!" Visible="false"></asp:Label>
                    </div>
                    <%-- Submit entire order to database --%>
                    <asp:Button ID="btnSubmitOrder" runat="server" Text="Submit Order" CssClass="btn btn-dark btn-lg btn-block" OnClick="btnSubmitOrder_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/popper.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>
