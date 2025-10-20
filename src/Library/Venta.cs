using System.Collections.Generic;

namespace Library;

public class Venta
{
   public Dictionary<Producto, int> ProductosCantidad { get; set; }
   public double Total { get; set; }
   public string Fecha { get; set; }
   public Cliente ClienteComprador { get; set; }
   public Usuario UsuarioVendedor { get; set; }

   public void AgregarProducto(Producto producto, int cantidad)
   {
      ProductosCantidad.Add(producto, cantidad);
   }
}