

using Abrazos.Persistence.Database;
using Abrazos.ServiceEventHandler.Commands;
using Abrazos.ServicesEvenetHandler.Intefaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Models;
using ServiceEventHandler.Command;

namespace Abrazos.ServiceEventHandler
{
    public class UserCreateHandler: IUserCreateHandler
    {
        //private readonly ILogger _logger;
        private readonly ApplicationDbContext _dbContext;
        public IGenericRepository command;

        public UserCreateHandler(ApplicationDbContext dbContext, IGenericRepository command)
        {
            _dbContext = dbContext;
            this.command = command;
        }

        public async Task<UserCreateCommand> AddUser(UserCreateCommand entity)
        {

            using (IDbContextTransaction transac = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = new User();
                    user.Name= entity.UserName;
                    user.UserState = 1;
                    user.Pass = "1234";
                    var result = await this.command.Add<User>(user);
                    //var dbSet = _dbContext.Set<T>();
                    //dbSet.Add(entity);
                    //_dbContext.SaveChanges();
                    //await transac.CommitAsync();
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

        public void Test()
        {
            throw new NotImplementedException();
        }

  
    }
}

