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
        <div id="divContent" runat="server" class="jumbotron container bg-light">
            <div id="divHead" runat="server" class="row" >
            <asp:Image ID="imgGroceries1" runat="server" ImageUrl="App_Themes/DefaultTheme/Groceries.bmp" CssClass="col-sm-1" /><br />
            <asp:Label ID="lblHeading1" runat="server" Text="General Grocery Store" CssClass="display-2 text-center text-primary col-sm-10"></asp:Label>
            <asp:Image ID="imgGroceries2" runat="server" ImageUrl="App_Themes/DefaultTheme/Groceries.bmp" CssClass="col-sm-1" />
                 </div>
            <asp:Label ID="lblHeading2" runat="server" Text="Order Confirmation" CssClass="display-4 text-center text-dark"></asp:Label><br />
            <br />
            <hr />
            <asp:Label ID="lblHeading3" runat="server" Text="Thank you for ordering!" CssClass="display-1 text-center text-Primary"></asp:Label>
            <div id="divBody" runat="server" class="card text-white bg-info border-dark h2">
                <asp:Label ID="lblHeading4" runat="server" Text="Your Order" CssClass=" card-header text-white display-4 text-center"></asp:Label><br />
                <asp:Label ID="lblOrderInfo" runat="server" Text="" CssClass="h2 text-white"></asp:Label><br />
                
            </div>
        </div>
    </form>
</body>
</html>
