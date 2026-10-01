using Farmacia_libreria.entidades;
using Farmacia_libreria.implementaciones;
using Farmacia_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Farmacia_Pruebas
{
    [TestClass]
    public class Sucursales_Pruebas
    {
        private IConexion conexion;
        private Sucursales? entidad = null;

        public Sucursales_Pruebas()
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
            this.entidad = new Sucursales()
            {
                nombre = "Sucursal Prueba",
                direccion = "Calle Prueba",
                telefono = "6040000000",
                activo = true
            };
            this.conexion.Sucursales!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Sucursales!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.activo = false;

            var entry = this.conexion!.Entry<Sucursales>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Sucursales!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
