using GetechnologiesMx.Domain.Entities;
using GetechnologiesMx.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GetechnologiesMx.Persistence.Repositories {
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository {

        public InvoiceRepository(GetechnologiesMxDbContext context) : base(context) { }

        public DbSet<Invoice> Invoices => _context.Invoices;

    }
}
