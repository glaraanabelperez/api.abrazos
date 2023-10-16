using Abrazos.ServiceEventHandler.Commands;
using ServiceEventHandler.Command;
using System;

namespace Abrazos.ServicesEvenetHandler.Intefaces
{
    public interface IGenericRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(int id) where T : class;

    }
}

