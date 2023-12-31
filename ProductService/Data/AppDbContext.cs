﻿using Microsoft.EntityFrameworkCore;
using ProductService.Data.Faker;
using ProductService.Models;

namespace ProductService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var productGenerator = new ProductGenerator();

            modelBuilder
                .Entity<Product>()
                .HasData(productGenerator.Generate(100));
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
    }
}