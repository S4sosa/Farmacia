using Farmacia_libreria.implementaciones;
using Farmacia_libreria.interfaces;

namespace Farmacia_Pruebas
{
    [TestClass]
    public class Cargos_Pruebas
    {
        [TestMethod]
        public void Execute()
        {
            Listar();
        }

        public void Listar()
        {
            IConexion conexion = new Conexion();
            conexion.StringConexion = "server=(localdb)\\MSSQLLocalDB;database=farmacia_db;Integrated Security=True;TrustServerCertificate=true;";
            /*
            Para localhost
            conexion.StringConexion = "server=localhost;database=farmacia_db;Integrated Security=True;TrustServerCertificate=true;";
            */
            var lista_cargos = conexion.Cargos!.ToList();
            if (lista_cargos.Count <= 0)
                throw new Exception("Lista vacia");
        }

    }
}