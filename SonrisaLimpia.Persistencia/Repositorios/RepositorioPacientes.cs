using SonrisaLimpia.Aplicacion.Contratos.Repositorios;
using SonrisaLimpia.Dominio.Entidades;

namespace SonrisaLimpia.Persistencia.Repositorios
{
    public class RepositorioPacientes : Repositorio<Paciente>, IRepositorioPacientes
    {
        public RepositorioPacientes(SonrisaLimpiaDbContext context) : base(context)
        {
            
        }
    }
}
