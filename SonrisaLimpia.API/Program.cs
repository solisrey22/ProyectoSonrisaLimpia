using SonrisaLimpia.API.Middleware;
using SonrisaLimpia.Aplicacion;
using SonrisaLimpia.Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AgregarServiciosAplicacion();
builder.Services.AgregarServiciosPersistencia();

var app = builder.Build();
app.UseManejadorExcepciones();

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
