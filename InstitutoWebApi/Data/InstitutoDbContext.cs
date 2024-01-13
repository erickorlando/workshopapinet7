using InstitutoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InstitutoWebApi.Data;

public class InstitutoDbContext : DbContext
{
    public InstitutoDbContext(DbContextOptions<InstitutoDbContext> options)
        : base(options)
    {

    }

    public DbSet<Alumno> Alumnos { get; set; } = default!;
    public DbSet<Nota> Notas { get; set; } = default!;
    public DbSet<Curso> Cursos { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // La configuracion de aqui se llama Fluent API

        modelBuilder.Entity<Alumno>()
            .ToTable("Alumno");

        modelBuilder.Entity<Alumno>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Alumno>()
           .Property(p => p.Nombres)
           .HasColumnName("Nombre")
           .HasMaxLength(150)
           .IsRequired();

        modelBuilder.Entity<Alumno>()
            .Property(p => p.Correo)
            .HasMaxLength(200);

        // Data Seeding para Cursos
        modelBuilder.Entity<Curso>()
            .ToTable("Curso");

        modelBuilder.Entity<Curso>()
            .HasData(new List<Curso>()
            {
                new() { Id= 1, Nombre = "Matematicas", Categoria = "Ciencias" },
                new() { Id= 2, Nombre = "Lenguaje y Comunicacion", Categoria = "Letras" },
                new() { Id= 3, Nombre = "Química", Categoria = "Ciencias" },
            });
    }
}