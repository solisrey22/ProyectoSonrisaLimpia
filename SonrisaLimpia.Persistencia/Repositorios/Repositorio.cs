using Microsoft.EntityFrameworkCore;
using SonrisaLimpia.Aplicacion.Contratos.Repositorios;

namespace SonrisaLimpia.Persistencia.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly SonrisaLimpiaDbContext context;

        public Repositorio(SonrisaLimpiaDbContext Context)
        {
            context = Context;
        }
        public Task Actualizar(T entidad)
        {
            context .Update(entidad);
            return Task.CompletedTask;
        }

        public Task<T?> Agregar(T entidad)
        {
           context.Add(entidad);
            return Task.FromResult<T?>(entidad);
        }

        public Task Borrar(T entidad)
        {
            context.Remove(entidad);
            return Task.CompletedTask;
        }

        public async Task<T?> ObtenerPorId(Guid id)
        {
            return await context.FindAsync<T>(id);
        }

        public async Task<IEnumerable<T>> ObtenerTodos()
        {
           return await context.Set<T>().ToListAsync();
        }
    }
}
