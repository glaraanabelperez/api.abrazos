using Microsoft.EntityFrameworkCore;
using Abrazos.Persistence.Database;
using Abrazos.ServicesEvenetHandler.Intefaces;
using Abrazos.ServiceEventHandler;
using Abrazos.Services.Interfaces;
using Abrazos.Services;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Utils.Exception;

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

//Config Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Add Filters, tu handler Exceeptions with microsoft'libreries
builder.Services.AddMvc(option =>
{
    option.Filters.Add<ExceptionHandlerFilter>();
});

// Add services to the container.
builder.Services.AddTransient<AbrazosDbContext, ApplicationDbContext>();

builder.Services.AddTransient<IGenericRepository, GenericRepository>();   //Solo para persistencia.

//Command Service
builder.Services.AddTransient<IProfileDancerCommandService, ProfileDancerCommandService>(); 
builder.Services.AddTransient<IUserCommandService, UserCommandService>();
builder.Services.AddTransient<IEventCommandService, EventCommandService>();
builder.Services.AddTransient<IProfileDancerQueryService, ProfileDancerQueryService>(); 
//Query services

builder.Services.AddTransient<IUserQueryService, UserQueryService>();
builder.Services.AddTransient<IEventQueryService, EventQueryService>();

//Cors
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
 builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("*")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                          });
    });


//Config Logger
var logDB = builder.Configuration["ConnectionStrings:DefaultConnection"];
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



builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//builder.Services.AddAuthentication("BasicAuthentication")
//    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);


//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers().RequireAuthorization(); // Requiere autorización para todos los controladores
//});

app.Run();

