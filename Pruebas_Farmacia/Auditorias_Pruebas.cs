using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.implementaciones;
using Lib_Farmacia_Aplicacion.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Farmacia_Pruebas
{
    [TestClass]
    public class Auditorias_Pruebas
    {
        private IConexion conexion;
        private Auditorias? entidad = null;

        public Auditorias_Pruebas()
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
            this.entidad = new Auditorias()
            {
                correo = "prueba@farmacia.com",
                fecha = DateTime.Now,
                exitoso = false
            };
            this.conexion.Auditorias!.Add(this.entidad!);
            ((DbContext)this.conexion!).SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Auditorias!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.correo = "pruebaActualizada@farmacia.com";

            var entry = this.conexion!.Entry<Auditorias>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Auditorias!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}