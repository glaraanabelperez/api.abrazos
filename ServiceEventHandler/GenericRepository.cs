

using Abrazos.Persistence.Database;
using Abrazos.ServiceEventHandler.Commands;
using Abrazos.ServicesEvenetHandler.Intefaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using ServiceEventHandler.Command;

namespace Abrazos.ServiceEventHandler
{
    public class GenericRepository : IGenericRepository
    {
        private readonly ILogger<GenericRepository> _logger;
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext, ILogger<GenericRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            _logger = logger;
        }

        public async Task<ResultApp> Add<T>(T entity) where T : class
        {

            using (IDbContextTransaction transac = await _dbContext.Database.BeginTransactionAsync())
            {
                ResultApp res= new ResultApp();
                try
                {
                    var dbSet = _dbContext.Set<T>();
                    var res_ = dbSet.Add(entity);
                    res.objectResult = res_.Entity;
                    _dbContext.SaveChanges();
                    await transac.CommitAsync();

                    res.Succeeded = true;
                    res.message = "Successful registration";
                    _logger.LogWarning("OK");
                    return res;
                }
                catch (System.Exception ex)
                {
                    await transac.RollbackAsync();
                    string value = ((ex.InnerException != null) ? ex.InnerException!.Message : ex.Message);
                    _logger.LogWarning(value);
                }
                return null;
            }

        }

        public void Delete<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

    }
}

