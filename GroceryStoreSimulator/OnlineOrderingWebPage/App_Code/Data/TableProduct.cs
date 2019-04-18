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
    public int? BrandID { get; set; }
    public decimal? InitialPricePerSellableUnit { get; set; }
    public int NameID { get; set; }
    public string Description { get; set; }
}