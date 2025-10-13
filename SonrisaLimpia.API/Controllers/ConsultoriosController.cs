using Microsoft.AspNetCore.Mvc;
using SonrisaLimpia.API.DTOs.Consultorios;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio;
using SonrisaLimpia.Aplicacion.Utilidades.Mediador;

namespace SonrisaLimpia.API.Controllers
{
    [ApiController]
    [Route("api/Consultorios")]
    public class ConsultoriosController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{id}")]
        public async Task<ActionResult<ObtenerDetalleConsultorioDto>> Get(Guid id)
        {
            var consulta = new ConsultaObtenerDetalleConsultorio {Id = id};
            var consultorios = await _mediator.Send(consulta);
            return Ok(consultorios);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CrearConsultorioDTO crearConsultorioDTO)
        {
            var comando = new ComandoCrearConsultorio { Nombre = crearConsultorioDTO.Nombre };
            await _mediator.Send(comando);
            return Ok();
        }
    }
}
