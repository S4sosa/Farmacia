using Farmacia_libreria.entidades;
using Farmacia_libreria.implementaciones;
using Farmacia_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Farmacia_Pruebas
{
    [TestClass]
    public class Lotes_Pruebas
    {
        private IConexion conexion;
        private Lotes? entidad = null;

        public Lotes_Pruebas()
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
            this.entidad = new Lotes()
            {
                producto = 1,
                numLote = "L-PRUEBA",
                fechaVencimiento = DateTime.Now.AddYears(2)
            };
            this.conexion.Lotes!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Lotes!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.numLote = "L-ACTUALIZADO";

            var entry = this.conexion!.Entry<Lotes>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Lotes!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
