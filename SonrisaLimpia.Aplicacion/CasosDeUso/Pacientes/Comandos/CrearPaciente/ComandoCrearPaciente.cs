using SonrisaLimpia.Aplicacion.Utilidades.Mediador;

namespace SonrisaLimpia.Aplicacion.CasosDeUso.Pacientes.Comandos.CrearPaciente
{
    public class ComandoCrearPaciente : IRequest<Guid>
    {
        public required string Nombre { get; set; }
        public required string Email { get; set; }
    }
}
