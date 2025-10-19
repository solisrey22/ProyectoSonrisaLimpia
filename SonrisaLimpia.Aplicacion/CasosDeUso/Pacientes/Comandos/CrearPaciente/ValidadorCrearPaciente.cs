using FluentValidation;
using System.Security.Cryptography;

namespace SonrisaLimpia.Aplicacion.CasosDeUso.Pacientes.Comandos.CrearPaciente
{
    public class ValidadorCrearPaciente : AbstractValidator<ComandoCrearPaciente>
    {
        public ValidadorCrearPaciente()
        {
            RuleFor(x => x.Nombre)
              .NotEmpty().WithMessage("El campo {PropertyName} es requerido.")
              .MaximumLength(250).WithMessage("El nombre del campo {PropertyName} debe ser menor o igual a {MaxLength}.");

            RuleFor(x => x.Email)
              .NotEmpty().WithMessage("El campo {PropertyName} es requerido.")
              .MaximumLength(254).WithMessage("La longitud del campo {PropertyName} debe ser menor o igual a {MaxLength}.")
              .EmailAddress().WithMessage("El formato del emial no es válido.");
        }
    }
}
