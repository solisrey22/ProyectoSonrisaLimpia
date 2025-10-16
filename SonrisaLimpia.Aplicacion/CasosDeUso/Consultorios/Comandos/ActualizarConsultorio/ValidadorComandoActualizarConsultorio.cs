using FluentValidation;

namespace SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.ActualizarConsultorio
{
    public class ValidadorComandoActualizarConsultorio : AbstractValidator<ComandoActualizarConsultorio>
    {
        ValidadorComandoActualizarConsultorio()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del campo {PropertyName} es requerido.")
                .MaximumLength(150).WithMessage("El nombre del {PropertyName} debe ser menor o igual a {MaxLength}.");
        }
    }
}
