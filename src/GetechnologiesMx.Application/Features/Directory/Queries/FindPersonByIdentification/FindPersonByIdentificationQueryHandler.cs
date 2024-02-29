using AutoMapper;
using GetechnologiesMx.Application.Contracts;
using GetechnologiesMx.Application.Exceptions;
using GetechnologiesMx.Application.Models;
using GetechnologiesMx.Domain.Entities;
using MediatR;


namespace GetechnologiesMx.Application.Features.Directory.Queries {
    public class FindPersonByIdentificationQueryHandler : IRequestHandler<FindPersonByIdentificationQuery, PersonModel> {

        private readonly IMapper _mapper;
        private readonly IDirectoryService _service;
       
        public FindPersonByIdentificationQueryHandler(IDirectoryService service, IMapper mapper) {
            
            _service = service;
            _mapper = mapper; 
        }
        public async Task<PersonModel> Handle(FindPersonByIdentificationQuery request, CancellationToken cancellationToken)
        {
            var person = await _service.GetPersonByIdentificationAsync(request.Identification) 
                ?? throw new NotFoundException(nameof(Person), request.Identification);

            return _mapper.Map<PersonModel>(person);
        }
    }
}
