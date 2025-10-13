using SonrisaLimpia.Aplicacion.Contratos.Repositorios;
using SonrisaLimpia.Dominio.Entidades;

namespace SonrisaLimpia.Persistencia.Repositorios
{
    public class RepositorioConsultorio : Repositorio<Consultorio>, IRepositorioConsultorios
    {

        public RepositorioConsultorio(SonrisaLimpiaDbContext context) : base(context)
        {

        }

    }
}
