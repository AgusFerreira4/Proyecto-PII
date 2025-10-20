using System;
using System.Security.AccessControl;

namespace Library;

public class Cliente : Persona
{

    public string Telefono { get; set; }
    public string Genero { get; set; }
    public DateTime FechaDeNacimiento { get; set; }
    public List<string> Etiquetas { get; set; }
    public Usuario UsuarioAsignado { get; set; }
    public GenericContainer<Interaccion> ListaInteraccion { get; set; }

    public Cliente(string telefono, string genero, DateTime fechaDeNacimiento, string nombre, string apellido, string email, Usuario usuarioAsignado, GenericContainer<Interaccion> listaInteraccion): base(nombre, apellido, email)
    {
        Telefono = telefono;
        Genero = genero;
        FechaDeNacimiento = fechaDeNacimiento;
        UsuarioAsignado = usuarioAsignado;
        ListaInteraccion = listaInteraccion;
    }
}