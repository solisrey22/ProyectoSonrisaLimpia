namespace SonrisaLimpia.Aplicacion.Contratos.Persistencia
{
    public interface IUnidadDeTrabajo
    {
        Task Persistir();
        Task Reversar();
    }
}
