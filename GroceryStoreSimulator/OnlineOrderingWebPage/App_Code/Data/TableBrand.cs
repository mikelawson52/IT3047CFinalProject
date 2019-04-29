using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Empl
/// </summary>
[Table("tBrand")]
public class TableBrand
{
    public TableBrand() { }

    [Key]
    public int BrandID { get; set; }
    public string Brand { get; set; }
}