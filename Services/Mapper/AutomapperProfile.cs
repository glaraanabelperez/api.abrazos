using Abrazos.Services.Dto;
using AutoMapper;


namespace Services.Mapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //-- Users -----------
            CreateMap<UserDto, Models.Users>().ReverseMap();
            CreateMap<DataCollection<UserDto>, DataCollection<Models.Users>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));


        }

    }

}