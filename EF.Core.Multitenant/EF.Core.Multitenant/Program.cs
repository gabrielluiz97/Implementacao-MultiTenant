using EF.Core.Multitenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Multitenant.API.Extension;
using Multitenant.Infraestructure.Data; 
using Multitenant.Infraestructure.Database.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.InstallDependenceInjections();

builder.Services.AddScoped<ApplicationContext>((provider) =>
{
    var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

    var httpContext = provider.GetService<IHttpContextAccessor>()?.HttpContext;

    var tenantId = httpContext?.GetTenantId();

    var connectionString = builder.Configuration.GetConnectionString(tenantId) ?? builder.Configuration.GetConnectionString("tenantz");

    optionsBuilder
        .UseNpgsql(connectionString)
        .LogTo(Console.WriteLine)
        .EnableSensitiveDataLogging();

    return new ApplicationContext(optionsBuilder.Options);
});

var app = builder.Build();

//generate all application contexts
var applicationsContexts = builder.GenerateContexts();

//execute migrations on all databases
applicationsContexts.RunMigrationsOnDataBases();

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

