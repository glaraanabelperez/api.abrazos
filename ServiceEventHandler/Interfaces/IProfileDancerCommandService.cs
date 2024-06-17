using Abrazos.Services.Dto;
using Models;
using ServiceEventHandler.Command;
using ServiceEventHandler.Command.CreateCommand;
using ServicesQueries.Dto;
using System;
using System.Threading.Tasks;
using Utils;

namespace Abrazos.ServicesEvenetHandler.Intefaces
{
    public interface IProfileDancerCommandService
    {
        public Task<ResultApp> Add(ProfileDancerCreateCommand entity);

        public Task<ResultApp> Update(ProfileDancerUpdateCommand entity);
        public Task<ResultApp> DeleteAsync(int profileDancerId);


    }
}

