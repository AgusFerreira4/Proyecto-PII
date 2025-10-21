using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;

namespace LibraryTests
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Constructor_DeberiaInicializarPropiedadesCorrectamente()
        {
            // Arrange
            string nombre = "Juan";
            string apellido = "Pérez";
            string email = "juan@example.com";

            // Act
            Admin admin = new Admin(nombre, apellido, email);

            // Assert
            Assert.AreEqual(nombre, admin.Nombre);
            Assert.AreEqual(apellido, admin.Apellido);
            Assert.AreEqual(email, admin.Email);
        }

        [TestMethod]
        public void Propiedades_DeberianSerEditables()
        {
            // Arrange
            Admin admin = new Admin("Juan", "Pérez", "juan@example.com");

            // Act
            admin.Nombre = "Carlos";
            admin.Apellido = "Gómez";
            admin.Email = "carlos@example.com";

            // Assert
            Assert.AreEqual("Carlos", admin.Nombre);
            Assert.AreEqual("Gómez", admin.Apellido);
            Assert.AreEqual("carlos@example.com", admin.Email);
        }

        [TestMethod]
        public void Admin_DeberiaSerSubclaseDePersona()
        {
            // Arrange & Act
            Admin admin = new Admin("Ana", "López", "ana@example.com");

            // Assert
            Assert.IsInstanceOfType(admin, typeof(Persona));
        }
    }
}