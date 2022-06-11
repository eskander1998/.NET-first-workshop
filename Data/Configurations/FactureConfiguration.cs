using System;
using System.Collections.Generic;
using System.Text;
using GP.Domain.Entities;
//
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GP.Data.Configurations
{
    public class FactureConfiguration : IEntityTypeConfiguration<Facture>
    {
        public void Configure(EntityTypeBuilder<Facture> builder)
        {
            //le nom de la table au niveau de la BD
        
            builder.HasKey(f => new { f.ProductFk,f.ClientFk,f.DateAchat });//clé primaire compose

            // Configurer la cle etrangere
            builder.HasOne<Product>(f=>f.Product)
                .WithMany(p=>p.Factures)
                .HasForeignKey(f=>f.ProductFk);

            // Configurer la cle etrangere
            builder.HasOne<Client>(f => f.Client)
           .WithMany(p => p.Factures)
           .HasForeignKey(f => f.ClientFk);

           
        }
    }
}
