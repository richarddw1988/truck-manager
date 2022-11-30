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
    public class MapBase<T> : IEntityTypeConfiguration<T>
           where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired().HasColumnName("ID").IsUnicode();
        }
    }
}
