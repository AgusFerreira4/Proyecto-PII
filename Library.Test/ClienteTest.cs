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
            var usuario = new Usuario(
                "Juan",                       // nombre
                "juan@example.com",            // email
                "Pérez",                       // apellido
                false,                         // suspendido
                new GenericContainer<Cliente>(),   // listaClientesDeUsuario
                new GenericContainer<Venta>(),     // listaVentas
                new GenericContainer<Cotizacion>(),// listaCotizaciones
                new GenericContainer<Interaccion>()// listaInteracciones
            );

            var listaInteracciones = new GenericContainer<Interaccion>();

            var cliente = new Cliente(
                "099123456",              // telefono
                "Femenino",               // genero
                new DateTime(1990, 1, 1), // fechaDeNacimiento
                "Ana",                    // nombre
                "López",                  // apellido
                "ana@example.com",        // email
                usuario,                  // usuarioAsignado
                listaInteracciones        // listaInteraccion
            );

            Assert.AreEqual("099123456", cliente.Telefono);
            Assert.AreEqual("Femenino", cliente.Genero);
            Assert.AreEqual(new DateTime(1990, 1, 1), cliente.FechaDeNacimiento);
            Assert.AreEqual("Ana", cliente.Nombre);
        }
    }
}