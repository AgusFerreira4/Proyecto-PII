using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Library;

namespace LibraryTests
{
    [TestClass]
    public class ReunionesTests
    {
        private Usuario usuario;
        private Cliente cliente;

        [TestInitialize]
        public void Setup()
        {
            usuario = new Usuario(
                "Juan",
                "juan@example.com",
                "Pérez",
                false,
                new GenericContainer<Cliente>(),
                new GenericContainer<Venta>(),
                new GenericContainer<Cotizacion>(),
                new GenericContainer<Interaccion>()
            );

            cliente = new Cliente(
                "099",
                "F",
                DateTime.Now,
                "Ana",
                "López",
                "ana@example.com",
                usuario,
                new GenericContainer<Interaccion>()
            );
        }

        [TestMethod]
        public void Constructor_DeberiaInicializarLugar()
        {
            var reunion = new Reuniones(usuario, cliente, DateTime.Now, "Tema2", "Sala A");

            Assert.AreEqual("Sala A", reunion.Lugar);
            Assert.AreEqual("Tema2", reunion.Tema);
        }
    }
}