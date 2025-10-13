using FluentValidation;
using SonrisaLimpia.Aplicacion.Contratos.Persistencia;
using SonrisaLimpia.Aplicacion.Contratos.Repositorios;
using SonrisaLimpia.Aplicacion.Utilidades.Mediador;
using SonrisaLimpia.Dominio.Entidades;

namespace SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio
{
    public class CasoDeUsoCrearConsultorio : IRequestHandler<ComandoCrearConsultorio, Guid>
    {
        private readonly IRepositorioConsultorios? _repositorioConsultorios;
        private readonly IUnidadDeTrabajo? _unidadDeTrabajo;
        private readonly IValidator<ComandoCrearConsultorio>? _validador;

        public CasoDeUsoCrearConsultorio(IRepositorioConsultorios repositorioConsultorios, IUnidadDeTrabajo unidadDeTrabajo)
        {
            _repositorioConsultorios = repositorioConsultorios;
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<Guid> Handle(ComandoCrearConsultorio comando)
        {

            //var resultadoValidacion = await _validador!.ValidateAsync(comando);

            //if (!resultadoValidacion.IsValid)
            //{
            //    throw new ExcepcionDeValidacion(resultadoValidacion);
            //}

            var consultorio = new Consultorio(comando.Nombre);

            try
            {
                var respuesta = await _repositorioConsultorios!.Agregar(consultorio);
                await _unidadDeTrabajo!.Persistir();
                return respuesta!.Id;
            }
            catch (Exception)
            {
                await _unidadDeTrabajo!.Reversar();
                throw;
            }
           
        }
    }
}
