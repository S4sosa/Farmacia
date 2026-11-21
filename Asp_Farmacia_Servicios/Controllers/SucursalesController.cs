using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Farmacia_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SucursalesController : ControllerBase
    {
        private ISucursalesAplicacion ISucursalesAplicacion;

        public SucursalesController(ISucursalesAplicacion ISucursalesAplicacion)
        {
            this.ISucursalesAplicacion = ISucursalesAplicacion;
        }


        //-----------------Sucursales---------------------
        [HttpPost]
        public List<Sucursales> ConsultarSucursales()
        {
            return this.ISucursalesAplicacion.ConsultarSucursales();
        }

        [HttpPost]
        public Sucursales InsertarSucursal(Sucursales entidad)
        {
            return this.ISucursalesAplicacion.InsertarSucursal(entidad);
        }

        [HttpPost]
        public Sucursales ActualizarSucursal(Sucursales entidad)
        {
            return this.ISucursalesAplicacion.ActualizarSucursal(entidad);
        }

        [HttpPost]
        public Sucursales BorrarSucursal(Sucursales entidad)
        {
            return this.ISucursalesAplicacion.BorrarSucursal(entidad);
        }

    }
}
