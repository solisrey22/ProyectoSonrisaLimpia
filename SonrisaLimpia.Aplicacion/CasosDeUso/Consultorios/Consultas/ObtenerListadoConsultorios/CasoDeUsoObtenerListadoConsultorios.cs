using SonrisaLimpia.Aplicacion.Contratos.Repositorios;
using SonrisaLimpia.Aplicacion.Utilidades.Mediador;

namespace SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios
{
    public class CasoDeUsoObtenerListadoConsultorios : IRequestHandler<ConsultaObtenerListadoConsultorios, List<ConsultorioListadoDTO>>
    {
        private readonly IRepositorioConsultorios? _repositorioConsultorios;
        public CasoDeUsoObtenerListadoConsultorios(IRepositorioConsultorios repositorioConsultorios)
        {
            _repositorioConsultorios = repositorioConsultorios;
        }
        public async Task<List<ConsultorioListadoDTO>> Handle(ConsultaObtenerListadoConsultorios request)
        {
           var consultorios =  await _repositorioConsultorios!.ObtenerTodos();
            var consultoriosDTO = consultorios.Select(consultorio => consultorio.ADto()).ToList();
            return consultoriosDTO;
        }
    }
}
