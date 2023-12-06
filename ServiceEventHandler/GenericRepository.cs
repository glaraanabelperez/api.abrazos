

using Abrazos.Persistence.Database;
using Abrazos.Services.Dto;
using Abrazos.ServicesEvenetHandler.Intefaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using ServiceEventHandler.Command;
using Utils;

namespace Abrazos.ServiceEventHandler
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ILogger<GenericRepository<T>> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GenericRepository(ApplicationDbContext dbContext, ILogger<GenericRepository<T>> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<T> Add<T1>(T entity) where T1 : class
        {
            using (IDbContextTransaction transac = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var dbSet = _dbContext.Set<T>();
                    var res_ = dbSet.Add(entity).Entity;
                    await _dbContext.SaveChangesAsync();
                    await transac.CommitAsync();

                    //_logger.LogWarning(res_.Metadata.ToString());
                   
                    return res_;
                }
                catch (System.Exception ex)
                {
                    await transac.RollbackAsync();
                    string value = ((ex.InnerException != null) ? ex.InnerException!.Message : ex.Message);
                    _logger.LogWarning(value);
                    throw;
                }

            }
        }

        public Task<ResultApp> Delete<T1>(int id) where T1 : class
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update<T1>(T entity) where T1 : class
        {
            using (IDbContextTransaction transac = await _dbContext.Database.BeginTransactionAsync())
            {
                ResultApp res = new ResultApp();
                try
                {

                    var dbSet = _dbContext.Set<T>();
                    var entyResult = dbSet.Attach(entity).Entity;
                    _dbContext.Entry(entity).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    await transac.CommitAsync();

                    //_logger.LogWarning(res_.Metadata.ToString());
                    return entyResult;
                }
                catch (System.Exception ex)
                {
                    await transac.RollbackAsync();
                    string value = ((ex.InnerException != null) ? ex.InnerException!.Message : ex.Message);
                    _logger.LogWarning(value);
                    throw;
                }

            }
        }

       
    }
}

