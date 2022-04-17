using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;
using SAPP.Test.Contracts.Utilities.Logger;
using SAPP.Test.Domain.Repositories;
using SAPP.Test.Persistance.Repositories;
using SAPP.Test.Presentation.Controllers;
using SAPP.Test.Services;
using SAPP.Test.Services.Abstractions;
using SAPP.Test.Services.Utilities.Logger;
using SAPP.Test.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddApplicationPart(typeof(TestParentController).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServiceManager,ServiceManager>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));

builder.Services.AddDbContext<RepositoryDbContext>(dbBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");

    dbBuilder.UseSqlServer(connectionString);

});
var mapConfig = new MapperConfiguration(mc =>
  mc.AddProfile(new MapperProfile())
);

IMapper mapper=mapConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddSingleton<ILoggerManager,LoggerManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
