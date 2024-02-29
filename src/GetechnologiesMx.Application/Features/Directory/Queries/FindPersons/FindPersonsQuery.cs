using GetechnologiesMx.Application.Models;
using MediatR;

namespace GetechnologiesMx.Application.Features.Directory.Queries {
    public class FindPersonsQuery : IRequest<PersonModel[]> {}
}
