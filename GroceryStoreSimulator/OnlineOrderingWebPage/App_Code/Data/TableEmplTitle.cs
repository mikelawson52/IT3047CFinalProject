﻿/**********************************************
 * Name: Mike Lawson and Tiffany Litteral 
 * Final Project 
 * IT3047C/001/Spring 2019
 * 05/01/2019
 * *******************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmplTitle
/// </summary>
[Table("tEmplTitle")]
public class TableEmplTitle
{
    public TableEmplTitle(){ }

    [Key]
    public int EmplTitleID { get; set; }
    public string EmplTitle { get; set; }
    public bool IsStoreManager { get; set; }
    public bool IsSelfScan { get; set; }

    //FK Builder
    public ICollection<TableEmpl> Empls { get; set; }
}