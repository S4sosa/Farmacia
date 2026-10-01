using Farmacia_libreria.entidades;
using Farmacia_libreria.implementaciones;
using Farmacia_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Farmacia_Pruebas
{
    [TestClass]
    public class Medicamentos_Pruebas
    {
        private IConexion conexion;
        private Medicamentos? entidad = null;
        private Presentaciones? Presentacion = null;

        public Medicamentos_Pruebas()
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
            Presentacion = new Presentaciones() { nombre = "Presentacion Prueba Secundaria" };
            this.conexion.Presentaciones!.Add(Presentacion);
            this.conexion.SaveChanges();

            this.entidad = new Medicamentos()
            {
                producto = 1,
                presentacion = 1
            };
            this.conexion.Medicamentos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Medicamentos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.presentacion = this.conexion.Presentaciones!.OrderByDescending(x => x.Id).First().Id;

            var entry = this.conexion!.Entry<Medicamentos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Medicamentos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
           
            this.conexion.Presentaciones!.Remove(Presentacion);
            this.conexion.SaveChanges();
            
        }
    }
}
