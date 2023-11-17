using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Abrazos.Persistence.Database;
using Abrazos.ServicesEvenetHandler.Intefaces;
using Abrazos.ServiceEventHandler;
using Abrazos.Services.Interfaces;
using Abrazos.Services;
using Serilog;
using ServicesQueries.Auth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(builder.Configuration);

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(
       builder.Configuration["ConnectionStrings:DefaultConnection"]
        )
    );

builder.Services.AddHealthChecks();
//.AddDbContextCheck<ApplicationDbContext>();


// Add services to the container.
builder.Services.AddTransient<AbrazosDbContext, ApplicationDbContext>();
builder.Services.AddTransient<IGenericRepository, GenericRepository>();
builder.Services.AddTransient<IUserCommandHandler, UserCommandHandler>();
builder.Services.AddTransient<IUserQueryService, UserQueryService>();




//Config Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Config Logger
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers().RequireAuthorization(); // Requiere autorización para todos los controladores
//});

app.Run();

