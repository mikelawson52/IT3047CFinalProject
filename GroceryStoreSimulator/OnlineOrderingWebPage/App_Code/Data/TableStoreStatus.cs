using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StoreStatus
/// </summary>
/// 
[Table("tStoreStatus")]
public class TableStoreStatus
{
    public TableStoreStatus() { }

    [Key]
    public int StoreStatusID { get; set; }
    public string StoreStatus { get; set; }
    public bool IsOpenForBusiness { get; set; }
    public bool IsClosedForever { get; set; }
    public bool AppliesToVirtualStores { get; set; }
    public bool AppliesToPhysicalStores { get; set; }
    public bool AcceptingOnlineOrders { get; set; }
}