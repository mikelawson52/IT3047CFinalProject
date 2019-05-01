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
/// Summary description for OrderDetail
/// </summary>
/// 
[Table("tOrderDetail")]
public class TableOrderDetail
{
    public TableOrderDetail(){ }

    [Key]
    public int OrderDetailID { get; set; }
    [ForeignKey("Order")]
    public int OrderID { get; set; }
    [ForeignKey("Product")]
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmountChargedToCustomer { get; set; }
    public string Comment { get; set; }
    public int? CouponDetailID { get; set; }
    public bool UnavailableWhenOrderWasFilled { get; set; }

    //FK Relation Builder
    public TableOrder Order { get; set; }
    public TableProduct Product { get; set; }
}