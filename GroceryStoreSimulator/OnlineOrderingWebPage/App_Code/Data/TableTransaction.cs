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
/// Summary description for Transaction
/// </summary>
/// 
[Table("tTransaction")]
public class TableTransaction
{
    public TableTransaction(){ }

    [Key]
    public int TransactionID { get; set; }
    public TimeSpan TimeOfTransaction { get; set; }
    public DateTime DateOfTransaction { get; set; }
    public int StoreID { get; set; }
    public int LoyaltyID { get; set; }
    public int TransactionTypeID { get; set; }
    public int EmplID { get; set; }
    public string Comment { get; set; }
    public DateTime? DateEntered { get; set; }
    public int? OrderID { get; set; }
    public int? MethodOfPaymentID { get; set; }
}