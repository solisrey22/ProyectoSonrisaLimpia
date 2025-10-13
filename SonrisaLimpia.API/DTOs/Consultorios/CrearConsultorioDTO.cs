using System.ComponentModel.DataAnnotations;

namespace SonrisaLimpia.API.DTOs.Consultorios
{
    public class CrearConsultorioDTO
    {
        [Required]
        [StringLength(150)]
        required public string Nombre { get; set;} = string.Empty;
        }
}
