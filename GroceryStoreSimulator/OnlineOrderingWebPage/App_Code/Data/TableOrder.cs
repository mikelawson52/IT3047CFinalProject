/**********************************************
 * Name: Mike Lawson and Tiffany Litteral 
 * Final Project 
 * IT3047C/001/Spring 2019
 * 05/01/2019
 * *******************************************/
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
    [ForeignKey("Loyalty")]
    public int LoyaltyID { get; set; }
    public DateTime DateTimeCreated { get; set; }
    [ForeignKey("Store")]
    public int StoreID { get; set; }
    [ForeignKey("OrderStatus")]
    public int OrderStatusID { get; set; }
    public decimal DeliveryCharge { get; set; }
    public string Notes { get; set; }
    public string DeliveryAddress { get; set; }
    public DateTime? DateTimeDelivered { get; set; }
    public bool? AllOrNone { get; set; }

    //FK Relation Builder
    public TableLoyalty Loyalty { get; set; }
    public TableStore Store { get; set; }
    public TableOrderStatus OrderStatus { get; set; }
}