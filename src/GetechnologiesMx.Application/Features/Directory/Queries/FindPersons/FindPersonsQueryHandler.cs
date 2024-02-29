using AutoMapper;
using GetechnologiesMx.Application.Contracts;
using GetechnologiesMx.Application.Models;
using MediatR;

namespace GetechnologiesMx.Application.Features.Directory.Queries {
    public class FindPersonsQueryHandler : IRequestHandler<FindPersonsQuery, PersonModel[]> {

        private readonly IMapper _mapper;
        private readonly IDirectoryService _service;

        public FindPersonsQueryHandler(IMapper mapper, IDirectoryService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<PersonModel[]> Handle(FindPersonsQuery request, CancellationToken ct) {

            var persons = await _service.FindPersonsAsync();
            return _mapper.Map<PersonModel[]>(persons);

        }

    }
}
