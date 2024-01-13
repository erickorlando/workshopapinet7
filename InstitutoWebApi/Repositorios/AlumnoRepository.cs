using InstitutoWebApi.Data;
using InstitutoWebApi.Models;

namespace InstitutoWebApi.Repositorios;

public class AlumnoRepository : RepositoryBase<Alumno>
{
    public AlumnoRepository(InstitutoDbContext dbContext) 
        : base(dbContext)
    {
    }
}