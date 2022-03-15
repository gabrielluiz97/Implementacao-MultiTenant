using EF.Core.Multitenant;
using Microsoft.EntityFrameworkCore;
using Multitenant.API.Midleware;
using Multitenant.Domain;
using Multitenant.Infraestructure.Data;
using Multitenant.Infraestructure.Database.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options => options
                .UseNpgsql(@"Host=localhost:5432;Username=postgres;Password=123;Database=Multitenant")
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging()
    );


Installer.Install(builder.Services);

var app = builder.Build();

SeedsInitilizer.Initialize(app);

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

