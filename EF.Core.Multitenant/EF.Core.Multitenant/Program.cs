using EF.Core.Multitenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Multitenant.API.Interceptors;
using Multitenant.API.Midleware;
using Multitenant.API.ModelFactory;
using Multitenant.Infraestructure.Data;
using Multitenant.Infraestructure.Database.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Estratégia 1
//builder.Services.AddDbContext<ApplicationContext>(options => options
//                .UseNpgsql(@"Host=localhost:5432;Username=postgres;Password=123;Database=Multitenant")
//                .LogTo(Console.WriteLine)
//                .EnableSensitiveDataLogging()
//    );

//Estratégia 2
builder.Services.AddDbContext<ApplicationContext>((provider, options) =>
{
    options
    .UseNpgsql(@"Host=localhost:5432;Username=postgres;Password=123;Database=Multitenant")
    .LogTo(Console.WriteLine)
    //.ReplaceService<IModelCacheKeyFactory, StrategySchemaModelCacheKey>()
    .EnableSensitiveDataLogging();

    var interceptor = provider.GetRequiredService<StrategySchemaInterceptor>();

    options.AddInterceptors(interceptor);
}); 

builder.Services.InstallDependenceInjections();
var app = builder.Build();

app.RunMigrations();

app.UseMiddleware<TenantMidleware>();

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

