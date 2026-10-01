using Farmacia_libreria.entidades;
using Farmacia_libreria.implementaciones;
using Farmacia_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Farmacia_Pruebas
{
    [TestClass]
    public class Empleados_Pruebas
    {
        private IConexion conexion;
        private Cargos? cargo = null;
        private Empleados? entidad = null;

        public Empleados_Pruebas()
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
            cargo = new Cargos() { nombre = "Cargo Prueba Secundario" };
            this.conexion.Cargos!.Add(cargo);
            this.conexion.SaveChanges();

            this.entidad = new Empleados()
            {
                persona = 1,
                cargo = 1
            };
            this.conexion.Empleados!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Empleados!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.cargo = this.conexion.Cargos!.OrderByDescending(x => x.Id).First().Id;

            var entry = this.conexion!.Entry<Empleados>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Empleados!.Remove(this.entidad!);
            this.conexion.SaveChanges();

            this.conexion.Cargos!.Remove(cargo);
            this.conexion.SaveChanges();
        }
    }
}
