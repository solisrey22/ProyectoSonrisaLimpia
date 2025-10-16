using Microsoft.Extensions.DependencyInjection;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.ActualizarConsultorio;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.EliminarConsultorio;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios;
using SonrisaLimpia.Aplicacion.Utilidades.Mediador;

namespace SonrisaLimpia.Aplicacion
{
    public static class RegistroServicioAplicacion 
    {

        public static IServiceCollection AgregarServiciosAplicacion(this IServiceCollection services)
        {
            services.AddTransient<IMediator, MediadorSimple>();
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(IMediator))
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            // Aquí puedes agregar servicios específicos de la capa de aplicación
            // Por ejemplo, servicios de mediación, validadores, etc.

            //services.AddTransient<IMediator, MediadorSimple>();
            //services.AddScoped <IRequestHandler<ComandoCrearConsultorio,Guid>, CasoDeUsoCrearConsultorio>();
            //services.AddScoped<IRequestHandler<ConsultaObtenerDetalleConsultorio, ObtenerDetalleConsultorioDto>, CasoDeUsoObtenerDetalleConsultorio>();
            //services.AddScoped<IRequestHandler<ConsultaObtenerListadoConsultorios, List<ConsultorioListadoDTO>>, CasoDeUsoObtenerListadoConsultorios>();
            //services.AddScoped<IRequestHandler<ComandoActualizarConsultorio>, CasoDeUsoActualizarConsultorio>();
            //services.AddScoped<IRequestHandler<ComandoBorrarConsultorio>, CasoDeUsoBorrarConsultorio>();
            return services;
        }
    }
}
