using NSubstitute;
using NSubstitute.ExceptionExtensions;
using SonrisaLimpia.Aplicacion.CasosDeUso.Pacientes.Comandos.CrearPaciente;
using SonrisaLimpia.Aplicacion.Contratos.Persistencia;
using SonrisaLimpia.Aplicacion.Contratos.Repositorios;
using SonrisaLimpia.Dominio.Entidades;
using SonrisaLimpia.Dominio.ObjetosDeValor;

namespace SonrisaLimpia.Pruebas.Aplicacion.CasosDeUsos.Pacientes
{
    [TestClass]
    public class CrearPacienteTests
    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
        private IRepositorioPacientes _repositorio;
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private CasoDeUsoCrearPaciente _casoDeUso;
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.

        [TestInitialize]
        public void Setup()
        {
            _repositorio = Substitute.For<IRepositorioPacientes>();
            _unidadDeTrabajo = Substitute.For<IUnidadDeTrabajo>();
            _casoDeUso = new CasoDeUsoCrearPaciente(_repositorio, _unidadDeTrabajo);
        }

        [TestMethod]
        public async Task Handle_CuandoDatosValidos_CrearPacienteYPersisteYRetornaId()
        {
            var comando = new ComandoCrearPaciente { Nombre = "Juan Perez", Email = "juancito@gmail.com" };
            var pacienteCreado = new Paciente(comando.Nombre, new Email(comando.Email));
            var id = pacienteCreado.Id;

            _repositorio.Agregar(Arg.Any<Paciente>()).Returns(pacienteCreado);

            var idResultado = await _casoDeUso.Handle(comando);

            Assert.AreEqual(id, idResultado);
            await _repositorio.Received(1).Agregar(Arg.Any<Paciente>());
            await _unidadDeTrabajo.Received(1).Persistir();
        }

        [TestMethod]
        public async Task Handle_CuandoOcurreExcepcion_ReversarYLanzaExcepcion()
        {
            var comando = new ComandoCrearPaciente { Nombre = "Juan Perez", Email = "juancito@gmail.com" };

            _repositorio.Agregar(Arg.Any<Paciente>()).Throws(new InvalidOperationException("Error al insertar datos"));

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => _casoDeUso.Handle(comando));
            await _unidadDeTrabajo.Received(1).Reversar();
            await _unidadDeTrabajo.DidNotReceive().Persistir();
        }
    }
}
