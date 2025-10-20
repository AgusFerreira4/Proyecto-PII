using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Library;

namespace LibraryTests
{
    [TestClass]
    public class GenericContainerTests
    {
        [TestMethod]
        public void Add_DeberiaAgregarElemento()
        {
            // Arrange
            var container = new GenericContainer<int>();

            // Act
            container.Add(42);

            // Assert
            Assert.AreEqual(1, container.Count());
        }

        [TestMethod]
        public void GetEnumerator_DeberiaPermitirIterarElementos()
        {
            // Arrange
            var container = new GenericContainer<string>();
            container.Add("uno");
            container.Add("dos");

            // Act
            var elementos = new List<string>();
            foreach (var e in container)
            {
                elementos.Add(e.ToString());
            }

            // Assert
            CollectionAssert.AreEqual(new List<string> { "uno", "dos" }, elementos);
        }

        [TestMethod]
        public void Count_DeberiaRetornarCantidadCorrecta()
        {
            // Arrange
            var container = new GenericContainer<int>();
            container.Add(1);
            container.Add(2);
            container.Add(3);

            // Act
            var count = container.Count();

            // Assert
            Assert.AreEqual(3, count);
        }
    }
}