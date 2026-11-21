using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Farmacia_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VentasController : ControllerBase
    {
        private IVentasAplicacion IVentasAplicacion;

        public VentasController(IVentasAplicacion IVentasAplicacion)
        {
            this.IVentasAplicacion = IVentasAplicacion;
        }


        //-----------------Ventas---------------------
        [HttpPost]
        public List<Ventas> ConsultarVentas()
        {
            return this.IVentasAplicacion.ConsultarVentas();
        }

        [HttpPost]
        public Ventas InsertarVenta(Ventas entidad)
        {
            return this.IVentasAplicacion.InsertarVenta(entidad);
        }

        [HttpPost]
        public Ventas ActualizarVenta(Ventas entidad)
        {
            return this.IVentasAplicacion.ActualizarVenta(entidad);
        }

        [HttpPost]
        public Ventas BorrarVenta(Ventas entidad)
        {
            return this.IVentasAplicacion.BorrarVenta(entidad);
        }


        //-----------------DetallesVentas---------------------
        [HttpPost]
        public List<DetallesVentas> ConsultarDetallesVentas()
        {
            return this.IVentasAplicacion.ConsultarDetallesVentas();
        }

        [HttpPost]
        public DetallesVentas InsertarDetallesVenta(DetallesVentas entidad)
        {
            return this.IVentasAplicacion.InsertarDetallesVenta(entidad);
        }

        [HttpPost]
        public DetallesVentas ActualizarDetallesVenta(DetallesVentas entidad)
        {
            return this.IVentasAplicacion.ActualizarDetallesVenta(entidad);
        }

        [HttpPost]
        public DetallesVentas BorrarDetallesVenta(DetallesVentas entidad)
        {
            return this.IVentasAplicacion.BorrarDetallesVenta(entidad);
        }


        //-----------------Facturas---------------------
        [HttpPost]
        public List<Facturas> ConsultarFacturas()
        {
            return this.IVentasAplicacion.ConsultarFacturas();
        }

        [HttpPost]
        public Facturas InsertarFactura(Facturas entidad)
        {
            return this.IVentasAplicacion.InsertarFactura(entidad);
        }

        [HttpPost]
        public Facturas ActualizarFactura(Facturas entidad)
        {
            return this.IVentasAplicacion.ActualizarFactura(entidad);
        }

        [HttpPost]
        public Facturas BorrarFactura(Facturas entidad)
        {
            return this.IVentasAplicacion.BorrarFactura(entidad);
        }

    }
}
