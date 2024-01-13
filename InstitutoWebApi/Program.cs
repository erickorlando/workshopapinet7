using InstitutoWebApi.Data;
using InstitutoWebApi.Models;
using InstitutoWebApi.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Estas son las clases en memoria
builder.Services.AddSingleton<AlumnoRepositorio>();
builder.Services.AddTransient<List<Alumno>>();

// Las clases de base de datos
builder.Services.AddTransient<AlumnoRepository>();
builder.Services.AddTransient<NotaRepository>();

builder.Services.AddDbContext<InstitutoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InstitutoDb"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//// Esto es un Minimal API
//app.MapGet("api/MinimalAlumnos", () => new List<Alumno>()
//{
//    new Alumno() { Id = 1, Nombres = "Juan Perez"},
//    new Alumno() {Id= 2, Nombres = "Maria Carrasco"}
//});

app.UseHttpsRedirection(); // Solo funciona en Windows

//app.UseAuthorization();

app.MapControllers();

app.Run();
