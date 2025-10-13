using SonrisaLimpia.Dominio.Excepciones;

namespace SonrisaLimpia.Dominio.ObjetosDeValor
{
   public record IntervaloTiempo
    {
        public DateTime FechaInicio { get; }
        public DateTime FechaFin { get; }

        public IntervaloTiempo(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio >= fechaFin)
            {
                throw new ExcepcionReglaNegocio("La fecha de inicio debe ser anterior a la fecha de fin.");
            }

            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }
    }
}
