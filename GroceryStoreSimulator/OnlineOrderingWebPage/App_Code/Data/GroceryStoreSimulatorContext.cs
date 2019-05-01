/**********************************************
 * Name: Mike Lawson and Tiffany Litteral 
 * Final Project 
 * IT3047C/001/Spring 2019
 * 05/01/2019
 * *******************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GroceryStoreSimulatorContext
/// </summary>
public class GroceryStoreSimulatorContext : DbContext
{
    public DbSet<TableLoyalty> Loyalty { get; set; }
    public DbSet<TableEmpl> Empl { get; set; }
    public DbSet<TableEmplStatus> EmplStatus { get; set; }
    public DbSet<TableEmplTitle> EmplTitle { get; set; }
    public DbSet<TableLoyaltyStatus> LoyaltyStatus { get; set; }
    public DbSet<TableOrder> Order { get; set; }
    public DbSet<TableOrderDetail> OrderDetail { get; set; }
    public DbSet<TableOrderStatus> OrderStatus { get; set; }
    public DbSet<TableProduct> Product { get; set; }
    public DbSet<TableStore> Store { get; set; }
    public DbSet<TableStoreStatus> StoreStatus { get; set; }
    public DbSet<TableTransaction> Transaction { get; set; }
    public DbSet<TableTransactionDetail> TransactionDetail { get; set; }
    public DbSet<TableStoreHistory> StoreHistory { get; set; }
    public DbSet<TableName> Name { get; set; }
}