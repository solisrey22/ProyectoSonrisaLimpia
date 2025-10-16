using Microsoft.AspNetCore.Mvc;
using SonrisaLimpia.API.DTOs.Consultorios;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.ActualizarConsultorio;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.EliminarConsultorio;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio;
using SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios;
using SonrisaLimpia.Aplicacion.Utilidades.Mediador;

namespace SonrisaLimpia.API.Controllers
{
    [ApiController]
    [Route("api/Consultorios")]
    public class ConsultoriosController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<List<ConsultorioListadoDTO>>> Get()
        {
            var consulta = new ConsultaObtenerListadoConsultorios();
            var resultado = await _mediator.Send(consulta);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObtenerDetalleConsultorioDto>> Get(Guid id)
        {
            var consulta = new ConsultaObtenerDetalleConsultorio { Id = id };
            var resultado = await _mediator.Send(consulta);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CrearConsultorioDTO crearConsultorioDTO)
        {
            var comando = new ComandoCrearConsultorio { Nombre = crearConsultorioDTO.Nombre };
            await _mediator.Send(comando);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, ActualizarConsultorioDTO actualizarConsultorioDTO)
        {
            var comando = new ComandoActualizarConsultorio
            {
                Id = id,
                Nombre = actualizarConsultorioDTO.Nombre
            };
            await _mediator.Send(comando);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var comando = new ComandoBorrarConsultorio { Id = id };
            await _mediator.Send(comando);
            return NoContent();
        }
    }
}
