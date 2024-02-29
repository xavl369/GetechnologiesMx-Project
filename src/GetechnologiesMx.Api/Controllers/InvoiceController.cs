using GetechnologiesMx.Application.Features.Directory.Commands;
using GetechnologiesMx.Application.Features.Directory.Queries;
using GetechnologiesMx.Application.Features.Sales.Commands;
using GetechnologiesMx.Application.Features.Sales.Queries;
using GetechnologiesMx.Application.Models;
using GetechnologiesMx.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace GetechnologiesMx.Api.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase {

        private readonly ISender _sender;

        public InvoicesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{identification}")]
        public async Task<InvoiceModel[]> Get(string identification)
        {
            var query = new FindInvoicesByPersonQuery { Identification = identification };
            var result = await _sender.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<Guid> Post([FromBody] StoreInvoiceCommand query)
        {
            var result = await _sender.Send(query);
            return result;
        }


    }
}
