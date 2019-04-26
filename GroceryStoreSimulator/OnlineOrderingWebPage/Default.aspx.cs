using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (GroceryStoreSimulatorContext context = new GroceryStoreSimulatorContext())
        {
            //All DB Context's work.  Need to build forign key relationships still.
            /*****
                var test1 = context.Empl.Take(100).ToList();
                var test2 = context.EmplStatus.ToList();
                var test3 = context.EmplTitle.ToList();
                var test4 = context.Loyalty.ToList();
                var test5 = context.LoyaltyStatus.ToList();
                var test6 = context.Order.ToList();
                var test7 = context.OrderDetail.ToList();
                var test8 = context.OrderStatus.ToList();
                var test9 = context.Product.ToList();
                var test10 = context.Store.ToList();
                var test11 = context.StoreStatus.ToList();
                var test12 = context.Transaction.Take(100).ToList();
                var test13 = context.TransactionDetail.Take(100).ToList();
                var test14 = context.StoreHistory.Take(500).ToList();
               // var test15 = context.Order
                    .Include("Store")
                    .Where(x => x.Store.State == "OH")
                   .ToList();
             ******/

            var storeSelectionOptions = context.Store.ToList();
            lbxSelectStore.DataValueField = "StoreID";
            lbxSelectStore.DataTextField = "Store";
            lbxSelectStore.DataSource = storeSelectionOptions;
            lbxSelectStore.DataBind();
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        // Verify the data entered by the user. 
        double number;
        // Checks if the loyalty number contains digits. 
        bool success = Double.TryParse(tbxLoyaltyNumber.Text, out number);

        // Do not allow loyalty number to be left blank. 
        if (tbxLoyaltyNumber.Text.Length != 0)
        { // If the number is not entered give a warning
            divWarningLoyalty.Visible = true;
            lblLoyalty1.Visible = true;

        }
        else
        {
            divWarningLoyalty.Visible = false;
        }
    
        //Verify the Selection of the Selected store
        // Make the selected store a string for verification
   
        String selectedStore = lbxSelectStore.Text.ToString();
        //If there is no selected store give a warning
        if (selectedStore.Length != 0)
        {
            divWarningStore.Visible = true;

        }
        else
        {
            divWarningStore.Visible = false;
        }
              
       
        if (!success)
        {
            // If the number is not a digit give a warning.
            divWarningLoyalty.Visible = true;
            lblLoyalty2.Visible = true;
            
        }
        else
        {
            divWarningLoyalty.Visible = false;
            lblLoyalty2.Visible = false;
        }
       /***
            {
                // When a user clicks the select button, display Products and Quantity Textbox for each product a user selects.
                divBodyHidden.Visible = true;
            }
            // Any other cases give a warning. 
            Response.Write("There was an error submitting your request. Please check your entries and try again.");
            Response.Write("From Default.asax, Ln 60");
        }
        ******/
    }

    protected void btnSubmitOrder_Click(object sender, EventArgs e)
    {

        //OrderInformation order = new OrderInformation(tbxLoyaltyNumber.Text, lbxSelectStore.SelectedItem.ToString());
    }
}