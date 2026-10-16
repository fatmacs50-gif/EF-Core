using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Entities.Data


{
    internal class AppDbContext : DbContext
    { 
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;


     protected  override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .ToTable("Orders", schema: "Sales")
                .HasKey(o => o.Id);


            modelBuilder.Entity<Product>()
                .ToTable("Products", schema: "Inventory")
                .HasKey(ip => ip.Id);


            modelBuilder.Entity<OrderDetail>() 
                .ToTable("OrderDetails", schema: "Sales")
                .HasKey(od => od.Id);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          var config=new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();


           string  ConStr = config.GetConnectionString("ConStr");
            optionsBuilder.UseSqlServer(ConStr);
        }
   
    }
}
