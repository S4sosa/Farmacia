using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;

namespace Lib_Farmacia_Presentacion.implementaciones
{
    public class ComprasPresentacion : IComprasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ComprasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public List<Compras> ConsultarCompras()
        {
            var task = this.IComunicaciones.Ejecutar<List<Compras>>(
                "Compras/ConsultarCompras",
                null!);
            task.Wait();
            return task.Result;
        }

        public Compras InsertarCompra(Compras entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validaciones.ValidarCompras(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Compras>(
                "Compras/InsertarCompra",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Compras ActualizarCompra(Compras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validaciones.ValidarCompras(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Compras>(
                "Compras/ActualizarCompra",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Compras BorrarCompra(Compras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Compras>(
                "Compras/BorrarCompra",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesCompras> ConsultarDetallesCompras()
        {
            var task = this.IComunicaciones.Ejecutar<List<DetallesCompras>>(
                "Compras/ConsultarDetallesCompras",
                null!);
            task.Wait();
            return task.Result;
        }

        public DetallesCompras InsertarDetallesCompra(DetallesCompras entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validaciones.ValidarDetallesCompras(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesCompras>(
                "Compras/InsertarDetallesCompra",
                entidad);
            task.Wait();
            return task.Result;
        }

        public DetallesCompras ActualizarDetallesCompra(DetallesCompras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validaciones.ValidarDetallesCompras(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesCompras>(
                "Compras/ActualizarDetallesCompra",
                entidad);
            task.Wait();
            return task.Result;
        }

        public DetallesCompras BorrarDetallesCompra(DetallesCompras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<DetallesCompras>(
                "Compras/BorrarDetallesCompra",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}
