using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.EliminarConsultorio;
using SonrisaLimpia.Aplicacion.Contratos.Persistencia;
using SonrisaLimpia.Aplicacion.Contratos.Repositorios;
using SonrisaLimpia.Aplicacion.Excepciones;
using SonrisaLimpia.Dominio.Entidades;

namespace SonrisaLimpia.Pruebas.Aplicacion.CasosDeUsos.Consultorios
{
    [TestClass]
    public class CasoDeUsoBorrarConsultorioTests
    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
        private IRepositorioConsultorios _repositorio;
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private CasoDeUsoBorrarConsultorio _casoDeUso;
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.

        [TestInitialize]
        public void Setup()
        {

            _repositorio = Substitute.For< IRepositorioConsultorios>();
            _unidadDeTrabajo = Substitute.For<IUnidadDeTrabajo>();
            _casoDeUso = new CasoDeUsoBorrarConsultorio(_repositorio, _unidadDeTrabajo);
        }

        [TestMethod]
        public async Task Handle_CuandoConsultorioExiste_TieneQueBorrar()
        {
            // Arrange
            var consultorioId = Guid.NewGuid();
            var comando = new ComandoBorrarConsultorio { Id = consultorioId };
            var consultorio = new Consultorio("Consultorio A");

            _repositorio.ObtenerPorId(consultorioId).Returns(consultorio);

            await _casoDeUso.Handle(comando);
            await _repositorio.Received(1).Borrar(consultorio);
            await _unidadDeTrabajo.Received(1).Persistir();

        }
        [TestMethod]
        [ExpectedException(typeof(ExcepcionNoEncontrado))]
        public async Task Handle_CuandoConsultorioNoExiste_LanzaExcepcionNoEncontrado()
        {
        
            var comando = new ComandoBorrarConsultorio { Id = Guid.NewGuid() };
            _repositorio.ObtenerPorId(comando.Id).ReturnsNull();
      
            await _casoDeUso.Handle(comando);
        }
        [TestMethod]
        public async Task Handle_CuandoOcurreError_LlamarAReversarYLanzarExcepcion()
        {
            var consultorioId = Guid.NewGuid();
            var comando = new ComandoBorrarConsultorio { Id = consultorioId };
            var consultorio = new Consultorio("Consultorio A");
           
            _repositorio.ObtenerPorId(consultorioId).Returns(consultorio);
            _repositorio.Borrar(consultorio).Throws(new InvalidOperationException("Fallo al Borrar."));

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => _casoDeUso.Handle(comando));
            await _unidadDeTrabajo.Received(1).Reversar();
            
        }   
    }
}
