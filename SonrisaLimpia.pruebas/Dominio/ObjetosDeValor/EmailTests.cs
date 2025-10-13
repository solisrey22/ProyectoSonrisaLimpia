using SonrisaLimpia.Dominio.Excepciones;
using SonrisaLimpia.Dominio.ObjetosDeValor;

namespace SonrisaLimpia.Pruebas.Dominio.ObjetosDeValor
{
    [TestClass]
    public class EmailTest
    {

        [TestMethod]
        [ExpectedException(typeof(ExcepcionReglaNegocio))]
        public void EmailNulo_LanzaExcepcion()
        {
            new Email(null!);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionReglaNegocio))]
        public void EmailSinArroba_LanzaExcepcion()
        {
            new Email("reynaldosolis.com");

        }

        [TestMethod]
        public void EmailValido_NoLanzaExcepcion()
        {
            _ = new Email("reynaldosolis@gmail.com");

        }
    }
}

