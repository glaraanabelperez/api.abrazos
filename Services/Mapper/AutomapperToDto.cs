using AutoMapper;
using Models;
using ServicesQueries.Dto;
using Utils;

namespace Services.Mapper
{
    public class AutomapperToDto : Profile
    {
        public AutomapperToDto()
        {
            //-- Users -----------

            CreateMap<User, UserDto>();
            CreateMap<DataCollection<User>, DataCollection<UserDto>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));

            CreateMap<EventState, EventStateDto>();
            CreateMap<DataCollection<EventState>, DataCollection<EventStateDto>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));

            CreateMap<Event, EventDto>();
            CreateMap<DataCollection<Event>, DataCollection<EventDto>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));

            CreateMap<Address, AddressDto>();
            CreateMap<DataCollection<Address>, DataCollection<AddressDto>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));

            CreateMap<Cycle, CycleDto>();
            CreateMap<DataCollection<Cycle>, DataCollection<CycleDto>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));

            CreateMap<City, CityDto>();
            CreateMap<DataCollection<City>, DataCollection<CityDto>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));
           
            CreateMap<Country, CountryDto>();
            CreateMap<DataCollection<Country>, DataCollection<CountryDto>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));


            //-- ProfileDAncer -----------
            CreateMap<ProfileDancer, ProfileDancerDto>();
            CreateMap<DataCollection<ProfileDancer>, DataCollection<ProfileDancerDto>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));

            //-- DanceLevel -----------
            CreateMap<DanceLevel, DanceLevelDto>();
            CreateMap<DataCollection<DanceLevel>, DataCollection<DanceLevelDto>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));

            //-- DanceRol -----------
            CreateMap<DanceRol, DanceRolDto>();
            CreateMap<DataCollection<DanceRol>, DataCollection<DanceRolDto>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));


            //-- TypeEvenet_User -----------
            CreateMap<TypeEventUser, TypeEventUserDto>();
            CreateMap<DataCollection<TypeEventUser>, DataCollection<TypeEventUserDto>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));

            //-- TypeEvenet -----------
            CreateMap<TypeEvent, TypeEventDto>();
            CreateMap<DataCollection<TypeEvent>, DataCollection<TypeEventDto>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));

        }

    }

}