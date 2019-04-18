using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        //When a user clicks the select button, display Products and Quantity Textbox for each product a user selects. 
        //lblSelectProduct.Visible = true;
        //lblSelectQuantity.Visible = true;
        //lbxSelectProduct.Visible = true;
        //tbxSelectQuantity.Visible = true;
        ///btnSubmitOrder.Visible = true;
        divBodyHidden.Visible = true;

    }

    protected void btnSubmitOrder_Click(object sender, EventArgs e)
    {
       
       //OrderInformation order = new OrderInformation(tbxLoyaltyNumber.Text, lbxSelectStore.SelectedItem);
    }
}