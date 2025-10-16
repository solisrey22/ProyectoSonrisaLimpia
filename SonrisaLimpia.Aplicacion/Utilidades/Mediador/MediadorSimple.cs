using FluentValidation;
using FluentValidation.Results;
using SonrisaLimpia.Aplicacion.Excepciones;

namespace SonrisaLimpia.Aplicacion.Utilidades.Mediador
{
    public class MediadorSimple : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public MediadorSimple(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            await RealizarValidaciones(request);

            var tipoCasoDeUso = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

            var manejador = _serviceProvider.GetService(tipoCasoDeUso);

            if (manejador is null)
            {
                throw new ExcepcionDeMediador($"No se encontró un manejador para la solicitud de tipo {request.GetType().Name}");
            }

            var metodo = tipoCasoDeUso.GetMethod("Handle");
            return await (Task<TResponse>)metodo.Invoke(manejador, [request]);
        }

        public async Task Send(IRequest request)
        {
            await RealizarValidaciones(request);

            var tipoCasoDeUso = typeof(IRequestHandler<>).MakeGenericType(request.GetType());
            var casoDeUso = _serviceProvider.GetService(tipoCasoDeUso);

            if (casoDeUso is null)
            {
                throw new ExcepcionDeMediador($"No se encontró un manejador para la solicitud de tipo {request.GetType().Name}");
            }

            var metodo = tipoCasoDeUso.GetMethod("Handle");
            await (Task)metodo.Invoke(casoDeUso, [request]);
        }

        private async Task RealizarValidaciones(object request)
        {
            var tipoValidador = typeof(IValidator<>).MakeGenericType(request.GetType());

            var validador = _serviceProvider.GetService(tipoValidador);

            if (validador is not null)
            {
                var metodoValidar = tipoValidador.GetMethod("ValidateAsync");
                var tareaValidar = (Task)metodoValidar!.Invoke(validador,
                    [request, CancellationToken.None])!;

                await tareaValidar.ConfigureAwait(false);

                var resultado = tareaValidar.GetType().GetProperty("Result");
                var validationResult = (ValidationResult)resultado!.GetValue(tareaValidar)!;

                if (!validationResult.IsValid)
                {
                    throw new ExcepcionDeValidacion(validationResult);
                }
            }

        }
    }
}
