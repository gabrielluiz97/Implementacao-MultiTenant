using Microsoft.EntityFrameworkCore;
using Multitenant.API.Interceptors;
using Multitenant.API.Midleware;
using Multitenant.Infraestructure.Data;
using Multitenant.Infraestructure.Database.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Estratégia 2
builder.Services.AddScoped<StrategySchemaInterceptor>();

builder.Services.AddDbContext<ApplicationContext>((provider, options) =>
{
    var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

    options
    .UseNpgsql(builder.Configuration.GetConnectionString("TenantZ"), b => b.MigrationsAssembly("Multitenant.Infraestructure"))
    .LogTo(Console.WriteLine)
    .EnableSensitiveDataLogging();

    var interceptor = provider.GetRequiredService<StrategySchemaInterceptor>();

    options.AddInterceptors(interceptor);
});


builder.Services.InstallServices();
var app = builder.Build();


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

