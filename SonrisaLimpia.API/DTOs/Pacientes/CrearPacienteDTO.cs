using System.ComponentModel.DataAnnotations;

namespace SonrisaLimpia.API.DTOs.Pacientes
{
    public class CrearPacienteDTO
    {
        [Required]
        [StringLength(250)]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [StringLength(254)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
