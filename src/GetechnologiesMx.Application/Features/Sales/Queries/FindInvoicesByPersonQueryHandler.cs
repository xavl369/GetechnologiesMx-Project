
using AutoMapper;
using GetechnologiesMx.Application.Contracts;
using GetechnologiesMx.Application.Models;
using MediatR;

namespace GetechnologiesMx.Application.Features.Sales.Queries {
    public class FindInvoicesByPersonQueryHandler : IRequestHandler<FindInvoicesByPersonQuery, InvoiceModel[]> {

        private readonly IMapper _mapper;
        private readonly ISalesService _service;
        public FindInvoicesByPersonQueryHandler(ISalesService service, IMapper mapper) {
            _service = service;
            _mapper = mapper;
        }

        public async Task<InvoiceModel[]> Handle(FindInvoicesByPersonQuery request, CancellationToken cancellationToken) {

            var invoices = await _service.FindInvoicesByPerson(request.Identification);
            return _mapper.Map<InvoiceModel[]>(invoices);
        }
    }
}
