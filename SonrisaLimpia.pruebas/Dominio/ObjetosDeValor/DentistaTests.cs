using SonrisaLimpia.Dominio.Entidades;
using SonrisaLimpia.Dominio.Excepciones;
using SonrisaLimpia.Dominio.ObjetosDeValor;

namespace SonrisaLimpia.Pruebas.Dominio.ObjetosDeValor
{
    [TestClass]
    public  class DentistaTests
    {
        [TestMethod]
        [ExpectedException(typeof(ExcepcionReglaNegocio))]
        public void NombreNulo_LanzarExcepcion()
        {
            var email = new Email("reynaldosolis@gmail.com");
            new Dentista(null!, email);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionReglaNegocio))]
        public void EmailNulo_LanzarExcepcion()
        {
            Email email = null!;
            new Dentista("Reynaldo", email);
        }
    }
}
