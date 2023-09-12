using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Models;
using Persistence.Database;

namespace api.abrazos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public AbrazosDbContext _db;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AbrazosDbContext dbcontext)
        {
            _logger = logger;
            _db = dbcontext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<User> Get()
        {
            using(IDbContextTransaction trans =_db.Database.BeginTransaction())
            {
                var user = new User();
                user.Name = "Lara";
                await _db.AddAsync(user);
                await _db.SaveChangesAsync();
                await trans.CommitAsync();
            return user;
            }
            
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}