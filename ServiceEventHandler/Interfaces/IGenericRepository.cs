﻿using ServiceEventHandler.Command;
using System;
using Utils;

namespace Abrazos.ServicesEvenetHandler.Intefaces
{
     public interface IGenericRepository<T1>where T1 : class
    {
        public Task<T> Add<T>(T entity) where T : class;
        public Task<T> Update<T>(T entity) where T : class;
        public Task<int> Delete<T>(int id) where T : class;

    }
}

