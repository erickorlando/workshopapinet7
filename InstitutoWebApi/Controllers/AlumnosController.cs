using InstitutoWebApi.Dto;
using InstitutoWebApi.Models;
using InstitutoWebApi.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace InstitutoWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlumnosController : ControllerBase
{
    private readonly AlumnoRepositorio _repositorio;
    private readonly AlumnoRepository _repository;
    private readonly NotaRepository _notaRepository;

    public AlumnosController(AlumnoRepositorio repositorio, AlumnoRepository repository, NotaRepository notaRepository)
    {
        _repositorio = repositorio;
        _repository = repository;
        _notaRepository = notaRepository;
    }

    [HttpGet]
    public List<Alumno> Listar()
    {
        return _repositorio.Listar();
    }

    [HttpGet("basedatos")]
    public async Task<List<Alumno>> ListarBaseDatos()
    {
        return await _repository.Listar();
    }

    [HttpPost]
    public void Post(Alumno request)
    {
        _repositorio.Agregar(request);
    }

    [HttpPost("basedatos")]
    public async Task<IActionResult> PostBaseDatos(AlumnoRequest request)
    {
        await _repository.Agregar(new Alumno()
        {
            Nombres = request.Nombres,
            Correo = request.Correo,
            Edad = request.Edad,
            Estado = true
        });
        return Ok();
    }

    [HttpPost("{id:int}/notas")]
    public async Task<IActionResult> PostNotas(int id, NotasAlumnoRequest request)
    {
        try
        {
            // Buscamos el alumno primero
            var alumno = await _repository.ObtenerPorId(id);
            if (alumno is null)
            {
                return NotFound(new { Mensaje = "El alumno no existe!" });
            }

            var coleccionNotas = new List<Nota>();
            // Registrar las notas
            foreach (var requestNota in request.Notas)
            {
                var nota = new Nota()
                {
                    AlumnoId = alumno.Id,
                    Calificacion = requestNota.Calificacion,
                    CursoId = requestNota.CursoId
                };

                //// Esto hace el registro individual
                //await _notaRepository.Agregar(nota);
                
                coleccionNotas.Add(nota);
            }

            await _notaRepository.Agregar(coleccionNotas);

            return Ok(new { Mensaje = "Se registraron las notas correctamente" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Mensaje = "No se pudo procesar la solicitud" });
        }
    }

    [HttpGet("{id:int}/notas")]
    public async Task<IActionResult> GetNotas(int id)
    {
        // Primero buscamos el alumno
        var alumno = await _repository.ObtenerPorId(id);

        if (alumno is null)
        {
            return NotFound(new { Mensaje = $"El alumno con el id {id} no existe!" });
        }
        
        // Recuperamos las notas.
        var notas = await _notaRepository.ListarNotas(id);

        return Ok(new
        {
            NombresCompletos = alumno.Nombres,
            Notas = notas.Select(x => new
            {
                Curso = x.Curso.Nombre,
                x.Calificacion // Cuando el nombre de la propiedad es igual al resultado, no es necesario colocarla
            })
        });
    }
    
    [HttpGet("{id:int}/notas/mejorado")]
    public async Task<IActionResult> GetNotasMejorado(int id)
    {
        // Primero buscamos el alumno
        var alumno = await _repository.ObtenerPorId(id);

        if (alumno is null)
        {
            return NotFound(new { Mensaje = $"El alumno con el id {id} no existe!" });
        }
        
        // Recuperamos las notas.
        var notas = await _notaRepository.ListarNotasMejorado(id);
        
        return notas == null ? NotFound() : Ok(notas); // If de una sola linea o expresion ternaria
    }
}