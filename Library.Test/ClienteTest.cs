using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Library;

namespace LibraryTests
{
    [TestClass]
    public class ClienteTests
    {
        [TestMethod]
        public void Constructor_DeberiaInicializarPropiedades()
        {
            var usuario = new Usuario(false, new GenericContainer<Cliente>(), new GenericContainer<Venta>(), new GenericContainer<Cotizacion>(), new GenericContainer<Interaccion>(), "Juan", "juan@example.com", "Pérez");
            var listaInteracciones = new GenericContainer<Interaccion>();
            var cliente = new Cliente("099123456", "Femenino", new DateTime(1990,1,1), "Ana", "López", "ana@example.com", usuario, listaInteracciones);

            Assert.AreEqual("099123456", cliente.Telefono);
            Assert.AreEqual("Femenino", cliente.Genero);
            Assert.AreEqual(new DateTime(1990,1,1), cliente.FechaDeNacimiento);
            Assert.AreEqual("Ana", cliente.Nombre);
        }
    }
}