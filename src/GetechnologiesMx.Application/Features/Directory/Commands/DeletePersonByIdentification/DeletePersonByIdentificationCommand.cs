using GetechnologiesMx.Domain.Common;
using MediatR;

namespace GetechnologiesMx.Application.Features.Directory.Commands {
    public class DeletePersonByIdentificationCommand : Identifiable, IRequest<Unit> { }
}
