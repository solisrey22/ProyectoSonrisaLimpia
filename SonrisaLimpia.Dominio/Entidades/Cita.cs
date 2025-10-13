using SonrisaLimpia.Dominio.Enums;
using SonrisaLimpia.Dominio.Excepciones;
using SonrisaLimpia.Dominio.ObjetosDeValor;

namespace SonrisaLimpia.Dominio.Entidades
{
    public  class Cita
    {
        private Guid pacienteId;
        private Guid dentistaId;
        private Guid consultorioId;
        private IntervaloTiempo intervalo;

        public Guid Id { get; private set; }
        public Guid PacienteId { get; private set; } 
        public Guid DentistaId { get; private set; } 
        public Guid ConsultorioId { get; private set; } 
        public EstadoCita Estado { get; private set; } 
        public IntervaloTiempo IntervaloTiempo { get; private set; }
        public Paciente? Paciente { get; private set; } 
        public Dentista? Dentista { get; private set; } 
        public Consultorio? Consultorio { get; private set; }


        public Cita(Guid pacienteId, Guid dentistaId, Guid consultorioId, IntervaloTiempo intervaloTiempo)
        {
            
            if (intervaloTiempo.FechaInicio < DateTime.UtcNow)
            {
                throw new ExcepcionReglaNegocio($"La fecha de inicio no puede ser anterior a la fecha actual");
            }

            PacienteId = pacienteId;
            DentistaId = dentistaId;
            ConsultorioId = consultorioId;
            IntervaloTiempo = intervaloTiempo;
            Estado = EstadoCita.programada;
            Id = Guid.CreateVersion7();
        }

        public void Cancelar()
        {
            if (Estado == EstadoCita.cancelada || Estado != EstadoCita.programada)
            {
                throw new ExcepcionReglaNegocio("Solo se pueden cancelar citas programada o la cita ya está cancelada.");
            }
            Estado = EstadoCita.cancelada;
        }

        public void Completar()
        {
            if (Estado != EstadoCita.programada)
            {
                throw new ExcepcionReglaNegocio("Solo se pueden completar citas programada");
            }
            Estado = EstadoCita.completada;
        }
    }
}
