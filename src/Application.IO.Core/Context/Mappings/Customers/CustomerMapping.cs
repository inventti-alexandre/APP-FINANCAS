using Application.IO.Core.Context.Extensions;
using Application.IO.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.IO.Core.Context.Mappings.Customers
{
    public class CustomerMapping : EntityTypeConfiguration<Customer>
    {
        public override void Map(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasOne(e => e.ApplicationUser)
                .WithMany(o => o.Customers)
                .HasForeignKey(e => e.IdApplicationUser);
        }
    }
}
