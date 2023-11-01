using Abrazos.ServiceEventHandler.Commands;
using Abrazos.Services.Dto;
using AutoMapper;


namespace Abrazos.ServicesEvenetHandler.Mapper
{
    public class AutomapperToCommand : Profile
    {
        public AutomapperToCommand()
        {
            //-- Users -----------

            CreateMap<UserCreateCommand, Models.User>().ReverseMap();
            CreateMap<DataCollection<UserCreateCommand>, DataCollection<Models.User>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));


        }

    }

}