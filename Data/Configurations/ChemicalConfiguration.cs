using System;
using System.Collections.Generic;
using System.Text;
using GP.Domain.Entities;
//
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GP.Data.Configurations
{
    public class ChemicalConfiguration : IEntityTypeConfiguration<Chemical>
    {
        public void Configure(EntityTypeBuilder<Chemical> builder)
        {
            builder.OwnsOne(c => c.MyAddress, myadd =>
            {
                myadd.Property(a =>
                a.StreetAdress).HasColumnName("MyStreet").HasMaxLength(50);
                myadd.Property(a => a.City).HasColumnName("MyCity").IsRequired();
            });

        }
    }
}
