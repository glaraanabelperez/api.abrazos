

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

        public async Task<ResultApp> Add<T>(T entity) where T : class
        {

            using (IDbContextTransaction transac = await _dbContext.Database.BeginTransactionAsync())
            {
                ResultApp res = new ResultApp();
                try
                {
                    var dbSet = _dbContext.Set<T>();
                    var res_ = dbSet.Add(entity);
                    _dbContext.SaveChanges();

                    res.objectResult = _mapper.Map<UserDto>(res_.Entity);
                    await transac.CommitAsync();

                    //_logger.LogWarning(res_.Metadata.ToString());
                    res.Succeeded = true;
                    res.message = "Successful registration";
                    return res;
                }
                catch (System.Exception ex)
                {
                    await transac.RollbackAsync();
                    string value = ((ex.InnerException != null) ? ex.InnerException!.Message : ex.Message);
                    _logger.LogWarning(value);
                    res.Succeeded = false;
                    res.message = "Error al Registrar el Usuario";
                    return res;
                }

            }

        }

        public async Task<ResultApp> Update<T>(T entity) where T : class
        {
            using (IDbContextTransaction transac = await _dbContext.Database.BeginTransactionAsync())
            {
                ResultApp res = new ResultApp();
                try
                {                    

                    var dbSet = _dbContext.Set<T>();
                    var entyResult = dbSet.Attach(entity);
                    _dbContext.Entry(entity).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    res.objectResult = _mapper.Map<UserDto>(entyResult.Entity);
                    await transac.CommitAsync();

                    //_logger.LogWarning(res_.Metadata.ToString());
                    res.Succeeded = true;
                    res.message = "Successful Edition";
                    return res;
                }
                catch (System.Exception ex)
                {
                    await transac.RollbackAsync();
                    string value = ((ex.InnerException != null) ? ex.InnerException!.Message : ex.Message);
                    _logger.LogWarning(value);
                    res.Succeeded = false;
                    res.message = "Error al Registrar el Usuario";
                    return res;
                }

            }
        }

        public Task<ResultApp> Delete<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }
    }
}

