namespace InstitutoWebApi.Models;

public class Nota : EntityBase
{
    public Alumno Alumno { get; set; } = default!;
    public int AlumnoId { get; set; } // Llave foranea
    public int Calificacion { get; set; }

    public Curso Curso { get; set; } = default!;
    public int CursoId { get; set; }
}