
using GetechnologiesMx.Application.Models;
using GetechnologiesMx.Domain.Common;
using MediatR;

namespace GetechnologiesMx.Application.Features.Directory.Queries {
    public class FindPersonByIdentificationQuery : Identifiable, IRequest<PersonModel> { }
}
