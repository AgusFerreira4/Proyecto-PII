using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Library;

namespace LibraryTests
{
    [TestClass]
    public class VentaTests
    {
        [TestMethod]
        public void Constructor_DeberiaInicializarPropiedades()
        {
            var cliente = new Cliente("099", "F", DateTime.Now, "Ana", "López", "ana@example.com", null, new GenericContainer<Interaccion>());
            var usuario = new Usuario(false, new GenericContainer<Cliente>(), new GenericContainer<Venta>(), new GenericContainer<Cotizacion>(), new GenericContainer<Interaccion>(), "Juan", "juan@example.com", "Pérez");
            var productos = new Dictionary<Producto,int>();
            var venta = new Venta(productos, 1000, DateTime.Now, cliente, usuario);

            Assert.AreEqual(1000, venta.Total);
            Assert.AreEqual(cliente, venta.ClienteComprador);
            Assert.AreEqual(usuario, venta.UsuarioVendedor);
            Assert.AreEqual(productos, venta.ProductosCantidad);
        }

        [TestMethod]
        public void AgregarProducto_DeberiaAñadirProducto()
        {
            var venta = new Venta(new Dictionary<Producto,int>(), 0, DateTime.Now, null, null);
            var prod = new Producto("Mouse", 50);

            venta.AgregarProducto(prod, 2);

            Assert.IsTrue(venta.ProductosCantidad.ContainsKey(prod));
            Assert.AreEqual(2, venta.ProductosCantidad[prod]);
        }
    }
}