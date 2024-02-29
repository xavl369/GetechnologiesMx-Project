
using GetechnologiesMx.Domain.Entities;

namespace GetechnologiesMx.Application.Contracts {
    public interface ISalesService
    {
        public Task<Invoice[]> FindInvoicesByPerson(string identification);
        public Task<Invoice> StoreInvoice(Invoice invoice);
    }
       
}
