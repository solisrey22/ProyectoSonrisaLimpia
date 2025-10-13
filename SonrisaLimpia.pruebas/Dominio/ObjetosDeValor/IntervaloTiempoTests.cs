using SonrisaLimpia.Dominio.Excepciones;
using SonrisaLimpia.Dominio.ObjetosDeValor;

namespace SonrisaLimpia.Pruebas.Dominio.ObjetosDeValor
{
    [TestClass]
    public class IntervaloTiempoTests
    {

        [TestMethod]
        [ExpectedException(typeof(ExcepcionReglaNegocio))]
        public void FechaInicioPosteriorFechaFin_LanzaExcepcion()
        {
            new IntervaloTiempo(DateTime.UtcNow, DateTime.UtcNow.AddDays(-1));

        }

        [TestMethod]
        public void ParametroCorrectos_NoLanzaExcepcion()
        {
            _ = new IntervaloTiempo(DateTime.UtcNow, DateTime.UtcNow.AddMinutes(30));

        }
    }
}
