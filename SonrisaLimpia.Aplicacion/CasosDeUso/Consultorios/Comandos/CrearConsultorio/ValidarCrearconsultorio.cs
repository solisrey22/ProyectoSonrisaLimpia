using FluentValidation;

namespace SonrisaLimpia.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio
{
    public class ValidarCrearconsultorio : AbstractValidator<ComandoCrearConsultorio>
    {
        public ValidarCrearconsultorio()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El campo {PropertyName} de consultorio es requerido.")
                .MaximumLength(100).WithMessage("El nombre del consultorio no puede exceder los 100 caracteres.");
        }
    }
}
