using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Library;

namespace LibraryTests
{
    [TestClass]
    public class CotizacionTests
    {
        [TestMethod]
        public void Constructor_DeberiaInicializarPropiedades()
        {
            var fecha = DateTime.Now;
            var fechaLimite = fecha.AddDays(5);
            var cot = new Cotizacion(500, fecha, fechaLimite, "Cotizacion prueba");

            Assert.AreEqual(500, cot.Total);
            Assert.AreEqual(fecha, cot.Fecha);
            Assert.AreEqual(fechaLimite, cot.FechaLimite);
            Assert.AreEqual("Cotizacion prueba", cot.Descripcion);
        }
    }
}