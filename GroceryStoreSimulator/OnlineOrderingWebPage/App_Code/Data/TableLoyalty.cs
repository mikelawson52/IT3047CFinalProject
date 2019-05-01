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
/// Summary description for tLoyalty
/// </summary>
[Table("tLoyalty")]
public class TableLoyalty
{
    public TableLoyalty() { }

    [Key]
    public int LoyaltyID { get; set; }
    public string LoyaltyNumber { get; set; }
    public int StoreID { get; set; }
    public DateTime DateOfIssue { get; set; }
    public string ZipCode { get; set; }
    [ForeignKey("LoyaltyStatus")]
    public int? LoyaltyStatusId { get; set; }

    //FK Relationship Builder
    public TableLoyaltyStatus LoyaltyStatus { get; set; }
    public ICollection<TableOrder> Orders { get; set; }
}