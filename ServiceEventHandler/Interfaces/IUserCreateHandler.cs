using Abrazos.ServiceEventHandler.Commands;
using ServiceEventHandler.Command;
using System;

namespace Abrazos.ServicesEvenetHandler.Intefaces
{
    public interface IUserCreateHandler
    {
        public Task<UserCreateCommand> AddUser(UserCreateCommand entity);

    }
}

