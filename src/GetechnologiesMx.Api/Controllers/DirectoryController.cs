using GetechnologiesMx.Application.Features.Directory.Commands;
using GetechnologiesMx.Application.Features.Directory.Queries;
using GetechnologiesMx.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GetechnologiesMx.Api.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class DirectoryController : ControllerBase {

        private readonly ISender _sender;

        public DirectoryController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<PersonModel[]> Get([FromQuery] FindPersonsQuery query)
        {
            var result = await _sender.Send(query);
            return result;
        }

        [HttpGet("{identification}")]
        public async Task<PersonModel> Get(string identification)
        {
            var query = new FindPersonByIdentificationQuery { Identification = identification };
            var result = await _sender.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<Guid> Post([FromBody] StorePersonCommand query)
        {
            var result = await _sender.Send(query);
            return result;
        }

        [HttpDelete("{identification}")]
        public async Task Post(string identification)
        {
            var command = new DeletePersonByIdentificationCommand() { Identification = identification };
            await _sender.Send(command);
        }



    }
}
