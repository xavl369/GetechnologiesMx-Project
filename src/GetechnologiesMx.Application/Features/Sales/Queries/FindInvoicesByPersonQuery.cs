using GetechnologiesMx.Application.Models;
using GetechnologiesMx.Domain.Common;
using MediatR;

namespace GetechnologiesMx.Application.Features.Sales.Queries {
    public class FindInvoicesByPersonQuery : Identifiable , IRequest<InvoiceModel[]>{ }
}
