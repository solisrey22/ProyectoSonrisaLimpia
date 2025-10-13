using SonrisaLimpia.Dominio.Entidades;
using SonrisaLimpia.Dominio.Excepciones;

namespace SonrisaLimpia.Pruebas.Dominio.ObjetosDeValor
{
    [TestClass]
    public class ConsultorioTests
    {
        [TestMethod]
        [ExpectedException (typeof (ExcepcionReglaNegocio))]
        public void NombreNulo_LanzarExcepcion()
        {
            new Consultorio (null!);
        }
    }
}
