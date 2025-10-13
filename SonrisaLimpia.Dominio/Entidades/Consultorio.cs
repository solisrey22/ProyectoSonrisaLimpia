using SonrisaLimpia.Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonrisaLimpia.Dominio.Entidades
{
    public class Consultorio
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = null!;

        public Consultorio(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ExcepcionReglaNegocio($"El {nameof(nombre)} no puede estar vacío.");

            Id = Guid.CreateVersion7(); // Genera un nuevo Id automáticamente
            Nombre = nombre;
        }
    }
}
