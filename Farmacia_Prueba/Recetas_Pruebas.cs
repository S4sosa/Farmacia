using Farmacia_libreria.entidades;
using Farmacia_libreria.implementaciones;
using Farmacia_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Farmacia_Pruebas
{
    [TestClass]
    public class Recetas_Pruebas
    {
        private IConexion conexion;
        private Recetas? entidad = null;

        public Recetas_Pruebas()
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
            this.entidad = new Recetas()
            {
                cliente = 1,
                medicoNombre = "Dr. Prueba",
                fechaEmision = DateTime.Now
            };
            this.conexion.Recetas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Recetas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.medicoNombre = "Dr. Actualizado";

            var entry = this.conexion!.Entry<Recetas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Recetas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
