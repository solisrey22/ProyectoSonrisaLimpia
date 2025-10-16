using NSubstitute;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios;
using SonrisaLimpia.Aplicacion.Contratos.Repositorios;
using SonrisaLimpia.Dominio.Entidades;

namespace SonrisaLimpia.Pruebas.Aplicacion.CasosDeUsos.Consultorios
{
    [TestClass]
    public class CasoDeUsoObtenerListadoConsultoriosTests
    {
        private IRepositorioConsultorios _repositorio;
        private CasoDeUsoObtenerListadoConsultorios _casoDeUsoO;

        [TestInitialize]
        public void Setup()
        {
            _repositorio = Substitute.For<IRepositorioConsultorios>();
            _casoDeUsoO = new CasoDeUsoObtenerListadoConsultorios(_repositorio);
        }

        [TestMethod]
        public async Task Handle_CuandoHayConsultorios_RetornaListaDeConsultorioListadoDTO()
        {
            var consultorios = new List<Consultorio>
            {
                new Consultorio("Consultorio A"),
                new Consultorio("Consultorio B")
            };

            _repositorio.ObtenerTodos().Returns(consultorios);
            var esperado = consultorios.Select(c => new ConsultorioListadoDTO { ID = c.Id, Nombre = c.Nombre }).ToList();
            
            var resultado = await _casoDeUsoO.Handle(new ConsultaObtenerListadoConsultorios());

            Assert.AreEqual(esperado.Count, resultado.Count);

            for (int i = 0; i < esperado.Count; i++)
            {
                Assert.AreEqual(esperado[i].ID, resultado[i].ID);
                Assert.AreEqual(esperado[i].Nombre, resultado[i].Nombre);
            }
        }

        [TestMethod]
        public async Task Handle_CuandoNoHayConsultorios_RetornaListaVacia()
        {
            _repositorio.ObtenerTodos().Returns([]);

            var resultado = await _casoDeUsoO.Handle(new ConsultaObtenerListadoConsultorios());

            Assert.IsNotNull(resultado);
            Assert.AreEqual(0, resultado.Count);
        }
    }
}
