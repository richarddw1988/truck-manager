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
    public class ModeloMap : MapBase<Modelo>
    {
        public override void Configure(EntityTypeBuilder<Modelo> builder)
        {
            base.Configure(builder);
            builder.ToTable("MODELO");
            builder.Property(c => c.Nome)
                .HasColumnType("VARCHAR")
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.Ativo)
                .HasColumnType("BIT")
                .HasColumnName("ATIVO")
                .IsRequired();
        }
    }
}
