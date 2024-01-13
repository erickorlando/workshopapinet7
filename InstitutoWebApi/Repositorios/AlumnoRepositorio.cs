using InstitutoWebApi.Models;

namespace InstitutoWebApi.Repositorios;

public class AlumnoRepositorio : RepositorioBase<Alumno>
{
    public AlumnoRepositorio(List<Alumno> coleccion) 
        : base(coleccion)
    {
        Agregar(new Alumno() { Nombres = "Erick Orlando"});
        Agregar(new Alumno() { Nombres = "Roxana Noriega"});
        Agregar(new Alumno() { Nombres = "Adam Mateo"});
    }
}