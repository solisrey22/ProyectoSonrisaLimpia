using SonrisaLimpia.Aplicacion.Contratos.Persistencia;

namespace SonrisaLimpia.Persistencia.UnidadesDeTrabajo
{
    public class UnidadDeTrabajoEFCore : IUnidadDeTrabajo
    {
        private readonly SonrisaLimpiaDbContext conetext;

        public UnidadDeTrabajoEFCore(SonrisaLimpiaDbContext conetext)
        {
            this.conetext = conetext;
        }

        public async Task Persistir()
        {
            await conetext.SaveChangesAsync();
        }

        public Task Reversar()
        {
           return Task.CompletedTask;
        }
    }
}
