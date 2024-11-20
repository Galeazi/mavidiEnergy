using MAVIDI_SMILE.Application.Services;
using MAVIDI_SMILE.mavidiSmile.Domain.Interfaces;
using MAVIDI_SMILE.mavidiSmile.Infrastructure.Repositories;
using MAVIDI_SMILE.mavidiSmile.Application.Interfaces;
using MAVIDI_SMILE.mavidiSmile.Application.Services;
using MAVIDI_SMILE.mavidiSmile.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MAVIDI_SMILE.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Verifique se a string de conexão está correta.
var connectionString = builder.Configuration.GetConnectionString("OracleConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string for Oracle Database is not configured.");
}

// Configure o DbContext para usar Oracle.
builder.Services.AddDbContext<AppData>(options =>
{
    options.UseOracle(connectionString);
});

// Adiciona os repositórios e serviços

// Repositórios
builder.Services.AddScoped<IProgressoRepository, ProgressoRepository>();
builder.Services.AddScoped<IAmigosRepository, AmigosRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Serviços
builder.Services.AddScoped<IProgressoService, ProgressoService>();
builder.Services.AddScoped<IAmigosService, AmigosService>();

builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Fornecedor",
        Version = "v1",
        Description = "API para cadastro de fornecedores"
    });

    c.EnableAnnotations();
});

var app = builder.Build();

// Configuração do pipeline para desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHttpsRedirection();
    app.UseHsts();
}

// Adicione o roteamento antes de autorizações e mapeamento de controladores
app.UseRouting(); // Importante para resolver o erro

// Configuração do Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Fornecedor V1");
});

app.UseAuthorization();

// Configuração de rotas e endpoints
app.UseEndpoints(endpoints =>
{
    // Rota padrão
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // Rota personalizada para o controlador Amigos
    endpoints.MapControllerRoute(
        name: "amigos",
        pattern: "Amigos/{action=Index}/{id?}",
        defaults: new { controller = "Amigos" });
});

// Executar a aplicação
app.Run();
