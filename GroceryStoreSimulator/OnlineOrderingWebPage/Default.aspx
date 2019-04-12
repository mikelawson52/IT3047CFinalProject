<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Ordering</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="frmOrderForm" runat="server">
        <div id="divHead" class="jumbotron container bg-primary">
            <asp:Label ID="lbl" runat="server" Text="General Grocery Store" CssClass="display-3"></asp:Label><br />
             <asp:Image ID="imgGroceries" runat="server" ImageUrl="App_Themes/DefaultTheme/Groceries.bmp" />
            <asp:Label ID="lblHeading2" runat="server" Text="Online Grocery Order Form" CssClass="h1"></asp:Label><br />
            <br />
            <asp:Label ID="lblHeading3" runat="server" Text="PLEASE ENTER YOUR LOYALTY NUMBER AND SELECT YOUR STORE" CssClass="h2"></asp:Label><br />
            <div id="divBody" class="form-group bg-secondary">
                <asp:Label ID="lblLoyaltyNumber" runat="server" Text="Loyalty Number:" CssClass="h2 "></asp:Label>
                <asp:TextBox ID="tbxLoyaltyNumber" runat="server" CssClass="form-control"></asp:TextBox><br />
                <asp:Label ID="lblStores" runat="server" Text="Store:" CssClass="h2"></asp:Label>
                <asp:ListBox ID="lbxStores" runat="server" CssClass="form-control"></asp:ListBox>
               </div>
            <asp:Button ID="btnSelect" runat="server" Text="Select" CssClass="btn btn-dark btn-lg btn-block" />
        </div>
    </form>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/popper.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>
