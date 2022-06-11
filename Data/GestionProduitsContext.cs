using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

using GP.Domain.Entities;
using GP.Data.Configurations;
using System.Linq;

namespace GP.Data
{
    public class GestionProduitsContext : DbContext
    {
        public GestionProduitsContext()
        {
            //this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public GestionProduitsContext(DbContextOptions<GestionProduitsContext> options) : base(options)
        {

        }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new FactureConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ChemicalConfiguration());
            modelBuilder.Entity<Chemical>()
            .OwnsOne(s => s.MyAddress);
            foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(string) && p.Name.StartsWith("Name")))
            {
                property.SetColumnName("MyName");
            }


        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies()
        //       .UseSqlServer(@"Server=localhost;Database=GestionProduitDb;Trusted_Connection=True;");
        //}
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Chemical> Chemicals { get; set; }

        public DbSet<Biological> Biologicals { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Facture> Factures { get; set; }
    }
}
