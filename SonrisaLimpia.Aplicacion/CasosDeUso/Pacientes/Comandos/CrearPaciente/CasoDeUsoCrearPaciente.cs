using SonrisaLimpia.Aplicacion.Contratos.Persistencia;
using SonrisaLimpia.Aplicacion.Contratos.Repositorios;
using SonrisaLimpia.Aplicacion.Utilidades.Mediador;
using SonrisaLimpia.Dominio.Entidades;
using SonrisaLimpia.Dominio.ObjetosDeValor;

namespace SonrisaLimpia.Aplicacion.CasosDeUso.Pacientes.Comandos.CrearPaciente
{
    public class CasoDeUsoCrearPaciente : IRequestHandler<ComandoCrearPaciente, Guid>
    {
        private readonly IRepositorioPacientes _repositorio;
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public CasoDeUsoCrearPaciente(IRepositorioPacientes repositorio, IUnidadDeTrabajo unidadDeTrabajo)
        {
            _repositorio = repositorio;
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<Guid> Handle(ComandoCrearPaciente request)
        {
            var email = new Email(request.Email);
            var paciente = new Paciente(request.Nombre, email);

            try
            {
                var respuesta = await _repositorio.Agregar(paciente);
                await _unidadDeTrabajo.Persistir();
                return respuesta.Id;
            }
            catch (Exception)
            {

                await _unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
