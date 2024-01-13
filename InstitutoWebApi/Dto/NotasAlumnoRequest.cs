namespace InstitutoWebApi.Dto;

public class NotasAlumnoRequest
{
    public ICollection<NotaCursoRequest> Notas { get; set; } = default!;
}