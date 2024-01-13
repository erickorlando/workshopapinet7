using InstitutoWebApi.Data;
using InstitutoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InstitutoWebApi.Repositorios;

public class RepositoryBase<T> where T : EntityBase
{
    protected readonly InstitutoDbContext DbContext;

    public RepositoryBase(InstitutoDbContext dbContext)
    {
        DbContext = dbContext;
    }
    
    public async Task<List<T>> Listar()
    {
        return await DbContext
            .Set<T>()
            .ToListAsync();
    }

    public async Task<T?> ObtenerPorId(int id)
    {
        return await DbContext
            .Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Agregar(T entidad)
    {
        await DbContext
            .Set<T>()
            .AddAsync(entidad); // Esto lo agrega a la coleccion de entidades que se van a guardar.
        await DbContext.SaveChangesAsync();
    }

    public async Task Agregar(ICollection<T> entidades)
    {
        await DbContext.Set<T>()
            .AddRangeAsync(entidades);

        await DbContext.SaveChangesAsync();
    }

    public async Task Actualizar()
    {
        await DbContext.SaveChangesAsync();
    }

    public async Task Eliminar(int id)
    {
        var registro = await ObtenerPorId(id);
        if (registro is null)
        {
            throw new Exception($"No existe el registro con id {id}");
        }
        
        DbContext.Set<T>().Remove(registro);
        await DbContext.SaveChangesAsync();
    }
}