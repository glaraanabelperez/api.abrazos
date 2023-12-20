using Abrazos.Services.Dto;
using Models;
using ServiceEventHandler.Command;
using ServiceEventHandler.Command.CreateCommand;
using System;
using Utils;

namespace Abrazos.ServicesEvenetHandler.Intefaces
{
    public interface IEventCommandHandler
    {
        public Task<ResultApp<Event>> Add(EventCreateCommand entity);

        public Task<ResultApp<Event>> Update(EventUpdateCommand entity);

    }
}

