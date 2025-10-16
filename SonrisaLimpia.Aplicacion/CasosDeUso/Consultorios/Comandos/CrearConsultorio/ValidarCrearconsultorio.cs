using FluentValidation;

namespace SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio
{
    public class ValidarCrearconsultorio : AbstractValidator<ComandoCrearConsultorio>
    {
        public ValidarCrearconsultorio()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El campo {PropertyName} es requerido.")
                .MaximumLength(150).WithMessage("El nombre del campo {PropertyName} debe ser menor o igual a {MaxLength}.");
        }
    }
}
