using SonrisaLimpia.Dominio.Entidades;

namespace SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios
{
    public static class MapeadorExtensions
    {
        public static ConsultorioListadoDTO ADto (this Consultorio consultorio)
        {
            var dto = new ConsultorioListadoDTO {ID = consultorio.Id, Nombre = consultorio.Nombre};
            return dto;
        }
    }
}
