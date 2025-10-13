using FluentValidation;
using NSubstitute;
using SonrisaLimpia.Aplicacion.Excepciones;
using SonrisaLimpia.Aplicacion.Utilidades.Mediador;

namespace SonrisaLimpia.Pruebas.Aplicacion.Utilidades.Mediador
{
    [TestClass]
    public class MediadorSimpleTests
    {
        public class RequestFalso : IRequest<string>
        {
            public required string Nombre { get; set; }
        }
        public class HandlerFalso : IRequestHandler<RequestFalso, string>
        {
            public Task<string> Handle(RequestFalso request)
            {
                return Task.FromResult("Respuesta de prueba");
            }
        }

        public class ValidadorRequestFalso : AbstractValidator<RequestFalso>
        {
            public ValidadorRequestFalso()
            {
                RuleFor(x => x.Nombre).NotEmpty();
            }
        }

        [TestMethod]
        public async Task Enviar_LlamaMetodoHandler()
        {
            var request = new RequestFalso() { Nombre = "El nombre no es vacío"};

            var casoDeUsoMock = Substitute.For<IRequestHandler<RequestFalso, string>>();

            var serviceProviderMock = Substitute.For<IServiceProvider>();

            serviceProviderMock.GetService(typeof(IRequestHandler<RequestFalso, string>))
                .Returns(casoDeUsoMock);

            var mediador = new MediadorSimple(serviceProviderMock);
            var resultado= await mediador.Send(request);
            await casoDeUsoMock.Received(1).Handle(request);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDeMediador))]
        public async Task Enviar_SinMetodoHandler_LanzaExcepción()
        {
            var request = new RequestFalso() { Nombre = "El nombre no es vacío" };

            var casoDeUsoMock = Substitute.For<IRequestHandler<RequestFalso, string>>();

            var serviceProviderMock = Substitute.For<IServiceProvider>();

            var mediador = new MediadorSimple(serviceProviderMock);
            var resultado = await mediador.Send(request);
           
        }

        [TestMethod]
        public async Task Enviar_ComandoNoValido_LanzaExcepcion()
        {
            var request = new RequestFalso { Nombre = "" };
            var serviceProvider = Substitute.For<IServiceProvider>();
            var validador = new ValidadorRequestFalso();

            serviceProvider
                .GetService(typeof(IValidator<RequestFalso>))
                .Returns(validador);

            var mediador = new MediadorSimple(serviceProvider);

            await Assert.ThrowsExceptionAsync<ExcepcionDeValidacion>(async () =>
            {
                await mediador.Send(request);
            });
        }


    }
}
