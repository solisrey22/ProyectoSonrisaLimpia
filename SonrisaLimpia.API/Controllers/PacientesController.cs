using Microsoft.AspNetCore.Mvc;
using SonrisaLimpia.API.DTOs.Pacientes;
using SonrisaLimpia.Aplicacion.CasosDeUso.Pacientes.Comandos.CrearPaciente;
using SonrisaLimpia.Aplicacion.Utilidades.Mediador;

namespace SonrisaLimpia.API.Controllers
{
    [ApiController]
    [Route("api/pacientes")]
    public class PacientesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PacientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CrearPacienteDTO crearPacienteDTO)
        {
            var comando = new ComandoCrearPaciente
            {
                Nombre = crearPacienteDTO.Nombre,
                Email = crearPacienteDTO.Email
            };

            await _mediator.Send(comando);
            return Ok();

        }
    }
}
