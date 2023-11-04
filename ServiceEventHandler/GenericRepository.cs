

using Abrazos.Persistence.Database;
using Abrazos.ServiceEventHandler.Commands;
using Abrazos.Services.Dto;
using Abrazos.ServicesEvenetHandler.Intefaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using ServiceEventHandler.Command;

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
                ResultApp res= new ResultApp();
                try
                {
                    var dbSet = _dbContext.Set<T>();
                    var res_ = dbSet.Add(entity);
                    _dbContext.SaveChanges();

                    res.objectResult = _mapper.Map<UserDto>(res_.Entity);
                    await transac.CommitAsync();

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

