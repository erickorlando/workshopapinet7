namespace InstitutoWebApi.Dto;

public class AlumnoRequest
{
    public string Nombres { get; set; } = default!;
    public string Correo { get; set; } = default!;
    public int Edad { get; set; } 
}