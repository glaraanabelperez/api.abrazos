using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Abrazos.Persistence.Database;
using Abrazos.ServicesEvenetHandler.Intefaces;
using Abrazos.ServiceEventHandler;
using Abrazos.Services.Interfaces;
using Abrazos.Services;
using Serilog;
using ServicesQueries.Auth;
using Serilog.Sinks.MSSqlServer;
using Serilog.Formatting.Compact;

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

//Cors
 string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


 builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("*");
                          });
    });


//Config Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Config Logger


var logDB = "workstation id=abrazoApp.mssql.somee.com;packet size=4096;user id=glaraanabelperez_SQLLogin_1;pwd=cngl7g9dti;data source=abrazoApp.mssql.somee.com;persist security info=False;initial catalog=abrazoApp";
var sinkOpts = new MSSqlServerSinkOptions();
sinkOpts.TableName = "Log";
var columnOpts = new ColumnOptions();
columnOpts.Store.Remove(StandardColumn.Properties);
columnOpts.Store.Add(StandardColumn.LogEvent);
columnOpts.LogEvent.DataLength = 2048;
columnOpts.TimeStamp.NonClusteredIndex = true;

Log.Logger = new LoggerConfiguration()
    //.WriteTo.File(new CompactJsonFormatter(), "Log.json", rollingInterval: RollingInterval.Day)
    .WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
    .WriteTo.MSSqlServer(
            connectionString: logDB,
            sinkOptions: sinkOpts,
            columnOptions: columnOpts
     )
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

try
{
    Log.Information("Application starting up.");

}
catch (Exception ex)
{
    Log.Fatal(ex, "The application failed to start up correctly.");
}
finally
{
    Log.CloseAndFlush();
}



//Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();



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

app.UseCors(MyAllowSpecificOrigins);


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers().RequireAuthorization(); // Requiere autorización para todos los controladores
//});

app.Run();

