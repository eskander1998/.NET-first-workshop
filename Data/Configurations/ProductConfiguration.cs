using System;
using System.Collections.Generic;
using System.Text;
using GP.Domain.Entities;
//
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GP.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Many to Many configuration
            builder.HasMany(p => p.Providers)
            .WithMany(pr => pr.Products)
            .UsingEntity(
            j => j.ToTable("Providings"));//Table d'association;


            builder.Property(p => p.Description).HasMaxLength(200).IsRequired(false);
            //One To Many
            builder.HasOne(p => p.MyCategory)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            ////Inheritance
            builder.HasDiscriminator<int>("IsBiological")
             .HasValue<Product>(0)
             .HasValue<Biological>(1)
             .HasValue<Chemical>(2);
           
            





        }
    }
}
