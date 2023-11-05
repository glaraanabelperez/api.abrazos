using Abrazos.Services.Dto;
using AutoMapper;
using Models;
using Utils;

namespace Services.Mapper
{
    public class AutomapperToDto : Profile
    {
        public AutomapperToDto()
        {
            //-- Users -----------

            CreateMap<User, UserDto>().ForMember(obj => obj.UserId, objDto => objDto.MapFrom(o => o.UserId));
            CreateMap<DataCollection<User>, DataCollection<UserDto>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));

            //CreateMap<DataCollection<Payment.Domain.Payment>, DataCollection<PaymentDto>>().ForMember(pay => pay.Items, paydto => paydto.MapFrom(p => p.Items));
            //CreateMap<Payment.Domain.Payment, PaymentDto>().ForMember(pay => pay.PaymentId, paydto => paydto.MapFrom(p => p.PaymentId));


            //-- ProfileDAncer -----------
            CreateMap<ProfileDancerDto, Models.ProfileDancer>().ReverseMap();
            CreateMap<DataCollection<ProfileDancerDto>, DataCollection<Models.ProfileDancer>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));

            //-- TypeEvenet_User -----------
            CreateMap<TypeEvent_UserDto, Models.TypeEvent_User>().ReverseMap();
            CreateMap<DataCollection<TypeEvent_UserDto>, DataCollection<Models.TypeEvent_User>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));

            //-- TypeEvenet -----------
            CreateMap<TypeEventDto, Models.TypeEvent>().ReverseMap();
            CreateMap<DataCollection<TypeEventDto>, DataCollection<Models.TypeEvent>>().ForMember(dest => dest.Items, sour => sour.MapFrom(s => s.Items));

        }

    }

}