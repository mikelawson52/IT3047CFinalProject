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
    public DbSet<Loyalty> Loyalty { get; set; }
    //public DbSet<Empl> Empl { get; set; }
    //public DbSet<EmplStatus> EmplStatus { get; set; }
    //public DbSet<EmplTitle> EmplTitle { get; set; }
    //public DbSet<LoyaltyStatus> LoyaltyStatus { get; set; }
    //public DbSet<Order> Order { get; set; }
    //public DbSet<OrderDetail> OrderDetail { get; set; }
    //public DbSet<OrderStatus> OrderStatus { get; set; }
    //public DbSet<Product> Product { get; set; }
    //public DbSet<Store> Store { get; set; }
    //public DbSet<StoreStatus> StoreStatus { get; set; }
    //public DbSet<Transaction> Transaction { get; set; }
    //public DbSet<TransactionDetail> TransactionDetail { get; set; }
}