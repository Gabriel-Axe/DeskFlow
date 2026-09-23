var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(o => {
        o.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

// string connection = builder.Configuration.GetConnectionString("Default Connection");

app.Run();
