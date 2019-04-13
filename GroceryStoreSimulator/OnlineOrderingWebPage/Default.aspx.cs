using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        using(GroceryStoreSimulatorContext context = new GroceryStoreSimulatorContext())
        {
            //All DB Context's work.  Need to build forign key relationships still.
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
        }
    }
}