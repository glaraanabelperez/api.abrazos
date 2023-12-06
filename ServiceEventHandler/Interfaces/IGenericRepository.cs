using ServiceEventHandler.Command;
using System;
using Utils;

namespace Abrazos.ServicesEvenetHandler.Intefaces
{
     public interface IGenericRepository<T>where T : class
    {
        public Task<T1> Add<T1>(T1 entity) where T1 : class;
        public Task<T1> Update<T1>(T1 entity) where T1 : class;
        public Task<int> Delete<T1>(int id) where T1 : class;

    }
}

