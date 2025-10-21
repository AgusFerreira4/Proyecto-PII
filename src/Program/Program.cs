using Library;

DateTime date = DateTime.Today;

Usuario user1 = new Usuario("gas", "tongas14@gmail.com", "gardil", false);
Cliente cliente1 = new Cliente("099734655", "Masculino", date, "Nacho",
    "rodriguez", "nacho123@gmail.com", user1);

Emails email1 = new Emails(cliente1, user1, date, "quiero comprar 2 sopas");
email1.Enviar();
GenericContainer<Interaccion> interacciones = new GenericContainer<Interaccion>();
interacciones.Add(email1);
cliente1.ListaInteraccion = interacciones;
user1.ListaInteracciones = interacciones;
user1.ListaClientesDeUsuario.Add(cliente1);
Producto sopa = new Producto("sopa de pollo", 30);
user1.RegistrarVenta(new Dictionary<Producto, int> { { sopa, 2 } }, 60, date, cliente1, user1);
//todo ver de borrar total pq ya tenes cantidad y precio

//todo agregar verificacion de datos, tendriamos q hacer una clase generica q se encargue para td


