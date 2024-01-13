using System.Reflection.Metadata.Ecma335;
using InstitutoWebApi.Data;
using InstitutoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InstitutoWebApi.Repositorios;

public class NotaRepository : RepositoryBase<Nota>
{
    public NotaRepository(InstitutoDbContext dbContext) 
        : base(dbContext)
    {
    }

    public async Task<ICollection<Nota>> ListarNotas(int alumnoId)
    {
        var query = await DbContext.Set<Nota>()
            .Include(p => p.Curso) // Las tablas estan relacionadas
            .Where(x => x.AlumnoId == alumnoId)
            .ToListAsync();

        return query;
    }
    
    public async Task<NotasInfo?> ListarNotasMejorado(int alumnoId)
    {
        var query = await DbContext.Set<Nota>()
            .Where(x => x.AlumnoId == alumnoId)
            .Select(p => new NotasInfo
            {
                NombreAlumno = p.Alumno.Nombres,
                Calificaciones = p.Alumno.Notas.Select(x => new Calificaciones
                {
                    Calificacion = x.Calificacion,
                    NombreCurso = x.Curso.Nombre
                }).ToList()
            })
            .ToListAsync();
        
        return query.FirstOrDefault();
    }
}