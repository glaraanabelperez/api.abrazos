using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// dbContext
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(
       builder.Configuration["ConnectionStrings:DefaultConnection"]
        )
    );

builder.Services.AddHealthChecks();
//.AddDbContextCheck<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddTransient<AbrazosDbContext, ApplicationDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



//////////////////////////////////
///
//builder.Services.AddTransient<CepasDbContext, ApplicationDbContext>();
//builder.Services.AddTransient<IConsumerQueryService, ConsumerQueryService>();
//builder.Services.AddTransient<IAddressQueryService, AddressQueryService>();
//builder.Services.AddTransient<IDocumentTypeQueryService, DocumentTypeQueryService>();



// Add services Authentification

//var secretKey = Encoding.ASCII.GetBytes(
//        builder.Configuration["SecretsKeys:SecretKeyLog"]
//    );
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
//{
//    x.RequireHttpsMetadata = false;
//    x.SaveToken = true;
//    x.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
//        ValidateIssuer = false,
//        ValidateAudience = false
//    };
//});




// AutoMapper
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
