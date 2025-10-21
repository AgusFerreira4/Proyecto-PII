using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Library;

namespace LibraryTests
{
    [TestClass]
    public class InteraccionTests
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
        public void AddNota_DeberiaActualizarNota()
        {
            var interaccion = new Mensajes(usuario, cliente, DateTime.Now, "Tema1");
            interaccion.AddNota("Nota importante");

            Assert.AreEqual("Nota importante", interaccion.Nota);
        }
    }
}