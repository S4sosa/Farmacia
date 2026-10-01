using Farmacia_libreria.entidades;
using Farmacia_libreria.implementaciones;
using Farmacia_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Farmacia_Pruebas
{
    [TestClass]
    public class DetallesCompras_Pruebas
    {
        private IConexion conexion;
        private DetallesCompras? entidad = null;

        public DetallesCompras_Pruebas()
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
            this.entidad = new DetallesCompras()
            {
                compra = 1,
                producto = 1,
                cantidad = 10,
                precio = 2000
            };
            this.conexion.DetallesCompras!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.DetallesCompras!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.cantidad = 20;

            var entry = this.conexion!.Entry<DetallesCompras>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.DetallesCompras!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
