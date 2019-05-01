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
/// Summary description for OrderStatus
/// </summary>
/// 
[Table("tOrderStatus")]
public class TableOrderStatus
{
    public TableOrderStatus(){ }

    [Key]
    public int OrderStatusID { get; set; }
    public string OrderStatus { get; set; }
    public bool IsOpen { get; set; }
    public bool IsDelivered { get; set; }
    public bool IsClosed { get; set; }

    //FK relation builder
    public ICollection<TableOrder> Orders { get; set; }
}