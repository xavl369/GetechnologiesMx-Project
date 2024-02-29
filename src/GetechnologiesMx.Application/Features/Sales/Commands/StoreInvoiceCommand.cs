
using GetechnologiesMx.Domain.Entities;
using MediatR;

namespace GetechnologiesMx.Application.Features.Sales.Commands {
    public class StoreInvoiceCommand : Invoice, IRequest<Guid> { }
}
