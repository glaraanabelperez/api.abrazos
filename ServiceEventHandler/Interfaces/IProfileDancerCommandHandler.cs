using Abrazos.Services.Dto;
using Models;
using ServiceEventHandler.Command;
using ServiceEventHandler.Command.CreateCommand;
using System;
using System.Threading.Tasks;
using Utils;

namespace Abrazos.ServicesEvenetHandler.Intefaces
{
    public interface IProfileDancerCommandHandler
    {
        public Task<ResultApp<UserDto>> Add(ProfileDancerCreateCommand entity);

        public Task<ResultApp<ProfileDancer>> Update(ProfileDancerUpdateCommand entity);

    }
}

