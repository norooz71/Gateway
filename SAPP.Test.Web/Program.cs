using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog;
using NoaFounding.Infrastructure.ExternalServices;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using SAPP.Gateway.Contracts.Utilities.Logger;
using SAPP.Gateway.Contracts.Utilities.ServiceCall;
using SAPP.Gateway.Domain.Repositories;
using SAPP.Gateway.Persistance.Repositories;
using SAPP.Gateway.Presentation.Controllers;
using SAPP.Gateway.Services;
using SAPP.Gateway.Services.Abstractions;
using SAPP.Gateway.Services.Abstractions.Redis;
using SAPP.Gateway.Services.Redis;
using SAPP.Gateway.Services.Utilities.Logger;
using SAPP.Gateway.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddApplicationPart(typeof(TestParentController).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServiceManager,ServiceManager>();
builder.Services.AddScoped<IServiceCall, ServiceCall>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Configuration.AddJsonFile("Routes.json");
builder.Services.AddOcelot();

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

builder.Services.AddSingleton<IRedisService,RedisService>();

builder.Services.AddStackExchangeRedisCache(Options =>
{
    Options.Configuration = builder.Configuration["RedisConfiguration:Host"];

    Options.InstanceName = "";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomExceptionMiddleware>();

app.UseMiddleware<RoutingDecideMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.UseOcelot();

app.Run();
