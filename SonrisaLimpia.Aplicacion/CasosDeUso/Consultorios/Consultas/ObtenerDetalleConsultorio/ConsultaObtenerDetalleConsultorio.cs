using SonrisaLimpia.Aplicacion.Utilidades.Mediador;

namespace SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio
{
    public class ConsultaObtenerDetalleConsultorio: IRequest<ObtenerDetalleConsultorioDto>
    {
        public Guid Id { get; set; }
    }
}
