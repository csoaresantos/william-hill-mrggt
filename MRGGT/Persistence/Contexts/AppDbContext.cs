using System;
using Microsoft.EntityFrameworkCore;
using MRGGT.Models;

namespace MRGGT.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            CreatingCustomerModel(builder);
            CreatingBrandModel(builder);

        }

        private void CreatingCustomerModel(ModelBuilder builder)
        {
            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Customer>().HasKey(i => i.ID);
            builder.Entity<Customer>().Property(p => p.ID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Customer>().Property(p => p.FirstName);
            builder.Entity<Customer>().Property(p => p.LastName);
            builder.Entity<Customer>().Property(p => p.Address);
            builder.Entity<Customer>().Property(p => p.PersonalNumber);
            builder.Entity<Customer>().Property(p => p.FavoriteFootballTeam);
        }

        private void CreatingBrandModel(ModelBuilder builder)
        {
            builder.Entity<Brand>().ToTable("Brand");
            builder.Entity<Brand>().HasKey(k => k.Id);
            builder.Entity<Brand>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Brand>().Property(p => p.Name);
            builder.Entity<Brand>().HasMany(p => p.Customers).WithOne(p => p.Brand).HasForeignKey(f => f.BrandId);
        }
    }
}
