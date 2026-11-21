using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Farmacia_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InventarioController : ControllerBase
    {
        private IInventarioAplicacion IInventarioAplicacion;

        public InventarioController(IInventarioAplicacion IInventarioAplicacion)
        {
            this.IInventarioAplicacion = IInventarioAplicacion;
        }


        //-----------------Productos---------------------
        [HttpPost]
        public List<Productos> ConsultarProductos()
        {
            return this.IInventarioAplicacion.ConsultarProductos();
        }

        [HttpPost]
        public List<Productos> BuscarProducto(Productos entidad) //metodo http para buscar los Productos 
        {
            return this.IInventarioAplicacion.BuscarProducto(entidad);
        }

        [HttpPost]
        public Productos InsertarProducto(Productos entidad)
        {
            return this.IInventarioAplicacion.InsertarProducto(entidad);
        }

        [HttpPost]
        public Productos ActualizarProducto(Productos entidad)
        {
            return this.IInventarioAplicacion.ActualizarProducto(entidad);
        }

        [HttpPost]
        public Productos BorrarProducto(Productos entidad)
        {
            return this.IInventarioAplicacion.BorrarProducto(entidad);
        }


        //-----------------Medicamentos---------------------
        [HttpPost]
        public List<Medicamentos> ConsultarMedicamentos()
        {
            return this.IInventarioAplicacion.ConsultarMedicamentos();
        }

        [HttpPost]
        public Medicamentos InsertarMedicamento(Medicamentos entidad)
        {
            return this.IInventarioAplicacion.InsertarMedicamento(entidad);
        }

        [HttpPost]
        public Medicamentos ActualizarMedicamento(Medicamentos entidad)
        {
            return this.IInventarioAplicacion.ActualizarMedicamento(entidad);
        }

        [HttpPost]
        public Medicamentos BorrarMedicamento(Medicamentos entidad)
        {
            return this.IInventarioAplicacion.BorrarMedicamento(entidad);
        }


        //-----------------Lotes---------------------
        [HttpPost]
        public List<Lotes> ConsultarLotes()
        {
            return this.IInventarioAplicacion.ConsultarLotes();
        }

        [HttpPost]
        public Lotes InsertarLote(Lotes entidad)
        {
            return this.IInventarioAplicacion.InsertarLote(entidad);
        }

        [HttpPost]
        public Lotes ActualizarLote(Lotes entidad)
        {
            return this.IInventarioAplicacion.ActualizarLote(entidad);
        }

        [HttpPost]
        public Lotes BorrarLote(Lotes entidad)
        {
            return this.IInventarioAplicacion.BorrarLote(entidad);
        }

        //-----------------Inventarios---------------------
        [HttpPost]
        public List<Inventarios> ConsultarInventarios()
        {
            return this.IInventarioAplicacion.ConsultarInventarios();
        }

        [HttpPost]
        public Inventarios InsertarInventario(Inventarios entidad)
        {
            return this.IInventarioAplicacion.InsertarInventario(entidad);
        }

        [HttpPost]
        public Inventarios ActualizarInventario(Inventarios entidad)
        {
            return this.IInventarioAplicacion.ActualizarInventario(entidad);
        }

        [HttpPost]
        public Inventarios BorrarInventario(Inventarios entidad)
        {
            return this.IInventarioAplicacion.BorrarInventario(entidad);
        }

    }
}