using Microsoft.EntityFrameworkCore;
using SonrisaLimpia.Dominio.Entidades;

namespace SonrisaLimpia.Persistencia
{
    public class SonrisaLimpiaDbContext : DbContext
    {
        public SonrisaLimpiaDbContext(DbContextOptions <SonrisaLimpiaDbContext>options) : base(options)
        {
        }

        protected SonrisaLimpiaDbContext()
        {
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SonrisaLimpiaDbContext).Assembly);

        }

        public DbSet<Consultorio> Consultorios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
    }
}
