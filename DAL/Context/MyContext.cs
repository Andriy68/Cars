using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DATA.Models;

namespace DATA.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDesc> Descriptions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Seller> Sellers{ get; set; }
        public DbSet<Worker> Workers{ get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=CarsDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasOne(o => o.Seller).WithMany(o => o.Cars).HasForeignKey(o => o.SellerID);
            modelBuilder.Entity<Car>().HasOne(o => o.Description).WithOne(o => o.Car).HasForeignKey<CarDesc>(o => o.CarID);
            modelBuilder.Entity<Order>().HasOne(o => o.Car).WithMany(o => o.Orders).HasForeignKey(o => o.CarID);
            modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany(o => o.Orders).HasForeignKey(o => o.CustomerID);
            modelBuilder.Entity<Order>().HasMany(o => o.Workers).WithMany(o => o.Orders).UsingEntity(o => o.ToTable("WorkerOrders"));
        }
    }
}
