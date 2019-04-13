using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderDetail
/// </summary>
/// 
[Table("tOrderDetail")]
public class TableOrderDetail
{
    public TableOrderDetail(){ }

    [Key]
    public int OrderDetailID { get; set; }
    public int OrderID { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmountChargedToCustomer { get; set; }
    public string Comment { get; set; }
    public int? CouponDetailID { get; set; }
    public bool UnavailableWhenOrderWasFilled { get; set; }
}