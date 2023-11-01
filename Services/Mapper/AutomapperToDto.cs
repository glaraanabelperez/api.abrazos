using Abrazos.Services.Dto;
using AutoMapper;


namespace Services.Mapper
{
    public class AutomapperToDto : Profile
    {
        public AutomapperToDto()
        {
            //-- Users -----------

            CreateMap<UserDto, Models.User>().ReverseMap();
            CreateMap<DataCollection<UserDto>, DataCollection<Models.User>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));


        }

    }

}