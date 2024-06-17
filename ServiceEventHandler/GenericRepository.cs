

using Abrazos.Persistence.Database;
using Abrazos.Services.Dto;
using Abrazos.ServicesEvenetHandler.Intefaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Models;
using ServiceEventHandler.Command;
using Utils;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Abrazos.ServiceEventHandler
{
    public class GenericRepository : IGenericRepository
    {
        private readonly ILogger<GenericRepository> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GenericRepository(ApplicationDbContext dbContext, ILogger<GenericRepository> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<T> Add<T>(T entity) where T : class
        {
            using (IDbContextTransaction transac = await _dbContext.Database.BeginTransactionAsync())
            {

                    var dbSet = _dbContext.Set<T>();
                    var res_ = dbSet.Add(entity).Entity;
                    await _dbContext.SaveChangesAsync();                   
                    return res_;

            }
        }

        public async Task<T> Delete<T>(T entity) where T : class
        {
            using (IDbContextTransaction transac = await _dbContext.Database.BeginTransactionAsync())
            {
                var dbSet = _dbContext.Set<T>();
                var entyResult = dbSet.Remove(entity);
                return entity;

            }
        }

        public async Task<T1> Update<T1>(T1 entity) where T1 : class
        {
            using (IDbContextTransaction transac = await _dbContext.Database.BeginTransactionAsync())
            {

                var dbSet = _dbContext.Set<T1>();
                var entyResult = dbSet.Attach(entity).Entity;
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
                await transac.CommitAsync();
                return entyResult;

            }
        }


    }
}

