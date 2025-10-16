using SonrisaLimpia.Aplicacion.Utilidades.Mediador;

namespace SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.EliminarConsultorio
{
    public class ComandoBorrarConsultorio : IRequest
    {
        public Guid Id { get; set; }

    }
}

