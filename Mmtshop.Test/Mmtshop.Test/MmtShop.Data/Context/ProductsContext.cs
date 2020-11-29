using Microsoft.EntityFrameworkCore;
using Mmtshop.Test.MmtShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmtshop.Test.MmtShop.Data.Context
{
    public class ProductsContext : DbContext
    {
        public ProductsContext()
        {

        }
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {

        }

        public virtual DbSet<Product> Product { get; set; }

        public virtual DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new InvalidOperationException("Cant run without configuring optionsBuilder");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Product>()
            .HasOne<Category>(p => p.category)
            .WithMany(g => g.productInfo)
            .HasForeignKey(p => p.CategoryID);




            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.ProductName).HasColumnName("ProductName").HasMaxLength(255);

                entity.Property(e => e.ProductDescription).HasColumnName("ProductDescription").HasMaxLength(255);

                entity.Property(e => e.SKU).HasColumnName("SKU").HasMaxLength(255);
                entity.Property(e => e.Price).HasColumnName("Price").HasColumnType("numeric(10,2)");

                entity.Property(e => e.CategoryID).HasColumnName("CategoryId");


            }
            );

            modelBuilder.Entity<Category> (entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.CategoryName).HasColumnName("CategoryName").HasMaxLength(255);
                entity.Property(e => e.CategoryDescription).HasColumnName("CategoryDescription").HasMaxLength(255);
                entity.Property(e => e.CategoryMinSkuRange).HasColumnName("CategoryMinSkuRange");
                entity.Property(e => e.CategoryMaxSkuRange).HasColumnName("CategoryMaxSkuRange");
                entity.Property(e => e.Featured).HasColumnName("Featured");
                
            });


        }
              
    }
}
