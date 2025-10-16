using System.ComponentModel.DataAnnotations;

namespace SonrisaLimpia.API.DTOs.Consultorios
{
    public class ActualizarConsultorioDTO
    {
        [Required]
        [StringLength(150)]
        public required string Nombre { get; set; } 
    }
}
