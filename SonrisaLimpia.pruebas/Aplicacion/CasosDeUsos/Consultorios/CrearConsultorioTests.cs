using NSubstitute;
using NSubstitute.ExceptionExtensions;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;
using SonrisaLimpia.Aplicacion.Contratos.Persistencia;
using SonrisaLimpia.Aplicacion.Contratos.Repositorios;
using SonrisaLimpia.Dominio.Entidades;


namespace SonrisaLimpia.Pruebas.Aplicacion.CasosDeUsos.Consultorios
{
    [TestClass]
    public class CrearConsultorioTests
    {
        private IRepositorioConsultorios? _repositorio;
        private IUnidadDeTrabajo? _unidadDeTrabajo;
        private CasoDeUsoCrearConsultorio? _casoDeUso;

        [TestInitialize]
        public void Setup()
        {
            _repositorio = Substitute.For<IRepositorioConsultorios>();
            _unidadDeTrabajo = Substitute.For<IUnidadDeTrabajo>();
            _casoDeUso = new CasoDeUsoCrearConsultorio(_repositorio, _unidadDeTrabajo);
        }

        [TestMethod]
        public async Task Handle_ComandoValido_ObtenerIdConsultorio()
        {
            var comando = new ComandoCrearConsultorio { Nombre = "Consultorio Ejemplo" };

            var consultorioCreado = new Consultorio("Consultorio Ejemplo");
            _repositorio.Agregar(Arg.Any<Consultorio>()).Returns(consultorioCreado);

            var resultado = await _casoDeUso.Handle(comando);

            await _repositorio.Received(1).Agregar(Arg.Any<Consultorio>());
            await _unidadDeTrabajo.Received(1).Persistir();
            Assert.AreNotEqual(Guid.Empty, resultado);
        }
        [TestMethod]
        public async Task Handle_CuandoHayError_HacemosRollback()
        {
            var comando = new ComandoCrearConsultorio { Nombre = "Consultorio Ejemplo" };

            _repositorio.Agregar(Arg.Any<Consultorio>()).Throws<Exception>();
     
            await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                var resultado = await _casoDeUso.Handle(comando);
            });

            await _unidadDeTrabajo.Received(1).Reversar();
        }

    }
}