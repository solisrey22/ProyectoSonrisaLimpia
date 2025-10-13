using NSubstitute;
using NSubstitute.ReturnsExtensions;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio;
using SonrisaLimpia.Aplicacion.Contratos.Repositorios;
using SonrisaLimpia.Aplicacion.Excepciones;
using SonrisaLimpia.Dominio.Entidades;

namespace SonrisaLimpia.Pruebas.Aplicacion.CasosDeUsos.Consultorios
{
    [TestClass]
    public class CasoDeUsoObtenerDetalleConsultorioTests
    {
        private IRepositorioConsultorios _repositorioConsultorios; 
        private CasoDeUsoObtenerDetalleConsultorio _casoDeUso;

        [TestInitialize]
        public void SetUp()
        {
            _repositorioConsultorios = Substitute.For<IRepositorioConsultorios>();
            _casoDeUso = new CasoDeUsoObtenerDetalleConsultorio(_repositorioConsultorios);
        }

        [TestMethod]
        public async Task Handle_ConsultorioExiste_RetornaDTO()
        {
            // Preparación
            var consultorio = new Consultorio("Consultorio A");
            var id = consultorio.Id;
            var consulta = new ConsultaObtenerDetalleConsultorio { Id = id };

            _repositorioConsultorios.ObtenerPorId(id).Returns(consultorio);

            // Prueba
            var resultado = await _casoDeUso.Handle(consulta);

            // Verificación
            Assert.IsNotNull(resultado);
            Assert.AreEqual(id, resultado.Id);
            Assert.AreEqual("Consultorio A", resultado.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionNoEncontrado))]
        public async Task Handle_ConsultorioNoExiste_LanzaExcepcionNoEncontrado()
        {
            // Preparación
            var id = Guid.NewGuid();
            var consulta = new ConsultaObtenerDetalleConsultorio { Id = id };

            _repositorioConsultorios.ObtenerPorId(id).ReturnsNull();

            // Prueba
            await _casoDeUso.Handle(consulta);
        }


    }



}
