using Application.IO.Core.Context.Extensions;
using Application.IO.Core.Domain.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.IO.Core.Context.Mappings.System
{
    public class PostalCodeAdressMapping : EntityTypeConfiguration<PostalCodeAdress>
    {
        public override void Map(EntityTypeBuilder<PostalCodeAdress> builder)
        {
            builder.Property(e => e.Code).HasColumnType("varchar(8)");
            builder.Property(e => e.Place).HasColumnType("varchar(100)");
            builder.Property(e => e.Neighborhood).HasColumnType("varchar(100)");
            builder.Property(e => e.City).HasColumnType("varchar(50)");
            builder.Property(e => e.State).HasColumnType("varchar(2)");
            builder.Property(e => e.StateName).HasColumnType("varchar(30)");
            builder.Property(e => e.Country).HasColumnType("varchar(40)");
            builder.Property(e => e.Date).HasColumnType("datetime");

            builder.HasIndex(i => i.Code).IsUnique().HasName("IDX_Code");

            builder.ToTable("PostalCodeAdress");
        }
    }
}
