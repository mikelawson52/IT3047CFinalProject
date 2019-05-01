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
/// Summary description for Product
/// </summary>
/// 
[Table("tName")]
public class TableName
{
    public TableName() { }

    [Key]
    public int NameID { get; set; }
    public string Name { get; set; }
}