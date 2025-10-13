using SonrisaLimpia.Dominio.Excepciones;

namespace SonrisaLimpia.Dominio.ObjetosDeValor
{
    public record Email
    {
        public string Valor { get; } = null!;
        public Email(string email) 
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ExcepcionReglaNegocio($"El {nameof(email)} no puede estar vacío.");
            }
            if (!email.Contains("@"))
            {
                throw new ExcepcionReglaNegocio($"El {nameof(email)} no es válido.");
            }

            Valor = email;
        }
    }
}
