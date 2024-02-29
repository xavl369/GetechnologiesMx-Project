
using AutoMapper;
using GetechnologiesMx.Application.Models;
using GetechnologiesMx.Domain.Entities;

namespace GetechnologiesMx.Application.Features.Directory.Mappings {
    public class PersonToPersonModelMapping : Profile {

        public PersonToPersonModelMapping(){

            CreateMap<Person, PersonModel>(MemberList.Destination)
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.LastName))
                .ForMember(d => d.MaternalSurname, o => o.MapFrom(s => s.MaternalSurname))
                .ForMember(d => d.Identification, o => o.MapFrom(s => s.Identification))
                .ReverseMap();

        }
    }
}
