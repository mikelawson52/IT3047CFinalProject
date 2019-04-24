using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoyaltyStatus
/// </summary>
/// 
[Table("tLoyaltyStatus")]
public class TableLoyaltyStatus
{
    public TableLoyaltyStatus() { }

    [Key]
    public int LoyaltyStatusID { get; set; }
    public string LoyaltyStatus { get; set; }
    public bool IsActive { get; set; }
    public bool IsSuspended { get; set; }
    public bool IsPending { get; set; }
    public bool CanPlaceOnlineOrder { get; set; }

    //FK relation builder
    public ICollection<TableLoyalty> Loyalties { get; set; }
}