using GetechnologiesMx.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GetechnologiesMx.Persistence.Contracts {
    public interface IInvoiceRepository : IBaseRepository<Invoice> {
        DbSet<Invoice> Invoices { get; }
    }
}
