using GetechnologiesMx.Application.Contracts;
using GetechnologiesMx.Domain.Entities;
using GetechnologiesMx.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GetechnologiesMx.Application.Services {
    public class SalesService : ISalesService {

        private readonly IInvoiceRepository _repository;
        public SalesService(IInvoiceRepository repository) {
            _repository = repository;
        }

        public async Task<Invoice[]> FindInvoicesByPerson(string identification) {

            var invoices = await _repository.Invoices.Where(i => i.Identification == identification)
                                               .ToArrayAsync();
            return invoices;
        }

        public async Task<Invoice> StoreInvoice(Invoice invoice)
        {
            invoice = await _repository.AddAsync(invoice);
            return invoice;
        }
    }
}
