
namespace Library;

public class Cotizacion
{
    public double Total { get; set; }
    public DateTime Fecha { get; set; }
    public DateTime FechaLimite { get; set; }
    public string Descripcion { get; set; }

    public Cotizacion(double total, DateTime fecha, DateTime fechaLimite, string descripcion)
    {
        Total = total;
        Fecha = fecha;
        FechaLimite = fechaLimite;
        Descripcion = descripcion;
    }
}