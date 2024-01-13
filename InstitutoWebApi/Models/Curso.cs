using System.ComponentModel.DataAnnotations;

namespace InstitutoWebApi.Models;

public class Curso : EntityBase
{
    [StringLength(200)]
    public string Nombre { get; set; } = default!;

    [StringLength(100)]
    public string Categoria { get; set; } = default!;
}