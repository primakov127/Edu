using Microsoft.EntityFrameworkCore;
using MoneyManager.DataAccess.Extensions;
using MoneyManager.DataAccess.Models;
using System;

namespace MoneyManager.DataAccess.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Category>().Property(c => c.Id).HasColumnType("uniqueidentifier").IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnType("nvarchar(64)").IsRequired();
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Category>().Property(c => c.Type).HasConversion<int>().IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.ParentId).HasColumnType("uniqueidentifier").IsRequired(false);
            modelBuilder.Entity<Category>().Property(c => c.Color)
                .HasColumnType("int")
                .HasConversion(
                    v => Int32.Parse(v.Replace("#", String.Empty), System.Globalization.NumberStyles.HexNumber),
                    v => $"#{v:X}")
                .HasDefaultValue("#233D4D")
                .IsRequired();

            modelBuilder.Entity<Asset>().ToTable("Asset");
            modelBuilder.Entity<Asset>().Property(a => a.Id).HasColumnType("uniqueidentifier").IsRequired();
            modelBuilder.Entity<Asset>().Property(a => a.Name).HasColumnType("nvarchar(64)").IsRequired();
            modelBuilder.Entity<Asset>().Property(a => a.UserId).HasColumnType("uniqueidentifier").IsRequired();

            modelBuilder.Entity<Transaction>().ToTable("Transaction");
            modelBuilder.Entity<Transaction>().Property(t => t.Id).HasColumnType("uniqueidentifier").IsRequired();
            modelBuilder.Entity<Transaction>().Property(t => t.CategoryId).HasColumnType("uniqueidentifier").IsRequired();
            modelBuilder.Entity<Transaction>().Property(t => t.Amount).HasColumnType("decimal(16, 3)").IsRequired();
            modelBuilder.Entity<Transaction>().Property(t => t.Date).HasColumnType("datetime2(7)").IsRequired();
            modelBuilder.Entity<Transaction>().Property(t => t.AssetId).HasColumnType("uniqueidentifier").IsRequired();
            modelBuilder.Entity<Transaction>().Property(t => t.Comment).HasColumnType("nvarchar(1024)").IsRequired(false);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnType("uniqueidentifier").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Name).HasColumnType("nvarchar(64)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnType("nvarchar(64)").IsRequired();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().Property(u => u.Hash).HasColumnType("nvarchar(1024)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Salt).HasColumnType("nvarchar(1024)").IsRequired();

            modelBuilder.Seed();
        }
    }
}
