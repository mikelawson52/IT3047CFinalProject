using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TransactionDetail
/// </summary>
/// 
[Table("tTransactionDetail")]
public class TableTransactionDetail
{
    public TableTransactionDetail(){ }

    [Key]
    public int TransactionDetailID { get; set; }
    public int? TransactionID { get; set; }
    public int? ProductID { get; set; }
    public int? QtyOfProduct { get; set; }
    public decimal? PricePerSellableUnitAsMarked { get; set; }
    public decimal? TotalPrice { get; set; }
    public string Comment { get; set; }
    public int? CouponDetailID { get; set; }
    public decimal? PricePerSellableUnitToTheCustomer { get; set; }
}