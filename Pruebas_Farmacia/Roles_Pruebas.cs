using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.implementaciones;
using Lib_Farmacia_Aplicacion.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Farmacia_Pruebas
{
    [TestClass]
    public class Roles_Pruebas
    {
        private IConexion conexion;
        private Roles? entidad = null;

        public Roles_Pruebas()
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
            this.entidad = new Roles()
            {
                nombre = "Rol Prueba"
            };
            this.conexion.Roles!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Roles!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.nombre = "Rol Prueba Actualizado";

            var entry = this.conexion!.Entry<Roles>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Roles!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}