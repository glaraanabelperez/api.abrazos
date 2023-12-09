using Abrazos.Services.Dto;
using Models;
using ServiceEventHandler.Command;
using ServiceEventHandler.Command.CreateCommand;
using System;
using Utils;

namespace Abrazos.ServicesEvenetHandler.Intefaces
{
    public interface IProfileDancerCommandHandler
    {
        public Task<ResultApp> Add(ProfileDancerCreateCommand entity);

        public Task<ResultApp> Update(ProfileDancerUpdateCommand entity);

    }
}

