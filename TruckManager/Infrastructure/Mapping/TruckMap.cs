using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckManager.Domain.Entity;

namespace TruckManager.Infrastructure.Mapping
{
    public class TruckMap : MapBase<Truck>
    {
        public override void Configure(EntityTypeBuilder<Truck> builder)
        {
            base.Configure(builder);
            builder.ToTable("TRUCK");
            builder.Property(c => c.Nome)
                .HasColumnType("VARCHAR")
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.AnoFabricacao)
                .HasColumnType("INT")
                .HasColumnName("ANO_FABRICACAO")
                .IsRequired();
            builder.Property(c => c.AnoModelo)
                .HasColumnType("INT")
                .HasColumnName("ANO_MODELO")
                .IsRequired();
            builder.Property(c => c.IdModelo)
                .HasColumnType("INT")
                .HasColumnName("ID_MODELO")
                .IsRequired();
            builder.HasIndex(c => c.IdModelo).IsUnique(false);
            builder.HasOne(c => c.Modelo)
                .WithOne()
                .HasForeignKey<Truck>(c => c.IdModelo); 
        }
    }
}
