using SonrisaLimpia.Dominio.Excepciones;
using SonrisaLimpia.Dominio.ObjetosDeValor;

namespace SonrisaLimpia.Dominio.Entidades
{
    public class Paciente
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = null!;
        public Email Email { get; private set; } = null!;

        public Paciente(string nombre, Email email)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ExcepcionReglaNegocio($"El {nameof(nombre)} es un campo obligatorio.");
            }

            if (email is null)
            {
                throw new ExcepcionReglaNegocio($"El {nameof(email)} es un campo obligatorio.");
            }

            Id = Guid.CreateVersion7(); // Genera un nuevo Id automáticamente
            Nombre = nombre;
            Email = email;
        }
    }
}