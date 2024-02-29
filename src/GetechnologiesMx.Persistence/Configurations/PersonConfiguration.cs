using GetechnologiesMx.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetechnologiesMx.Persistence.Configurations {
    public class PersonConfiguration : IEntityTypeConfiguration<Person> {
        public void Configure(EntityTypeBuilder<Person> builder) {

            builder.ToTable("Person")
                   .HasMany(p => p.Invoices)
                   .WithOne(i => i.Person)
                   .HasForeignKey(i => i.Identification) 
                   .HasPrincipalKey(p => p.Identification);


        }
    }
}
