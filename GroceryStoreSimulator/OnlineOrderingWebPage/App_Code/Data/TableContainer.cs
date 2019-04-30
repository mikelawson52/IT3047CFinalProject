using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Empl
/// </summary>
[Table("tContainer")]
public class TableContainer
{
    public TableContainer() { }

    [Key]
    public int ContainerID { get; set; }
    public string Container { get; set; }
}