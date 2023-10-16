

using Abrazos.Persistence.Database;
using Abrazos.ServiceEventHandler.Commands;
using Abrazos.ServicesEvenetHandler.Intefaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using ServiceEventHandler.Command;

namespace Abrazos.ServiceEventHandler
{
    public class UserEventHandler: IUserEventHandler
    {
        //private readonly ILogger _logger;
        //private readonly ApplicationDbContext _dbContext;

        public UserEventHandler(ApplicationDbContext dbContext, ILogger _logger)
        {
            //_dbContext = dbContext;
        }

        //public async void Add<T>(T entity) where T : class
        //{
           
        //    //using (IDbContextTransaction transac = await _dbContext.Database.BeginTransactionAsync())
        //    //{
        //    //    try
        //    //    {
        //    //        var dbSet = _dbContext.Set<T>();
        //    //        dbSet.Add(entity);
        //    //        _dbContext.SaveChanges();
        //    //        await transac.CommitAsync();
        //    //    }
        //    //    catch (System.Exception ex)
        //    //    {
        //    //        await transac.RollbackAsync();

        //    //        string value = ((ex.InnerException != null) ? ex.InnerException!.Message : ex.Message);
        //    //        _logger.LogWarning(value);
        //    //    }
        //    //}

        //}

        //public void Delete<T>(int id) where T : class
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update<T>(T entity) where T : class
        //{
        //    throw new NotImplementedException();
        //}


    }
}

