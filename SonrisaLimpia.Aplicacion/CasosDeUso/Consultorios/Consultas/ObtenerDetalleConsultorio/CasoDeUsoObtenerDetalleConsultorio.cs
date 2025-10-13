using SonrisaLimpia.Aplicacion.Contratos.Repositorios;
using SonrisaLimpia.Aplicacion.Excepciones;
using SonrisaLimpia.Aplicacion.Utilidades.Mediador;

namespace SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio
{
    public class CasoDeUsoObtenerDetalleConsultorio  : IRequestHandler<ConsultaObtenerDetalleConsultorio, ObtenerDetalleConsultorioDto>
    {
        private readonly IRepositorioConsultorios _repositorio;
        public CasoDeUsoObtenerDetalleConsultorio(IRepositorioConsultorios repositorio)
        {
            _repositorio = repositorio;
        }


        public async Task<ObtenerDetalleConsultorioDto> Handle(ConsultaObtenerDetalleConsultorio request)
        {
           var Consultorio = await _repositorio.ObtenerPorId(request.Id);

           if (Consultorio is null)
            {
              throw new ExcepcionNoEncontrado();
            }

           //var dto = new ObtenerDetalleConsultorioDto
           //{
           //    Id = Consultorio.Id,
           //    Nombre = Consultorio.Nombre
           //};

           //return dto;

           return Consultorio.MapearADto();
        }
    }
}


