using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Library;

namespace LibraryTests
{
    [TestClass]
    public class MensajesTests
    {
        private Usuario usuario;
        private Cliente cliente;

        [TestInitialize]
        public void Setup()
        {
            usuario = new Usuario("Juan", "juan@example.com", "Pérez", false, new GenericContainer<Cliente>(), new GenericContainer<Venta>(), new GenericContainer<Cotizacion>(), new GenericContainer<Interaccion>());
            cliente = new Cliente("099", "F", DateTime.Now, "Ana", "López", "ana@example.com", usuario, new GenericContainer<Interaccion>());
        }

        [TestMethod]
        public void Constructor_DeberiaInicializarPropiedades()
        {
            var msg = new Mensajes(usuario, cliente, DateTime.Now, "Tema1");

            Assert.AreEqual(usuario, msg.Remitente);
            Assert.AreEqual(cliente, msg.Destinatario);
            Assert.AreEqual("Tema1", msg.Tema);
        }

        [TestMethod]
        public void Enviar_NoLanzaExcepcion()
        {
            var msg = new Mensajes(usuario, cliente, DateTime.Now, "Tema1");
            msg.Enviar(); // Verifica que no explote

            Assert.IsTrue(true);
        }
    }
}