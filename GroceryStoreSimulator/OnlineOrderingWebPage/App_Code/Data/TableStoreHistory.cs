using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Store
/// </summary>
/// 
[Table("tStoreHistory")]
public class TableStoreHistory
{
    public TableStoreHistory() { }

    [Key]
    public int StoreHistoryID { get; set; }
    public int StoreID { get; set; }
    public DateTime StartDate { get; set; }
    public int StoreStatusID { get; set; }
    public string Comment { get; set; }
    public DateTime DateStamp { get; set; }

    //FK Table Relationships
    public TableStore Store { get; set; }
    public TableStoreStatus StoreStatus { get; set; }
}