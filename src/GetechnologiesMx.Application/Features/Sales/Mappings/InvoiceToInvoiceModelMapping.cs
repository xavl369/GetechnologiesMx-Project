
using AutoMapper;
using GetechnologiesMx.Application.Models;
using GetechnologiesMx.Domain.Entities;

namespace GetechnologiesMx.Application.Features.Directory.Mappings {
    public class InvoiceToInvoiceModelMapping : Profile {
        public InvoiceToInvoiceModelMapping(){
            CreateMap<Invoice, InvoiceModel>(MemberList.Destination)
                .ConstructUsing((src, context) => new InvoiceModel {
                    Date = src.CreatedDate,
                    Amount = src.Amount
                });
        }
    }
}
