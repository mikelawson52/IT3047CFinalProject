<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderConfirmation.aspx.cs" Inherits="OrderConfirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Order Confirmation</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="div1" runat="server" class="jumbotron container bg-primary">
            <asp:Label ID="lbl" runat="server" Text="General Grocery Store" CssClass="display-3"></asp:Label>
            <asp:Image ID="imgGroceries" runat="server" ImageUrl="App_Themes/DefaultTheme/Groceries.bmp" />
            <asp:Label ID="lblHeading2" runat="server" Text="Order Confirmation" CssClass="h1"></asp:Label><br />
            <br />
            <asp:Label ID="lblHeading3" runat="server" Text="Your order has been processed." CssClass="h2"></asp:Label><br />
            <asp:Label ID="lblOrderInfo" runat="server" Text="" CssClass=""></asp:Label><br />            
        </div>
    </form>
</body>
</html>
