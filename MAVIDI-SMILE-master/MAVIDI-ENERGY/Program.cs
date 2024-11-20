using MAVIDI_ENERGY.Application.Services;
using MAVIDI_ENERGY.Application.Interfaces;
using MAVIDI_ENERGY.Domain.Interfaces;
using MAVIDI_ENERGY.Infrastructure.Repositories;
using MAVIDI_ENERGY.Infrastructure.Data;
using MAVIDI_ENERGY.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração da string de conexão
var connectionString = builder.Configuration.GetConnectionString("OracleConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string for Oracle Database is not configured.");
}

// Configuração do DbContext para usar Oracle
builder.Services.AddDbContext<AppData>(options =>
{
    options.UseOracle(connectionString);
});

// Registro de repositórios
builder.Services.AddScoped<IEnergyUsageRepository, EnergyUsageRepository>();
builder.Services.AddScoped<ISolarProviderRepository, SolarProviderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Registro de serviços
builder.Services.AddScoped<IEnergyUsageService, EnergyService>();
builder.Services.AddScoped<ISolarProviderService, ProviderService>();
builder.Services.AddScoped<IUserApplicationService, UserService>();

// Adiciona controladores e configurações do Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MavidiEnergy API",
        Version = "v1",
        Description = "API para gerenciamento de energia sustentável",
    });

    c.EnableAnnotations(); // Habilitar anotações para documentação com Swagger
});

// Configuração do pipeline da aplicação
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MavidiEnergy API V1");
    });
}
else
{
    app.UseHttpsRedirection();
    app.UseHsts();
}

// Configuração de roteamento
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    // Rota padrão
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // Rota personalizada para usuários
    endpoints.MapControllerRoute(
        name: "users",
        pattern: "Users/{action=Index}/{id?}",
        defaults: new { controller = "User" });
});

// Executar a aplicação
app.Run();
