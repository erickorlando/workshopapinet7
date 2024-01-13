namespace InstitutoWebApi.Models;

public class Alumno : EntityBase
{
    public string Nombres { get; set; } = default!;
    public string Correo { get; set; } = default!;
    public int Edad { get; set; }
    public bool Estado { get; set; }
    
    // Propiedad de Navegacion
    public ICollection<Nota> Notas { get; set; } = default!;
}