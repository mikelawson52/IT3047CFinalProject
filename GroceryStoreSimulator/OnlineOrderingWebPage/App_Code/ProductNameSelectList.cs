using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductNameSelectList
/// </summary>
public class ProductNameSelectList
{
    public ProductNameSelectList(TableProduct tableProduct)
    {
        this.VisibleOptionText = tableProduct.Name.Name + " - " + tableProduct.Description + " - " + tableProduct.Brand.Brand + " - $" + tableProduct.InitialPricePerSellableUnit + " - " + tableProduct.Container.Container + " " + tableProduct.Size + "Ct.";
        this.Name = tableProduct.Name.Name;
        this.Brand = tableProduct.Brand.Brand;
        this.ProductID = tableProduct.ProductID;
        this.UPC_A = tableProduct.UPC_A;
        this.InitialPricePerSellableUnit = tableProduct.InitialPricePerSellableUnit;
        this.Description = tableProduct.Description;
        this.Container = tableProduct.Container.Container;
        this.Size = tableProduct.Size;
    }
    public string VisibleOptionText { get; set; }
    public string Brand { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ProductID { get; set; }
    public string UPC_A { get; set; }
    public decimal? InitialPricePerSellableUnit { get; set; }
    public string Container { get; set; }
    public double? Size { get; set; }
}