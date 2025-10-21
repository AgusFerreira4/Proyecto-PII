using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Library;

namespace LibraryTests
{
    [TestClass]
    public class EmailsTests
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
            var email = new Emails(usuario, cliente, DateTime.Now, "Tema4");

            Assert.AreEqual("Tema4", email.Tema);
            Assert.AreEqual(usuario, email.Remitente);
            Assert.AreEqual(cliente, email.Destinatario);
        }

        [TestMethod]
        public void Enviar_NoLanzaExcepcion()
        {
            var email = new Emails(usuario, cliente, DateTime.Now, "Tema4");
            email.Enviar();

            Assert.IsTrue(true);
        }
    }
}