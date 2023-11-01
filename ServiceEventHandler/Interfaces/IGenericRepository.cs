using Abrazos.ServiceEventHandler.Commands;
using ServiceEventHandler.Command;
using System;

namespace Abrazos.ServicesEvenetHandler.Intefaces
{
    public interface IGenericRepository
    {
        public Task<ResultApp> Add<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public void Delete<T>(int id) where T : class;

    }
}

