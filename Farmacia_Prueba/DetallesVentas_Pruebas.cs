using Farmacia_libreria.entidades;
using Farmacia_libreria.implementaciones;
using Farmacia_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Farmacia_Pruebas
{
    [TestClass]
    public class DetallesVentas_Pruebas
    {
        private IConexion conexion;
        private DetallesVentas? entidad = null;

        public DetallesVentas_Pruebas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = "server=localhost;database=farmacia_db;Integrated Security=True;TrustServerCertificate=true;";
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
            this.entidad = new DetallesVentas()
            {
                venta = 1,
                producto = 1,
                cantidad = 2
            };
            this.conexion.DetallesVentas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.DetallesVentas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.cantidad = 3;

            var entry = this.conexion!.Entry<DetallesVentas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.DetallesVentas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
