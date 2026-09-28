using DeskFlow.Config;
using DeskFlow.Repositories;
using DeskFlow.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(connection));

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<IChamadoRepository, ChamadoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
// builder.Services.AddScoped<ErroMiddleware>();

// WARN: Adicionar "servicos" dos IServices da aplicacao

var app = builder.Build();
app.MapControllers();
app.UseMiddleware<ErroMiddleware>();
// app.UseErroMiddleware();

// NOTE: Swagger UI eh localizado em localhost:5211/swagger/index.html...
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(o => {
        o.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}


app.Run();
