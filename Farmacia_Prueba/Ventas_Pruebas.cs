using Farmacia_libreria.entidades;
using Farmacia_libreria.implementaciones;
using Farmacia_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Farmacia_Pruebas
{
    [TestClass]
    public class Ventas_Pruebas
    {
        private IConexion conexion;
        private Ventas? entidad = null;

        public Ventas_Pruebas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = "server=(localdb)\\MSSQLLocalDB;database=farmacia_db;Integrated Security=True;TrustServerCertificate=true;";
        }

        [TestMethod]
        public void Execute()
        {
            Insertar();
            Consultar();
            Actualizar();
            Borrar();
        }

        public void Insertar()
        {
            this.entidad = new Ventas()
            {
                cliente = 1,
                fecha = DateTime.Now,
                total = 10000
            };
            this.conexion.Ventas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Ventas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.total = 12000;

            var entry = this.conexion!.Entry<Ventas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Ventas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
