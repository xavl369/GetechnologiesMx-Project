
using Azure.Identity;
using GetechnologiesMx.Application.Contracts;
using GetechnologiesMx.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GetechnologiesMx.Application.Features.Directory.Commands {
    public class StorePersonCommandHandler : IRequestHandler<StorePersonCommand, Guid> {

        private readonly IDirectoryService _service;
        private readonly ILogger<StorePersonCommandHandler> _logger;

        public StorePersonCommandHandler(IDirectoryService service, ILogger<StorePersonCommandHandler> logger) {
            _service = service;
            _logger = logger;
        }

        public async Task<Guid> Handle(StorePersonCommand request, CancellationToken cancellationToken) {

            var person = await _service.GetPersonByIdentificationAsync(request.Identification);
            if (person != null) {
                var message = $"A person with the same identification {request.Identification} already exists.";
                throw new BadRequestException(message);
            }

            person = await _service.StorePerson(request);
            _logger.LogInformation($"New Person {person.Name} added");
            return person.Id;
        }
    }
}
