using SonrisaLimpia.Dominio.Excepciones;
using SonrisaLimpia.Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonrisaLimpia.Dominio.Entidades
{
   public class Dentista
   {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = null!;
        public Email Email { get; private set; } = null!;

        private Dentista()
        {

        }

        public Dentista(string nombre, Email email)
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
