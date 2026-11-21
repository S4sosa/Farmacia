using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Farmacia_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ComprasController : ControllerBase
    {
        private IComprasAplicacion IComprasAplicacion;

        public ComprasController(IComprasAplicacion IComprasAplicacion)
        {
            this.IComprasAplicacion = IComprasAplicacion;
        }


        //-----------------Compras---------------------
        [HttpPost]
        public List<Compras> ConsultarCompras()
        {
            return this.IComprasAplicacion.ConsultarCompras();
        }

        [HttpPost]
        public Compras InsertarCompra(Compras entidad)
        {
            return this.IComprasAplicacion.InsertarCompra(entidad);
        }

        [HttpPost]
        public Compras ActualizarCompra(Compras entidad)
        {
            return this.IComprasAplicacion.ActualizarCompra(entidad);
        }

        [HttpPost]
        public Compras BorrarCompra(Compras entidad)
        {
            return this.IComprasAplicacion.BorrarCompra(entidad);
        }


        //-----------------DetallesCompras---------------------
        [HttpPost]
        public List<DetallesCompras> ConsultarDetallesCompras()
        {
            return this.IComprasAplicacion.ConsultarDetallesCompras();
        }

        [HttpPost]
        public DetallesCompras InsertarDetallesCompra(DetallesCompras entidad)
        {
            return this.IComprasAplicacion.InsertarDetallesCompra(entidad);
        }

        [HttpPost]
        public DetallesCompras ActualizarDetallesCompra(DetallesCompras entidad)
        {
            return this.IComprasAplicacion.ActualizarDetallesCompra(entidad);
        }

        [HttpPost]
        public DetallesCompras BorrarDetallesCompra(DetallesCompras entidad)
        {
            return this.IComprasAplicacion.BorrarDetallesCompra(entidad);
        }

    }
}
