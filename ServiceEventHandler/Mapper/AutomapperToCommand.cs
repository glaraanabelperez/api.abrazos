using Abrazos.Services.Dto;
using AutoMapper;
using ServiceEventHandler.Command;
using ServiceEventHandler.Command.CreateCommand;
using Utils;

namespace Abrazos.ServicesEvenetHandler.Mapper
{
    public class AutomapperToCommand : Profile
    {
        public AutomapperToCommand()
        {
            //-- Users  -----------

            //CreateMap<UserCreateCommand, Models.User>().ReverseMap();
            //CreateMap<DataCollection<UserCreateCommand>, DataCollection<Models.User>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));
            //CreateMap<UserUpdateCommand, Models.User>();

            //-- Profile  -----------
            CreateMap<ProfileDancerCreateCommand, Models.ProfileDancer>().ReverseMap();

        }

    }

}