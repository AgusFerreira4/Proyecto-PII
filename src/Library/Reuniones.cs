using System;

namespace Library;

public class Reuniones : Interaccion
{
    public string Lugar { get; set; }
    
    public Reuniones(Persona remitente, Persona destinatario, DateTime fecha, string tema, string lugar) : base(remitente, destinatario,
        fecha, tema)
    {
        Lugar = lugar;
    }
    
}