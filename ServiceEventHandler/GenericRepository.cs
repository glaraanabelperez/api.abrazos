

using Abrazos.Persistence.Database;
using Abrazos.ServiceEventHandler.Commands;
using Abrazos.ServicesEvenetHandler.Intefaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Abrazos.ServiceEventHandler
{
    public class GenericRepository : IGenericRepository
    {
        //private readonly ILogger _logger;
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            //_logger = logger;
        }

        public async Task<T> Add<T>(T entity) where T : class
        {
           
            using (IDbContextTransaction transac = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var dbSet = _dbContext.Set<T>();
                    var result= dbSet.Add(entity);
                    _dbContext.SaveChanges();
                    await transac.CommitAsync();
                    return null;
                }
                catch (System.Exception ex)
                {
                    await transac.RollbackAsync();

                    string value = ((ex.InnerException != null) ? ex.InnerException!.Message : ex.Message);
                    //_logger.LogWarning(value);
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

