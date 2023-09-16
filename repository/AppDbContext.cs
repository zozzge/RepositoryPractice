using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = ZOZGEDR\\ZOZGE; Database = Repository; Trusted_Connection = True; MultipleActiveResultSets=True");

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Order>()
        //        .HasMany(o => o.Items)
        //        .WithOne(i => i.Order)
        //        .HasForeignKey(i => i.OrderId)
        //        .IsRequired();

        //}

    }

}
