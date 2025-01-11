using AutoMapper;
using Test.Millon.API.Models.Dtos;
using Test.Millon.Core.Entities;

namespace Test.Millon.API.Models.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PropertyBuildingDTO, Owner>()
                .ForMember(from => from.Address, opt => opt.MapFrom(src => src.AddressOwner))
                .ForMember(from => from.Name, opt => opt.MapFrom(src => src.NameOwner));

            CreateMap<PropertyBuildingDTO, Property>();

            CreateMap<PropertyImageDTO, PropertyImage>()
                .ForMember(from => from.Enabled, opt => opt.MapFrom(src => true));
        }
    }
}
