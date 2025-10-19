using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SonrisaLimpia.Aplicacion.Contratos.Persistencia;
using SonrisaLimpia.Aplicacion.Contratos.Repositorios;
using SonrisaLimpia.Persistencia.Repositorios;
using SonrisaLimpia.Persistencia.UnidadesDeTrabajo;

namespace SonrisaLimpia.Persistencia
{
    public static class RegistroServicioPersistencia
    {
        public static IServiceCollection AgregarServiciosPersistencia(this IServiceCollection services)
        {
            services.AddDbContext<SonrisaLimpiaDbContext>(options =>
                options.UseSqlServer("name=SonrisaLimpiaConnectionString"));
            
            services.AddScoped<IRepositorioConsultorios, RepositorioConsultorio>();
            services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajoEFCore>();
            services.AddScoped<IRepositorioPacientes, RepositorioPacientes>();
            return services;
        }
    }
}
