using ServiceEventHandler.Command;
using ServiceEventHandler.Command.CreateCommand;
using System;
using Utils;

namespace Abrazos.ServicesEvenetHandler.Intefaces
{
    public interface IUserCommandHandler
    {
        public Task<ResultApp> AddUser(UserCreateCommand entity);

        public Task<ResultApp> UpdateUser(UserUpdateCommand entity);

    }
}

