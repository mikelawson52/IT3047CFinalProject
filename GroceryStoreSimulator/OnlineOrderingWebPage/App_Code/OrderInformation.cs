using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// This class holds all Order informaton for orders submitted through Default.Asax 
/// </summary>
public class OrderInformation
{
    public OrderInformation()
    {
        ShoppingCart = new Dictionary<int, int>();
    }
    public Dictionary<int, int> ShoppingCart { get; set; }
    public double LoyaltyNumber { get; set; }
    public int StoreId { get; set; }
    public decimal TotalOrderCost { get; set; }
    public int OrderNumber { get; set; }
}