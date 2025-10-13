using SonrisaLimpia.Aplicacion.Utilidades.Mediador;

namespace SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio
{
    public class ComandoCrearConsultorio : IRequest<Guid>
    {
        public required string Nombre { get; set; }
    }
}
