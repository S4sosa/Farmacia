using Farmacia_libreria.entidades;
using Farmacia_libreria.implementaciones;
using Farmacia_libreria.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Farmacia_Pruebas
{
    [TestClass]
    public class Facturas_Pruebas
    {
        private IConexion conexion;
        private Facturas? entidad = null;

        public Facturas_Pruebas()
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
            var metodoPago = new MetodosPagos() { nombre = "Metodo Prueba Secundario" };
            this.conexion.MetodosPagos!.Add(metodoPago);
            this.conexion.SaveChanges();

            this.entidad = new Facturas()
            {
                venta = 1,
                metodoPago = 1
            };
            this.conexion.Facturas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Facturas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.metodoPago = this.conexion.MetodosPagos!.OrderByDescending(x => x.Id).First().Id;

            var entry = this.conexion!.Entry<Facturas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Facturas!.Remove(this.entidad!);
            this.conexion.SaveChanges();

            var dependencia = this.conexion.MetodosPagos!.FirstOrDefault(x => x.nombre == "Metodo Prueba Secundario");
            if (dependencia != null)
            {
                this.conexion.MetodosPagos!.Remove(dependencia);
                this.conexion.SaveChanges();
            }
        }
    }
}
