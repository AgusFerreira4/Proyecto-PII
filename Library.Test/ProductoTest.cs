using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;

namespace LibraryTests
{
    [TestClass]
    public class ProductoTests
    {
        [TestMethod]
        public void Constructor_DeberiaInicializarPropiedades()
        {
            var producto = new Producto("Laptop", 1500);

            Assert.AreEqual("Laptop", producto.Nombre);
            Assert.AreEqual(1500, producto.Precio);
        }

        [TestMethod]
        public void Propiedades_DeberianSerEditables()
        {
            var producto = new Producto("Laptop", 1500);
            producto.Nombre = "Tablet";
            producto.Precio = 1200;

            Assert.AreEqual("Tablet", producto.Nombre);
            Assert.AreEqual(1200, producto.Precio);
        }
    }
}