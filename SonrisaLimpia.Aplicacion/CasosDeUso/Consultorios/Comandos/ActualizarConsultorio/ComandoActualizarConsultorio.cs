using SonrisaLimpia.Aplicacion.Utilidades.Mediador;

namespace SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.ActualizarConsultorio
{
    public class ComandoActualizarConsultorio : IRequest
    {
        public Guid Id { get; set; }
        public required string Nombre { get; set; }
    }
}
