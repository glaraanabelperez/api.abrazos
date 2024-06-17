using ServiceEventHandler.Command;
using System;
using Utils;

namespace Abrazos.ServicesEvenetHandler.Intefaces
{
     public interface IGenericRepository
    {
        public Task<T> Add<T>(T entity) where T : class;
        public Task<T> Update<T>(T entity) where T : class;
        public Task<T> Delete<T>(T ientityd) where T : class;

    }
}

