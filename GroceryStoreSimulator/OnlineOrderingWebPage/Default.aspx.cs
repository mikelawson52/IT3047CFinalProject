/**********************************************
 * Name: Mike Lawson and Tiffany Litteral 
 * Final Project 
 * IT3047C/001/Spring 2019
 * 05/01/2019
 * Form to enter loyalty information and submit order. 
 * *******************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using ASP;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Make sure the instance of our session variable isn't null. Make a new one if it is.
        ((global_asax)this.Context.ApplicationInstance).orderInformation = ((global_asax)this.Context.ApplicationInstance).orderInformation ?? new OrderInformation();
        using (GroceryStoreSimulatorContext context = new GroceryStoreSimulatorContext())
        {
            //Get store statuses.
            var storeStatuses = context.StoreStatus.ToList();
            //Get all store statuses that can't be ordered from.
            var unavailableStoreStatusIds = storeStatuses
                .Where(x => x.IsClosedForever || !x.AcceptingOnlineOrders)
                .Select(x => x.StoreStatusID);
            //Get stores
            var storeSelectionOptions = context.Store.ToList();
            //Get store history, join/include store status, group by store
            var storeHistory = context.StoreHistory
                .Include(x => x.StoreStatus)
                .GroupBy(x => x.StoreID);
            //Go through every store group in store history
            foreach (var storeHistoryRow in storeHistory)
            {
                //Get the newest store history record in a store group in order to determine the store's current status.
                var newestStoreHistoryRecord = storeHistoryRow
                    .OrderByDescending(x => x.StoreHistoryID)
                    .FirstOrDefault();
                //Check if the store is currently unavailable to order from and remove it from the selection list if it is unavailable.
                if (unavailableStoreStatusIds.Contains(newestStoreHistoryRecord.StoreStatus.StoreStatusID))
                {
                    var storeToRemove = storeSelectionOptions
                        .FirstOrDefault(x => x.StoreID == newestStoreHistoryRecord.StoreID);
                    storeSelectionOptions.Remove(storeToRemove);
                }
            }
            //Set the store to be the visible option for stores, set the id to be the value of the option, and bind the data to the select box.
            lbxSelectStore.DataValueField = "StoreID";
            lbxSelectStore.DataTextField = "Store";
            lbxSelectStore.DataSource = storeSelectionOptions;
            lbxSelectStore.DataBind();
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        /*************************************    Loyalty Number Validation.     ***************************************/
        //Keep track of if the entire section is complete and valid.
        bool isSectionComplete = true;

        // Do not allow loyalty number to be left blank. 
        if (tbxLoyaltyNumber.Text.Length == 0)
        {
            lblLoyaltyWarningEmpty.Visible = true;
            isSectionComplete = false;
        }
        //Else reset the visibility of the warning
        else
        {
            lblLoyaltyWarningEmpty.Visible = false;
        }

        //Check if the input is a number(double)
        double number = 0;
        bool isLoyaltyANumber = false;
        if (!lblLoyaltyWarningEmpty.Visible)
        {
            // Try and convert loyalty number to a double.
            isLoyaltyANumber = Double.TryParse(tbxLoyaltyNumber.Text, out number);
            if (!isLoyaltyANumber)
            {
                lblLoyaltyWarningNaN.Visible = true;
                isSectionComplete = false;
            }
            else
            {
                lblLoyaltyWarningNaN.Visible = false;
            }
        }
        //Else reset the visibility of the warning.
        else
        {
            lblLoyaltyWarningNaN.Visible = false;
        }

        //If the loyalty number passed the previous two checks, we need to make sure the loyalty number is valid in the DB.
        if (!lblLoyaltyWarningEmpty.Visible && !lblLoyaltyWarningNaN.Visible)
        {
            //open DB connection
            using (GroceryStoreSimulatorContext context = new GroceryStoreSimulatorContext())
            {
                //default value
                bool isLoyaltyUsable = false;
                //get all loyalty numbers from the DB and include their status
                var loyaltyNumbers = context.Loyalty
                    .Include(x => x.LoyaltyStatus)
                    .ToList();
                //Loop through each loyalty number
                foreach (var loyaltyNumber in loyaltyNumbers)
                {
                    //If the loyalty number in the DB matches the loyalty number entered, and the loyalty number is active, and the loyalty number can place online orders, mark it as a usable #.
                    if (loyaltyNumber.LoyaltyNumber.Trim().Equals(number.ToString())
                        && loyaltyNumber.LoyaltyStatus.IsActive
                        && loyaltyNumber.LoyaltyStatus.CanPlaceOnlineOrder)
                    {
                        isLoyaltyUsable = true;
                        break;
                    }
                }
                //Tell the user if their loyalty number was valid or not.
                if (!isLoyaltyUsable)
                {
                    lblLoyaltyWarningBadLoyaltyNum.Visible = true;
                    isSectionComplete = false;
                }
                else
                {
                    lblLoyaltyWarningBadLoyaltyNum.Visible = false;
                }
            }
        }
        //Else reset the visibility of the warning
        else
        {
            lblLoyaltyWarningBadLoyaltyNum.Visible = false;
        }

        /*************************************    Store Select Validation.     ***************************************/

        ListItem selectedStore = lbxSelectStore.SelectedItem;
        //Check if a store was selected, give a warning if not.
        if (selectedStore == null)
        {
            lblWarningStore.Visible = true;
            isSectionComplete = false;
        }
        else
        {
            lblWarningStore.Visible = false;
        }

        /*************************************    Populate Products Selection.     ***************************************/
        //Make sure the entire previous section was complete and valid first.
        if (isSectionComplete)
        {
            //Open DB connection and populate products.
            using (GroceryStoreSimulatorContext context = new GroceryStoreSimulatorContext())
            {
                //Web forms didn't like looking into a class's property that contained a different class for databinding, so lets make our own class out of the products!
                var products = context.Product
                    .Include(x => x.Name)
                    .Include(x => x.Brand)
                    .Include(x => x.Container)
                    .ToList();
                List<ProductNameSelectList> productNameSelections = new List<ProductNameSelectList>();
                foreach (var product in products)
                {
                    productNameSelections.Add(new ProductNameSelectList(product));
                }

                lbxSelectProduct.DataValueField = "ProductID";
                lbxSelectProduct.DataTextField = "VisibleOptionText";
                lbxSelectProduct.DataSource = productNameSelections;
                lbxSelectProduct.DataBind();
            }
            //Make new section visible
            divBodyHidden.Visible = true;
            lblHeading3.Visible = false;
            lblLoyaltyNumber.Text += tbxLoyaltyNumber.Text;
            lblSelectStore.Text += selectedStore.Text;
            tbxLoyaltyNumber.Visible = false;   
            lbxSelectStore.Visible = false;
            btnSelect.Visible = false;
            break1.Visible = false;
            break2.Visible = false;

        }
        //Else, reset the next section to be not visible.
        else
        {
            divBodyHidden.Visible = false;
        }
    }
    protected void btnAddProductToOrder_Click(object sender, EventArgs e)
    {
        //tracking variable for both inputs
        bool isValidProductAndQuantity = true;

        //Check for a selected product
        ListItem selectedProductLbxItem = lbxSelectProduct.SelectedItem;
        if (selectedProductLbxItem == null)
        {
            lblWarningProduct.Visible = true;
            isValidProductAndQuantity = false;
        }
        //Reset warning visibility
        else
        {
            lblWarningStore.Visible = false;
        }

        //Check to make sure quantity is a number and isn't empty.
        if (tbxSelectQuantity.Text.Length == 0)
        {
            lblWarningQuantityEmpty.Visible = true;
            isValidProductAndQuantity = false;
        }
        else
        {
            lblWarningQuantityEmpty.Visible = false;
        }

        //Validate quantity is an integer and not equal to 0
        int quantity = 0;
        if (!lblWarningQuantityEmpty.Visible)
        {
            //Check for quantity being an integer and != 0
            bool isQuantityAnInt = int.TryParse(tbxSelectQuantity.Text, out quantity);
            if (!isQuantityAnInt || quantity <= 0)
            {
                lblWarningQuantityNaN.Visible = true;
                isValidProductAndQuantity = false;
            }
            //Reset visibility
            else
            {
                lblWarningQuantityNaN.Visible = false;
            }
        }
        //Reset visibility
        else
        {
            lblWarningQuantityNaN.Visible = false;
        }


        if (isValidProductAndQuantity)
        {
            int selectedProductId = int.Parse(selectedProductLbxItem.Value);
            if (((global_asax)this.Context.ApplicationInstance).orderInformation.ShoppingCart.ContainsKey(selectedProductId))
            {
                ((global_asax)this.Context.ApplicationInstance).orderInformation.ShoppingCart[selectedProductId] += quantity;
            }
            else
            {
                ((global_asax)this.Context.ApplicationInstance).orderInformation.ShoppingCart.Add(selectedProductId, quantity);
            }
            //show the user whats in their cart
            lblCurrentShoppingCart.Text = "";
            //Reset empty cart warning if you add a product to the cart.
            lblWarningEmptyCart.Visible = false;
            using (GroceryStoreSimulatorContext context = new GroceryStoreSimulatorContext())
            {
                
                foreach (var product in ((global_asax)this.Context.ApplicationInstance).orderInformation.ShoppingCart)
                {
                    var selectedProduct = context.Product.Include(x => x.Name).FirstOrDefault(x => x.ProductID == product.Key);
                   
                    lblCurrentShoppingCart.Text += "<br />" + "Item: " + selectedProduct.Name.Name.Trim() + "  -  Quantity: " + product.Value + " - $" + product.Value * Math.Round(selectedProduct.InitialPricePerSellableUnit, 2);
                }
            }
        }
    }
    protected void btnSubmitOrder_Click(object sender, EventArgs e)
    {
        if (((global_asax)this.Context.ApplicationInstance).orderInformation.ShoppingCart.Any())
        {
            decimal totalOrderCost = 0;
            ((global_asax)this.Context.ApplicationInstance).orderInformation.StoreId = int.Parse(lbxSelectStore.SelectedItem.Value);
            ((global_asax)this.Context.ApplicationInstance).orderInformation.LoyaltyNumber = double.Parse(tbxLoyaltyNumber.Text);

            //Open DB connection and save the order.
            using (GroceryStoreSimulatorContext context = new GroceryStoreSimulatorContext())
            {
                int loyaltyId = 0;
                var loyalties = context.Loyalty.ToList();
                foreach (var loyalty in loyalties)
                {
                    if (double.Parse(loyalty.LoyaltyNumber.Trim()) == ((global_asax)this.Context.ApplicationInstance).orderInformation.LoyaltyNumber)
                    {
                        loyaltyId = loyalty.LoyaltyID;
                        break;
                    }
                }
                TableOrder tableOrder = new TableOrder()
                {
                    LoyaltyID = loyaltyId,
                    DateTimeCreated = DateTime.Now,
                    OrderStatusID = context.OrderStatus.FirstOrDefault(x => x.IsOpen).OrderStatusID,
                    StoreID = ((global_asax)this.Context.ApplicationInstance).orderInformation.StoreId
                };

                context.Order.Add(tableOrder);
                context.SaveChanges();
                var tableOrderSaved = context.Entry(tableOrder);
                ((global_asax)this.Context.ApplicationInstance).orderInformation.OrderNumber = tableOrderSaved.Entity.OrderID;

                foreach (var product in ((global_asax)this.Context.ApplicationInstance).orderInformation.ShoppingCart)
                {
                    decimal totalCost = 0;
                    totalCost = context.Product.FirstOrDefault(x => x.ProductID == product.Key).InitialPricePerSellableUnit * product.Value;
                    totalOrderCost += totalCost;
                    TableOrderDetail tableOrderDetail = new TableOrderDetail()
                    {
                        OrderID = tableOrderSaved.Entity.OrderID,
                        ProductID = product.Key,
                        Quantity = product.Value,
                        TotalAmountChargedToCustomer = totalCost
                    };
                    context.OrderDetail.Add(tableOrderDetail);
                    context.SaveChanges();
                }
            }
        ((global_asax)this.Context.ApplicationInstance).orderInformation.TotalOrderCost = totalOrderCost;
            Response.Redirect("/OrderConfirmation.aspx");
        }
        else
        {
            lblWarningEmptyCart.Visible = true;
        }
    }

    protected void btnResetOrder_Click(object sender, EventArgs e)
    {
        ((global_asax)this.Context.ApplicationInstance).orderInformation.ShoppingCart = new Dictionary<int, int>();
        lblCurrentShoppingCart.Text = "";
        
    }
}