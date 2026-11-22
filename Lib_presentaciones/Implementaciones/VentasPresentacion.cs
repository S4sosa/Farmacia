using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;

namespace Lib_Farmacia_Presentacion.implementaciones
{
    public class VentasPresentacion : IVentasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public VentasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public List<Ventas> ConsultarVentas()
        {
            var task = this.IComunicaciones.Ejecutar<List<Ventas>>(
                "Ventas/ConsultarVentas",
                null!);
            task.Wait();
            return task.Result;
        }

        public Ventas InsertarVenta(Ventas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validaciones.ValidarVentas(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Ventas>(
                "Ventas/InsertarVenta",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Ventas ActualizarVenta(Ventas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validaciones.ValidarVentas(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Ventas>(
                "Ventas/ActualizarVenta",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Ventas BorrarVenta(Ventas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Ventas>(
                "Ventas/BorrarVenta",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesVentas> ConsultarDetallesVentas()
        {
            var task = this.IComunicaciones.Ejecutar<List<DetallesVentas>>(
                "Ventas/ConsultarDetallesVentas",
                null!);
            task.Wait();
            return task.Result;
        }

        public DetallesVentas InsertarDetallesVenta(DetallesVentas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validaciones.ValidarDetallesVentas(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesVentas>(
                "Ventas/InsertarDetallesVenta",
                entidad);
            task.Wait();
            return task.Result;
        }

        public DetallesVentas ActualizarDetallesVenta(DetallesVentas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validaciones.ValidarDetallesVentas(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesVentas>(
                "Ventas/ActualizarDetallesVenta",
                entidad);
            task.Wait();
            return task.Result;
        }

        public DetallesVentas BorrarDetallesVenta(DetallesVentas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<DetallesVentas>(
                "Ventas/BorrarDetallesVenta",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Facturas> ConsultarFacturas()
        {
            var task = this.IComunicaciones.Ejecutar<List<Facturas>>(
                "Ventas/ConsultarFacturas",
                null!);
            task.Wait();
            return task.Result;
        }

        public Facturas InsertarFactura(Facturas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validaciones.ValidarFacturas(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Facturas>(
                "Ventas/InsertarFactura",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Facturas ActualizarFactura(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validaciones.ValidarFacturas(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Facturas>(
                "Ventas/ActualizarFactura",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Facturas BorrarFactura(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Facturas>(
                "Ventas/BorrarFactura",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}

