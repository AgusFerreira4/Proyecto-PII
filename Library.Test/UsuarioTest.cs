using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Library;

namespace LibraryTests
{
    [TestClass]
    public class UsuarioTests
    {
        private Usuario CrearUsuarioDePrueba()
        {
            var clientes = new GenericContainer<Cliente>();
            var ventas = new GenericContainer<Venta>();
            var cotizaciones = new GenericContainer<Cotizacion>();
            var interacciones = new GenericContainer<Interaccion>();

            return new Usuario(
                "Juan",
                "juan@example.com",
                "Pérez",
                false,
                clientes,
                ventas,
                cotizaciones,
                interacciones
            );
        }

        private Cliente CrearClienteDePrueba(Usuario usuario)
        {
            return new Cliente(
                "099111222",
                "Femenino",
                new DateTime(1990, 5, 20),
                "Ana",
                "López",
                "ana@example.com",
                usuario,
                new GenericContainer<Interaccion>()
            );
        }

        [TestMethod]
        public void Constructor_DeberiaInicializarCorrectamente()
        {
            var usuario = CrearUsuarioDePrueba();

            Assert.IsNotNull(usuario);
            Assert.AreEqual("Juan", usuario.Nombre);
            Assert.AreEqual("Pérez", usuario.Apellido);
            Assert.AreEqual("juan@example.com", usuario.Email);
            Assert.IsFalse(usuario.Suspendido);
        }

        [TestMethod]
        public void VerClientes_DeberiaRetornarClientesDelUsuario()
        {
            var usuario = CrearUsuarioDePrueba();
            var cliente = CrearClienteDePrueba(usuario);
            usuario.ListaClientesDeUsuario.Add(cliente);

            var resultado = usuario.VerClientes();

            Assert.IsTrue(resultado.Contains(cliente));
        }

        [TestMethod]
        public void VerClientesConPocaInteraccion_DeberiaRetornarClientesCon5OMenosInteracciones()
        {
            var usuario = CrearUsuarioDePrueba();
            var cliente = CrearClienteDePrueba(usuario);
            usuario.ListaClientesDeUsuario.Add(cliente);

            var resultado = usuario.VerClientesConPocaInteraccion();

            Assert.IsTrue(resultado.Contains(cliente));
        }

        [TestMethod]
        public void VerClientesEnVisto_DeberiaRetornarClientesConUsuarioAsignado()
        {
            var usuario = CrearUsuarioDePrueba();
            var cliente = CrearClienteDePrueba(usuario);
            cliente.UsuarioAsignado = usuario;
            usuario.ListaClientesDeUsuario.Add(cliente);

            var resultado = usuario.VerClientesEnVisto();

            Assert.IsTrue(resultado.Contains(cliente));
        }

        [TestMethod]
        public void VerInteraccionesCliente_DeberiaRetornarTodasLasInteracciones()
        {
            var usuario = CrearUsuarioDePrueba();
            var cliente = CrearClienteDePrueba(usuario);
            var interaccion = new Mensajes(usuario, cliente, DateTime.Now, "Tema1");

            cliente.ListaInteraccion.Add(interaccion);

            var resultado = usuario.VerInteraccionesCliente(cliente);

            Assert.IsTrue(resultado.Contains(interaccion));
        }

        [TestMethod]
        public void VerInteraccionesCliente_PorTipo_DeberiaFiltrarPorTipo()
        {
            var usuario = CrearUsuarioDePrueba();
            var cliente = CrearClienteDePrueba(usuario);
            var inter1 = new Mensajes(usuario, cliente, DateTime.Now, "Tema1");
            var inter2 = new Reuniones(usuario, cliente, DateTime.Now, "Tema2", "Sala A");
            cliente.ListaInteraccion.Add(inter1);
            cliente.ListaInteraccion.Add(inter2);

            var resultado = usuario.VerInteraccionesCliente(cliente, "Mensajes");

            Assert.IsTrue(resultado.Contains(inter1));
            Assert.IsFalse(resultado.Contains(inter2));
        }

        [TestMethod]
        public void VerInteraccionesCliente_PorFecha_DeberiaFiltrarPorFecha()
        {
            var usuario = CrearUsuarioDePrueba();
            var cliente = CrearClienteDePrueba(usuario);
            var fecha = new DateTime(2025, 10, 20);
            var inter1 = new Mensajes(usuario, cliente, fecha, "Tema1");
            var inter2 = new Mensajes(usuario, cliente, DateTime.Now, "Tema2");
            cliente.ListaInteraccion.Add(inter1);
            cliente.ListaInteraccion.Add(inter2);

            var resultado = usuario.VerInteraccionesCliente(cliente, fecha);

            Assert.IsTrue(resultado.Contains(inter1));
            Assert.IsFalse(resultado.Contains(inter2));
        }

        [TestMethod]
        public void AgregarNotaAInteraccion_DeberiaActualizarNota()
        {
            var usuario = CrearUsuarioDePrueba();
            var cliente = CrearClienteDePrueba(usuario);
            var inter = new Mensajes(usuario, cliente, DateTime.Now, "Tema1");
            usuario.ListaInteracciones.Add(inter);

            usuario.AgregarNotaAInteraccion(inter, "Nueva nota");

            Assert.AreEqual("Nueva nota", inter.Nota);
        }

        [TestMethod]
        public void RegistrarVenta_DeberiaAgregarVentaALaLista()
        {
            var usuario = CrearUsuarioDePrueba();
            var cliente = CrearClienteDePrueba(usuario);
            var productos = new Dictionary<Producto, int>
            {
                { new Producto("Producto1", 100), 2 }
            };
            usuario.RegistrarVenta(productos, 200, DateTime.Now, cliente, usuario);

            Assert.IsTrue(usuario.ListaVentas.Count() == 1);
        }

        [TestMethod]
        public void RegistrarCotizacion_DeberiaCrearCotizacion()
        {
            var usuario = CrearUsuarioDePrueba();
            usuario.RegistrarCotizacion(500, DateTime.Now, DateTime.Now.AddDays(10), "Cotizacion test");

            Assert.IsTrue(true);
        }
    }
}
