using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        using(GroceryStoreSimulatorContext context = new GroceryStoreSimulatorContext())
        {
            //All DB Context Tests.
            //var test1 = context.Empl.Take(100).ToList();
            //var test2 = context.EmplStatus.ToList();
            //var test3 = context.EmplTitle.ToList();
            //var test4 = context.Loyalty.ToList();
            //var test5 = context.LoyaltyStatus.ToList();
            //var test6 = context.Order.ToList();
            //var test7 = context.OrderDetail.ToList();
            //var test8 = context.OrderStatus.ToList();
            //var test9 = context.Product.ToList();
            //var test10 = context.Store.ToList();
            //var test11 = context.StoreStatus.ToList();
            //var test12 = context.Transaction.Take(100).ToList();
            //var test13 = context.TransactionDetail.Take(100).ToList();
            //var test14 = context.StoreHistory.Take(500).ToList();
            //var test15 = context.Order
            //    .Include(x => x.Store)
            //    .Where(x => x.Store.State == "OH")
            //    .ToList();
            //var test16 = context.Name.ToList();
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        // Verify the data entered by the user. 
        double number;
        // Checks if the loyalty number contains digits. 
        bool success = Double.TryParse(tbxLoyaltyNumber.Text, out number);
        // Make the selected store a string for verification.
        String selectedStore = lbxSelectStore.Text.ToString();
        if (tbxLoyaltyNumber.Text.Length != 0 && success && selectedStore.Length != 0)
        {
            // When a user clicks the select button, display Products and Quantity Textbox for each product a user selects.
            divBodyHidden.Visible = true;
        }
        else if (tbxLoyaltyNumber.Text.Length == 0 && selectedStore.Length != 0)
        {
            // If the number is not entered give a warning
            divWarningLoyalty.Visible = true;
            lblLoyalty1.Visible = true;
        }
        else if (!success && tbxLoyaltyNumber.Text.Length != 0 && selectedStore.Length == 0)
        {
            // If the number is not a digit give a warning.
            divWarningLoyalty.Visible = true;
            lblLoyalty2.Visible = true;
            divWarningStore.Visible = true;
        }
        else if (tbxLoyaltyNumber.Text.Length !=0 && success && selectedStore.Length ==0)
        {
            // If the store is not selected give a warning
            divWarningStore.Visible = true;
        }
        else if (!success && tbxLoyaltyNumber.Text.Length !=0 && selectedStore.Length != 0)
        {
            //If the loyalty number is not a digit and store is not selected give a warning
            divWarningLoyalty.Visible = true;
            lblLoyalty2.Visible = true;
            divWarningStore.Visible = true;

        }
       else
        {
            // Any other cases give a warning. 
            Response.Write("There was an error submitting your request. Please check your entries and try again.");
            Response.Write("From Default.asax, Ln 60");
        }
    }

    protected void btnSubmitOrder_Click(object sender, EventArgs e)
    {

        //OrderInformation order = new OrderInformation(tbxLoyaltyNumber.Text, lbxSelectStore.SelectedItem.ToString());
    }
}