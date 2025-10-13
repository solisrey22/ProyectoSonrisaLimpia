using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonrisaLimpia.Dominio.Entidades;

namespace SonrisaLimpia.Persistencia.Configuraciones
{
    public class ConsultorioConfig : IEntityTypeConfiguration<Consultorio>
    {
        public void Configure(EntityTypeBuilder<Consultorio> builder)
        {
            builder.Property(prop => prop.Nombre)
                   .IsRequired()
                   .HasMaxLength(150);
        }
    }
}
