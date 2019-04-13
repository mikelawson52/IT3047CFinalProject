using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmplStatus
/// </summary>
[Table("tEmplStatus")]
public class TableEmplStatus
{
    public TableEmplStatus(){ }

    [Key]
    public int EmplStatusID { get; set; }
    public string EmplStatus { get; set; }
    public bool CanWork { get; set; }
    public bool IsEmployed { get; set; }
    public bool IsPermanent { get; set; }
}