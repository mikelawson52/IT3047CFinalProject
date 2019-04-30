/************************************************
 * Authors: Tiffany Litteral and Mike Lawson
 * Final Project
 * IT3047C Fall 2019
 * Description:
 * This is the form to display all content submitted to the customer online through the database to confirm their order. 
 * 
*************************************************/
using ASP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

public partial class OrderConfirmation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (GroceryStoreSimulatorContext context = new GroceryStoreSimulatorContext())
        {
            
            foreach (var product in ((global_asax)this.Context.ApplicationInstance).orderInformation.ShoppingCart)
            {
                var productInDB = context.Product.Include(x => x.Name).FirstOrDefault(x => x.ProductID == product.Key);
                //todo - add actual product names
                lblOrderInfo.Text += "<br />" + "Item: " + productInDB.Name.Name.Trim() + "  -  Quantity: " + product.Value;
            }
            lblOrderInfo.Text += "<br />" + "Total Order Cost: " + ((global_asax)this.Context.ApplicationInstance).orderInformation.TotalOrderCost;
        }
        //Reset the session variable now that the order is placed.
        ((global_asax)this.Context.ApplicationInstance).orderInformation = new OrderInformation();
    }
}