using System.Security.AccessControl;

namespace Library;

public class Cliente : Persona
{

    public string Telefono { get; set; }
    public string Genero { get; set; }
    public string FechaDeNacimiento { get; set; }
    public List<string> Etiquetas { get; set; }
    public Usuario UsuarioAsignado { get; set; }
    private GenericContainer<Interaccion> ListaInteraccion { get; set; }

    public Cliente(string telefono, string genero, string fechaDeNacimiento, string nombre, string apellido, string email): base(nombre, apellido, email)
    {
        Telefono = telefono;
        Genero = genero;
        FechaDeNacimiento = fechaDeNacimiento;
    }
}