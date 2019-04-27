using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (GroceryStoreSimulatorContext context = new GroceryStoreSimulatorContext())
        {
            //Get store statuses.
            var storeStatuses = context.StoreStatus.ToList();
            //Get all store statuses that can't be ordered from.
            var unavailableStoreStatusIds = storeStatuses.Where(x => x.IsClosedForever || !x.AcceptingOnlineOrders).Select(x => x.StoreStatusID);
            //Get stores
            var storeSelectionOptions = context.Store.ToList();
            //Get store history, join/include store status, group by store
            var storeHistory = context.StoreHistory.Include(x => x.StoreStatus).GroupBy(x => x.StoreID);
            //Go through every store group in store history
            foreach (var storeHistoryRow in storeHistory)
            {
                //Get the newest store history record in a store group in order to determine the store's current status.
                var newestStoreHistoryRecord = storeHistoryRow.OrderByDescending(x => x.StoreHistoryID).FirstOrDefault();
                //Check if the store is currently unavailable to order from and remove it from the selection list if it is unavailable.
                if (unavailableStoreStatusIds.Contains(newestStoreHistoryRecord.StoreStatus.StoreStatusID))
                {
                    var storeToRemove = storeSelectionOptions.FirstOrDefault(x => x.StoreID == newestStoreHistoryRecord.StoreID);
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