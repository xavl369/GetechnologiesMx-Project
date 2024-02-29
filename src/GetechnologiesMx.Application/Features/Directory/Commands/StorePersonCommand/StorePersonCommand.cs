using GetechnologiesMx.Domain.Entities;
using MediatR;

namespace GetechnologiesMx.Application.Features.Directory.Commands {
    public class StorePersonCommand : Person, IRequest<Guid> { }
    
    
}
