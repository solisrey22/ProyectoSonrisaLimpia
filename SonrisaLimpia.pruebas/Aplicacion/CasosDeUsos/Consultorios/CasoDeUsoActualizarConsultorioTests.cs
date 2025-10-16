using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.ActualizarConsultorio;
using SonrisaLimpia.Aplicacion.Contratos.Persistencia;
using SonrisaLimpia.Aplicacion.Contratos.Repositorios;
using SonrisaLimpia.Aplicacion.Excepciones;
using SonrisaLimpia.Dominio.Entidades;

namespace SonrisaLimpia.Pruebas.Aplicacion.CasosDeUsos.Consultorios
{
    [TestClass]
    public class CasoDeUsoActualizarConsultorioTests
    {
        private IRepositorioConsultorios? _repositorio;
        private IUnidadDeTrabajo? _unidadDeTrabajo;
        private CasoDeUsoActualizarConsultorio? _casoDeUso;

        [TestInitialize]
        public void Setup()
        {
            _repositorio = Substitute.For<IRepositorioConsultorios>();
            _unidadDeTrabajo = Substitute.For<IUnidadDeTrabajo>();
            _casoDeUso = new CasoDeUsoActualizarConsultorio(_repositorio, _unidadDeTrabajo);
        }
        [TestMethod]
        public async Task Handle_CuandoConsultorioExiste_ActualizaNombreYPersiste()
        {
           var consultorio = new Consultorio("Consultorio Original");
           var id = consultorio.Id;
            var comando = new ComandoActualizarConsultorio
            {
                Id = id,
                Nombre = "Consultorio Actualizado"
            };

            _repositorio!.ObtenerPorId(id).Returns(consultorio);
            await _casoDeUso!.Handle(comando);
            await _repositorio.Received(1).Actualizar(consultorio);
            await _unidadDeTrabajo!.Received(1).Persistir();
        }
        [TestMethod]
        [ExpectedException(typeof(ExcepcionNoEncontrado))]
        public async Task Handle_CuandoConsultorioNoExiste_LanzaExcepcionNoEncontrado()
        {
            var comando = new ComandoActualizarConsultorio
            {
                Id = Guid.NewGuid(),
                Nombre = "Consultorio Actualizado"
            };
           _repositorio!.ObtenerPorId(comando.Id).ReturnsNull();
            await _casoDeUso!.Handle(comando);
        }

        [TestMethod]
        public async Task Handle_CuandoOcurreExcepcionActualizar_LlamarAReversarYLanzaExcepcion()
        {
            var consultorio = new Consultorio("Consultorio Original");
            var id = consultorio.Id;
            var comando = new ComandoActualizarConsultorio
            {
                Id = id,
                Nombre = "Consultorio Actualizado"
            };
            _repositorio!.ObtenerPorId(id).Returns(consultorio);
            _unidadDeTrabajo!.Persistir().Throws(new InvalidOperationException("Error al actualizar."));
           
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() =>_casoDeUso!.Handle(comando));
            await _unidadDeTrabajo.Received(1).Reversar();
        }

    }
}
