using Farmacia_libreria.entidades;
using Farmacia_libreria.implementaciones;
using Farmacia_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Farmacia_Pruebas
{
    [TestClass]
    public class Usuarios_Pruebas
    {
        private IConexion conexion;
        private Usuarios? entidad = null;
        private Roles? rol = null;

        public Usuarios_Pruebas()
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
            rol = new Roles() { nombre = "Rol Prueba Secundario"};
            this.conexion.Roles!.Add(rol);
            this.conexion.SaveChanges();

            this.entidad = new Usuarios()
            {
                nombre = "Usuario Prueba",
                correo = "prueba@farmacia.com",
                contrasena = "Prueba.123",
                rol = this.conexion.Roles!.OrderByDescending(x => x.Id).First().Id
            };
            this.conexion.Usuarios!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Usuarios!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.correo = "actualizado@farmacia.com";

            var entry = this.conexion!.Entry<Usuarios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Usuarios!.Remove(this.entidad!);
            this.conexion.SaveChanges();

            this.conexion.Roles!.Remove(rol!);
            this.conexion.SaveChanges();
        }
    }
}