using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tLoyalty
/// </summary>
[Table("tLoyalty")]
public class Loyalty
{
    [Key]
    public int LoyaltyID { get; set; }
    public string LoyaltyNumber { get; set; }
    public int StoreID { get; set; }
    public DateTime DateOfIssue { get; set; }
    public string ZipCode { get; set; }
    public int LoyaltyStatusId { get; set; }
}