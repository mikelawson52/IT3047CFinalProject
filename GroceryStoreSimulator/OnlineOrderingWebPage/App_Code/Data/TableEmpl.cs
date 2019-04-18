using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Empl
/// </summary>
[Table("tEmpl")]
public class TableEmpl
{
    public TableEmpl(){ }

    [Key]
    public int EmplID { get; set; }
    public string Empl { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int? StoreID { get; set; }
    public int? EmplTitleID { get; set; }
    public bool IsSelfScan { get; set; }
    public DateTime? DateStamp { get; set; }
}