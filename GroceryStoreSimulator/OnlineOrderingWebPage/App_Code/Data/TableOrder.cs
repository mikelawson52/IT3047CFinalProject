using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Order
/// </summary>
[Table("tOrder")]
public class TableOrder
{
    public TableOrder(){ }

    [Key]
    public int OrderID { get; set; }
    public int LoyaltyID { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public int StoreID { get; set; }
    public int OrderStatusID { get; set; }
    public decimal DeliveryCharge { get; set; }
    public string Notes { get; set; }
    public string DeliveryAddress { get; set; }
    public DateTime? DateTimeDelivered { get; set; }
    public bool? AllOrNone { get; set; }
}