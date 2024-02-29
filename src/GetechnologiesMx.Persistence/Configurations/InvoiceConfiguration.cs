using GetechnologiesMx.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetechnologiesMx.Persistence.Configurations {
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice> {
        public void Configure(EntityTypeBuilder<Invoice> builder) {

            builder.ToTable("Invoice")
                   .HasKey(i => i.Id);

            builder.Property(p => p.Amount)
                   .HasColumnType("decimal(18,2)");

        }
    }
}
