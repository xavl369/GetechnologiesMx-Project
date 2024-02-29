
using GetechnologiesMx.Application.Contracts;
using GetechnologiesMx.Application.Exceptions;
using GetechnologiesMx.Domain.Entities;
using MediatR;

namespace GetechnologiesMx.Application.Features.Directory.Commands {
    public class DeletePersonByIdentificationCommandHandler : IRequestHandler<DeletePersonByIdentificationCommand, Unit> {

        private readonly IDirectoryService _service;
        public DeletePersonByIdentificationCommandHandler(IDirectoryService service) {
            _service = service;
        }

        public async Task<Unit> Handle(DeletePersonByIdentificationCommand request, CancellationToken cancellationToken)
        {
            await _service.DeletePersonByIdentificationAsync(request.Identification);
            return Unit.Value;
        }
    }
}
