using SonrisaLimpia.Dominio.Entidades;

namespace SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio
{
    public static class MapeadorExtensions
    {
        public static ObtenerDetalleConsultorioDto MapearADto(this Consultorio consultorio)
        {
            return new ObtenerDetalleConsultorioDto
            {
                Id = consultorio.Id,
                Nombre = consultorio.Nombre
            };
        }
    }
}
