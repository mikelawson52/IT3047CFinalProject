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
                var loyaltyNumbers = context.Loyalty.Include(x => x.LoyaltyStatus).ToList();
                //Loop through each loyalty number
                foreach (var loyaltyNumber in loyaltyNumbers)
                {
                    //If the loyalty number in the DB matches the loyalty number entered, and the loyalty number is active, and the loyalty number can place online orders, mark it as a usable #.
                    if (loyaltyNumber.LoyaltyNumber.Trim().Equals(number.ToString()) && loyaltyNumber.LoyaltyStatus.IsActive && loyaltyNumber.LoyaltyStatus.CanPlaceOnlineOrder)
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
        if (isSectionComplete)
        {
            using (GroceryStoreSimulatorContext context = new GroceryStoreSimulatorContext())
            {
                //var products = context.Product.Include(x => x.)
            }
            divBodyHidden.Visible = true;
        }
        //Make sure the page was completely valid.  If it was, display the next options.
        divBodyHidden.Visible = isSectionComplete ? true : false;
    }

    protected void btnSubmitOrder_Click(object sender, EventArgs e)
    {

        //OrderInformation order = new OrderInformation(tbxLoyaltyNumber.Text, lbxSelectStore.SelectedItem.ToString());
    }
}