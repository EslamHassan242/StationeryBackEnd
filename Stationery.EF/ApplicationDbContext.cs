using Microsoft.EntityFrameworkCore;
using Stationery.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<OrdersDetails> OrdersDetails { get; set; }
        public virtual DbSet<Categories>  Categories { get; set; }
        public virtual DbSet<Units>  Units { get; set; }
        public virtual DbSet<ProductUnits>  ProductUnits { get; set; }
        public virtual DbSet<OrdersBuyDetails> OrdersBuyDetails { get; set; }
        public virtual DbSet<OrdersBuy> OrdersBuy { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrdersDetails>().HasOne(op => op.Order).WithMany(p => p.OrdersDetails).HasForeignKey(op => op.OrderId); 
            modelBuilder.Entity<OrdersDetails>().HasOne(op => op.Product).WithMany(p => p.OrdersDetails).HasForeignKey(op => op.ProductID);
            modelBuilder.Entity<ProductUnits>().HasOne(op => op.Products).WithMany(p => p.ProductUnits).HasForeignKey(op => op.ProductId);
            modelBuilder.Entity<ProductUnits>().HasOne(op => op.Units).WithMany(p => p.ProductUnits).HasForeignKey(op => op.UnitId);
            modelBuilder.Entity<OrdersBuyDetails>().HasOne(op => op.OrderBuy).WithMany(p => p.OrdersBuyDetails).HasForeignKey(op => op.OrderBuyId);
            modelBuilder.Entity<OrdersBuyDetails>().HasOne(op => op.OrderBuy).WithMany(p => p.OrdersBuyDetails).HasForeignKey(op => op.OrderBuyId);
        }

    }
}
