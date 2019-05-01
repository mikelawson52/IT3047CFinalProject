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
/// Summary description for Empl
/// </summary>
[Table("tEmpl")]
public class TableEmpl
{
    public TableEmpl() { }

    [Key]
    public int EmplID { get; set; }
    public string Empl { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    [ForeignKey("Store")]
    public int? StoreID { get; set; }

    [ForeignKey("EmplTitle")]
    public int? EmplTitleID { get; set; }
    public bool IsSelfScan { get; set; }
    public DateTime? DateStamp { get; set; }

    //Foreign key builders
    public TableStore Store { get; set; }
    public TableEmplTitle EmplTitle { get; set; }
}