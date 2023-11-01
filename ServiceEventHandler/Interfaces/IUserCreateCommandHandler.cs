using Abrazos.ServiceEventHandler.Commands;
using ServiceEventHandler.Command;
using System;

namespace Abrazos.ServicesEvenetHandler.Intefaces
{
    public interface IUserCreateCommandHandler
    {
        public Task<ResultApp> AddUser(UserCreateCommand entity);

    }
}

