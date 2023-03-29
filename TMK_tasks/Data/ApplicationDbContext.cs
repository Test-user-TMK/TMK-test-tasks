using Microsoft.EntityFrameworkCore;
using TMK_tasks.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMK_tasks.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<SteelType> SteelTypes { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasOne(ea => ea.Manufacturer)
            .WithMany(e => e.Orders)
            .HasForeignKey(ea => ea.ManufacturerId);

            modelBuilder.Entity<Order>()
            .HasOne(ea => ea.State)
            .WithMany(e => e.Orders)
            .HasForeignKey(ea => ea.StateId);

            modelBuilder.Entity<Position>()
            .HasOne(ea => ea.Order)
            .WithMany(e => e.Positions)
            .HasForeignKey(ea => ea.OrderId);

            modelBuilder.Entity<Position>()
            .HasOne(ea => ea.SteelType)
            .WithMany(e => e.Positions)
            .HasForeignKey(ea => ea.SteelTypeId);

            modelBuilder.Entity<Position>()
            .HasOne(ea => ea.State)
            .WithMany(e => e.Positions)
            .HasForeignKey(ea => ea.StateId);
        }
    }
}