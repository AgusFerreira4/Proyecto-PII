using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Library;

namespace LibraryTests
{
    [TestClass]
    public class LlamadasTests
    {
        private Usuario usuario;
        private Cliente cliente;

        [TestInitialize]
        public void Setup()
        {
            usuario = new Usuario(false, new GenericContainer<Cliente>(), new GenericContainer<Venta>(), new GenericContainer<Cotizacion>(), new GenericContainer<Interaccion>(), "Juan", "juan@example.com", "Pérez");
            cliente = new Cliente("099", "F", DateTime.Now, "Ana", "López", "ana@example.com", usuario, new GenericContainer<Interaccion>());
        }

        [TestMethod]
        public void Constructor_DeberiaInicializarCorrectamente()
        {
            var llamada = new Llamadas(usuario, cliente, DateTime.Now, "Tema3");

            Assert.AreEqual("Tema3", llamada.Tema);
            Assert.AreEqual(usuario, llamada.Remitente);
            Assert.AreEqual(cliente, llamada.Destinatario);
        }
    }
}