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
/// Summary description for Store
/// </summary>
/// 
[Table("tStore")]
public class TableStore
{
    public TableStore() { }

    [Key]
    public int StoreID { get; set; }
    public string Store { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public int ManagerID { get; set; }
    public string StoreNumber { get; set; }
    public bool IsVirtual { get; set; }
    public int CountryID { get; set; }

    //Foreign Key Table Relationship
    public ICollection<TableEmpl> Empls { get; set; }
    public ICollection<TableStoreHistory> StoreHistories { get; set; }
    public ICollection<TableOrder> Orders { get; set; }
}