using Microsoft.Extensions.DependencyInjection;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.ActualizarConsultorio;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios;
using SonrisaLimpia.Aplicacion.Utilidades.Mediador;

namespace SonrisaLimpia.Aplicacion
{
    public static class RegistroServicioAplicacion 
    {

        public static IServiceCollection AgregarServiciosAplicacion(this IServiceCollection services)
        {
            // Aquí puedes agregar servicios específicos de la capa de aplicación
            // Por ejemplo, servicios de mediación, validadores, etc.
            // services.AddTransient<IRequestHandler<ConsultaObtenerDetalleConsultorio, ObtenerDetalleConsultorioDto>, CasoDeUsoObtenerDetalleConsultorio>();
            services.AddTransient<IMediator, MediadorSimple>();
            services.AddScoped <IRequestHandler<ComandoCrearConsultorio,Guid>, CasoDeUsoCrearConsultorio>();
            services.AddScoped<IRequestHandler<ConsultaObtenerDetalleConsultorio, ObtenerDetalleConsultorioDto>, CasoDeUsoObtenerDetalleConsultorio>();
            services.AddScoped<IRequestHandler<ConsultaObtenerListadoConsultorios, List<ConsultorioListadoDTO>>, CasoDeUsoObtenerListadoConsultorios>();
            services.AddScoped<IRequestHandler<ComandoActualizarConsultorio>, CasoDeUsoActualizarConsultorio>();
            return services;
        }
    }
}
