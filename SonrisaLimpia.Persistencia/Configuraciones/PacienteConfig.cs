using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonrisaLimpia.Dominio.Entidades;

namespace SonrisaLimpia.Persistencia.Configuraciones
{
    public class PacienteConfig : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
           builder.Property(prop => prop.Nombre)
                  .IsRequired()
                  .HasMaxLength(250);

            builder.ComplexProperty(prop => prop.Email, accion =>
            {
                accion.Property(e => e.Valor) // Mapeo Especial para el Value Object Email
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(254); 
            });
               
        }
    }
}
