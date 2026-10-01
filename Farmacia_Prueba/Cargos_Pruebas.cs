using Farmacia_libreria.entidades;
using Farmacia_libreria.implementaciones;
using Farmacia_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Farmacia_Pruebas
{
    [TestClass]
    public class Cargos_Pruebas
    {
        private IConexion conexion;
        private Cargos? entidad = null;

        public Cargos_Pruebas()
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
            this.entidad = new Cargos()
            {
                nombre = "Farmaceutico Prueba"
            };
            this.conexion.Cargos!.Add(this.entidad!);
            ((DbContext)this.conexion!).SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Cargos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.nombre = "Farmaceutico Actualizado";

            var entry = this.conexion!.Entry<Cargos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Cargos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}