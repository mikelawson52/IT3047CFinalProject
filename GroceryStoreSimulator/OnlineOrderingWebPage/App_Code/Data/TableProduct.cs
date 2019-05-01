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
[Table("tProduct")]
public class TableProduct
{
    public TableProduct(){ }

    [Key]
    public int ProductID { get; set; }
    public string Status { get; set; }
    [Column("UPC-E")]
    public string UPC_E { get; set; }
    [Column("UPC-A")]
    public string UPC_A { get; set; }
    public int? ManufacturerID { get; set; }
    [ForeignKey("Brand")]
    public int? BrandID { get; set; }
    public decimal InitialPricePerSellableUnit { get; set; }
    [ForeignKey("Name")]
    public int NameID { get; set; }
    public string Description { get; set; }
    [ForeignKey("Container")]
    public int? ContainerID { get; set; }
    public double? Size { get; set; }

    //FK relationship builder
    public TableName Name { get; set; }
    public TableBrand Brand { get; set; }
    public TableContainer Container { get; set; }
}