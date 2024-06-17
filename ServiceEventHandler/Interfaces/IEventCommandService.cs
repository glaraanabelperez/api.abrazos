using ServiceEventHandler.Command.CreateCommand;
using ServiceEventHandler.Command.UpdateCommand;
using Utils;

namespace Abrazos.ServicesEvenetHandler.Intefaces
{
    public interface IEventCommandService
    {
        public Task<ResultApp> AddRange(EventCreateCommand entity);
        public Task<ResultApp> Update(EventUpdateCommand entity);
        //public Task<ResultApp> UpdateCupo(int eventiId, int cupo);

    }
}

