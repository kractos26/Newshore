namespace Api.ViewModels
{
    public class Response<T>
    {
       string Mensaje = string.Empty;
       T Entidad { get; set; }
       
    }
}
