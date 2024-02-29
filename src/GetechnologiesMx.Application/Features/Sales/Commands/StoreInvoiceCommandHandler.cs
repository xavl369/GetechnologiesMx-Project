using GetechnologiesMx.Application.Contracts;
using MediatR;



namespace GetechnologiesMx.Application.Features.Sales.Commands {
    public class StoreInvoiceCommandHandler : IRequestHandler<StoreInvoiceCommand, Guid> {

        private readonly ISalesService _service;
        public StoreInvoiceCommandHandler(ISalesService service) {
            _service = service;
        }

        public async Task<Guid> Handle(StoreInvoiceCommand request, CancellationToken cancellationToken) {

            var invoice = await _service.StoreInvoice(request);
            return invoice.Id;

        }
    }
}
