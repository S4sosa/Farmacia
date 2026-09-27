using Farmacia_libreria.entidades;
using Farmacia_libreria.implementaciones;
using Farmacia_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Farmacia_Pruebas
{
    [TestClass]
    public class DetallesRecetas_Pruebas
    {
        private IConexion conexion;
        private DetallesRecetas? entidad = null;

        public DetallesRecetas_Pruebas()
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
            this.entidad = new DetallesRecetas()
            {
                receta = 1,
                medicamento = 1,
                cantidad = 2
            };
            this.conexion.DetallesRecetas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.DetallesRecetas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.cantidad = 3;

            var entry = this.conexion!.Entry<DetallesRecetas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.DetallesRecetas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
