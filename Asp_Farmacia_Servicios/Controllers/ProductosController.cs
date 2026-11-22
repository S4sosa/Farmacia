using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Farmacia_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductosController : ControllerBase
    {
        private IProductosAplicacion IProductosAplicacion;

        public ProductosController(IProductosAplicacion IProductosAplicacion)
        {
            this.IProductosAplicacion = IProductosAplicacion;
        }

        [HttpPost]
        public List<Productos> ConsultarProductos()
        {
            return this.IProductosAplicacion.ConsultarProductos();
        }

        [HttpPost]
        public List<Productos> BuscarProducto([FromBody] string nombre)
        {
            return this.IProductosAplicacion.BuscarProducto(nombre);
        }

    }
}
