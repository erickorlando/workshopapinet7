namespace InstitutoWebApi.Models;

public class NotasInfo
{
    public string NombreAlumno { get; set; } = default!;
    public ICollection<Calificaciones> Calificaciones { get; set; } = default!;
}

public class Calificaciones
{
    public string NombreCurso { get; set; } = default!;
    public int Calificacion { get; set; }
}