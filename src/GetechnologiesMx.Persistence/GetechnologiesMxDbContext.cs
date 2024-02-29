using GetechnologiesMx.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GetechnologiesMx.Persistence {

    public class GetechnologiesMxDbContext : DbContext {
        public GetechnologiesMxDbContext(DbContextOptions<GetechnologiesMxDbContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set;}
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GetechnologiesMxDbContext).Assembly);
        }

    }
}