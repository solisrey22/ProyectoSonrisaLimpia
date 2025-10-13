using SonrisaLimpia.Dominio.Entidades;
using SonrisaLimpia.Dominio.Enums;
using SonrisaLimpia.Dominio.Excepciones;
using SonrisaLimpia.Dominio.ObjetosDeValor;

namespace SonrisaLimpia.Pruebas.Dominio.ObjetosDeValor
{
    [TestClass]
    public class CitasTests
    {
        private Guid _pacienteId = Guid.NewGuid();
        private Guid _dentistaId = Guid.NewGuid();
        private Guid _consultorioId = Guid.NewGuid();
        private IntervaloTiempo _intervalo = new (DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));

        [TestMethod]
        public void Constructor_CitaValida_EstadoEsProgramada()
        {
            var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, _intervalo);

            Assert.AreEqual(_pacienteId, cita.PacienteId);
            Assert.AreEqual(_dentistaId, cita.DentistaId);
            Assert.AreEqual(_consultorioId, cita.ConsultorioId);
            Assert.AreEqual(_intervalo, cita.IntervaloTiempo);
            Assert.AreEqual(EstadoCita.programada, cita.Estado);
            Assert.AreNotEqual(Guid.Empty, cita.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionReglaNegocio))]
        public void FechaInicioEnElPasado_LanzaExcepcion()
        {
            var intervaloPasado = new IntervaloTiempo(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow);
            var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, intervaloPasado);

        }
        [TestMethod]
        public void Cancelar_CitaProgramada_EstadoEsCancelada()
        {
            var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, _intervalo);
            cita.Cancelar();
            Assert.AreEqual(EstadoCita.cancelada, cita.Estado);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionReglaNegocio))]
        public void Cancelar_CitaNoProgramada_LanzaExcepcion()
        {
            var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, _intervalo);
            cita.Cancelar();
            cita.Cancelar();
        } 

        [TestMethod]
        public void Completar_CitaProgramada_EstadoEsCompletada()
        {
            var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, _intervalo);
            cita.Completar();
            Assert.AreEqual(EstadoCita.completada, cita.Estado);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionReglaNegocio))]
        public void Completar_CitaNoProgramada_LanzaExcepcion()
        {
            var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, _intervalo);
            cita.Cancelar();
            cita.Completar();
        }



    }

}
