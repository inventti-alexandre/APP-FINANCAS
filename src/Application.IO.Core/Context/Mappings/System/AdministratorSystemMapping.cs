using Application.IO.Core.Context.Extensions;
using Application.IO.Core.Domain.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.IO.Core.Context.Mappings.System
{
    public class AdministratorSystemMapping : EntityTypeConfiguration<AdministratorSystem>
    {
        public override void Map(EntityTypeBuilder<AdministratorSystem> builder)
        {
            builder.ToTable("AdministratorsSystem");

            builder.HasOne(e => e.ApplicationUser)
                .WithMany(o => o.AdmUsersSystem)
                .HasForeignKey(e => e.IdApplicationUser);
        }
    }
}
