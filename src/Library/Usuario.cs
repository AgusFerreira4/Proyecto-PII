
namespace Library;

public class Usuario : Persona
{
    public bool Suspendido { get; set; }
    private GenericContainer<Cliente> ListaClientesDeUsuario { get; set; }
    private GenericContainer<Venta> ListaVentas { get; set; }
    private GenericContainer<Cotizacion> ListaCotizaciones { get; set; }
    private GenericContainer<Interaccion> ListaInteracciones { get; set; }

    public Usuario(bool suspendido, GenericContainer<Cliente> listaClientesDeUsuario,
        GenericContainer<Venta> listaVentas, GenericContainer<Cotizacion> listaCotizaciones, GenericContainer<Interaccion> listaInteracciones, string nombre, string email, string apellido)
        : base(nombre, email, apellido)
    {
        Suspendido = suspendido;
        ListaClientesDeUsuario = listaClientesDeUsuario;
        ListaVentas = listaVentas;
        ListaCotizaciones = listaCotizaciones;
        ListaInteracciones = listaInteracciones;
    }
    public List<Cliente> VerClientes()
    {
        List<Cliente> clientes = new List<Cliente>();
        foreach (Cliente cliente in ListaClientesDeUsuario)
        {
            clientes.Add(cliente);
        }

        return clientes;
    }

    public List<Interaccion> VerInteraccionesCliente(Cliente cliente)
    {
        List<Interaccion> interacciones = new List<Interaccion>();
        foreach (Interaccion i in cliente.ListaInteraccion)
        {
            interacciones.Add(i);
        }
        return interacciones;
    }
    
    public List<Interaccion> VerInteraccionesCliente(Cliente cliente, string tipo)
    {
        List<Interaccion> interacciones = new List<Interaccion>();
        foreach (Interaccion i in cliente.ListaInteraccion)
        {
            if (i.GetType().Name == tipo)
            {
                interacciones.Add(i);
            }
        }
        return interacciones;
    }
    
    public List<Interaccion> VerInteraccionesCliente(Cliente cliente, DateTime fecha)
    {
        List<Interaccion> interacciones = new List<Interaccion>();
        foreach (Interaccion i in cliente.ListaInteraccion)
        {
            if (i.Fecha == fecha)
            {
                interacciones.Add(i);
            }
        }
        return interacciones;
    }

    public List<Interaccion> VerInteraccionesCliente(Cliente cliente, DateTime fecha, string tipo)
    {
        List<Interaccion> interacciones = new List<Interaccion>();
        foreach (Interaccion i in cliente.ListaInteraccion)
        {
            if (i.GetType().Name == tipo && i.Fecha == fecha)
            {
                interacciones.Add(i);
            }
        }
        return interacciones;
    }
    
    public List<Cliente> VerClientesConPocaInteraccion()
    {
        List<Cliente> clientesPocaInteraccion = new List<Cliente>();
        foreach (Cliente cl in ListaClientesDeUsuario)
        {
            if (cl.ListaInteraccion.Count() <= 5)
            {
                clientesPocaInteraccion.Add(cl);
            }
        }

        return clientesPocaInteraccion;
    }


    public List<Cliente> VerClientesEnVisto()
    {
        List<Cliente> clientesVistos = new List<Cliente>();
        foreach (Cliente cl in ListaClientesDeUsuario)
        {
            if (cl.UsuarioAsignado != null) // etiqueta visto
            {
                clientesVistos.Add(cl);
            }
        }

        return clientesVistos;
    }

    public List<Venta> VerVentasPorPeriodo(DateTime fechaini, DateTime fechafin)
    {
        List<Venta> ventasPorFecha = new List<Venta>();
        foreach (Venta v in ListaVentas)
        {
            if (v.Fecha >= fechaini && v.Fecha <= fechafin)
            {
                ventasPorFecha.Add(v);
            }
        }
        return ventasPorFecha;
    }

    public void RegistrarCotizacion(Dictionary<Producto, int> productocantidad, double total, DateTime fecha,
        DateTime fechaLimite,
        Cliente clientecomprador, Usuario usuariovendedor, string descripcion)
    {
        Cotizacion cotizacion = new Cotizacion(total, fecha, fechaLimite, descripcion);
    }
    
    public void RegistrarVenta(Dictionary<Producto, int> productos, double total, DateTime fecha, Cliente cliente,
        Usuario usuario)
    {
        Venta venta = new Venta(productos, total, fecha, cliente, usuario);
        ListaVentas.Add(venta);
    }

    public void AgregarNotaAInteraccion(Interaccion interaccion, string nota)
    {
        foreach (Interaccion i in ListaInteracciones)
        {
            if (i.Equals(interaccion))
            {
                i.Nota = nota;
                break;
            }
        }
    }
}