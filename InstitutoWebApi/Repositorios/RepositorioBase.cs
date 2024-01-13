using InstitutoWebApi.Models;

namespace InstitutoWebApi.Repositorios;

public class RepositorioBase<T> where T : EntityBase
{
    private readonly List<T> _coleccion;

    private event Action ActualizarRegistro = delegate {};
    
    public RepositorioBase(List<T> coleccion)
    {
        _coleccion = coleccion;
    }

    public List<T> Listar()
    {
        return _coleccion;
    }

    public T? ObtenerPorId(int id)
    {
        return _coleccion.FirstOrDefault(x => x.Id == id);
    }

    public void Agregar(T entidad)
    {
        entidad.Id = _coleccion.Count + 1;
        _coleccion.Add(entidad);
    }

    public void Actualizar()
    {
        // Por ahora no va nada, pero se debe actualizar la coleccion.
        ActualizarRegistro.Invoke();
    }

    public void Eliminar(int id)
    {
        var registro = ObtenerPorId(id);
        if (registro is null)
        {
            throw new Exception($"No existe el registro con id {id}");
        }

        _coleccion.Remove(registro);
    }
}