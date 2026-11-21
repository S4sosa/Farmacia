using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Farmacia_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientesController : ControllerBase
    {
        private IClientesAplicacion IClientesAplicacion;

        public ClientesController(IClientesAplicacion IClientesAplicacion)
        {
            this.IClientesAplicacion = IClientesAplicacion;
        }


        //-----------------Clientes---------------------
        [HttpPost]
        public List<Clientes> ConsultarClientes()
        {
            return this.IClientesAplicacion.ConsultarClientes();
        }

        [HttpPost]
        public List<Clientes> BuscarCliente(Clientes entidad) //metodo http ppara buscar clientes 
        {
            return this.IClientesAplicacion.BuscarCliente(entidad);
        }

        [HttpPost]
        public Clientes InsertarCliente(Clientes entidad)
        {
            return this.IClientesAplicacion.InsertarCliente(entidad);
        }

        [HttpPost]
        public Clientes ActualizarCliente(Clientes entidad)
        {
            return this.IClientesAplicacion.ActualizarCliente(entidad);
        }

        [HttpPost]
        public Clientes BorrarCliente(Clientes entidad)
        {
            return this.IClientesAplicacion.BorrarCliente(entidad);
        }


        //-----------------Recetas---------------------
        [HttpPost]
        public List<Recetas> ConsultarRecetas()
        {
            return this.IClientesAplicacion.ConsultarRecetas();
        }

        [HttpPost]
        public Recetas InsertarReceta(Recetas entidad)
        {
            return this.IClientesAplicacion.InsertarReceta(entidad);
        }

        [HttpPost]
        public Recetas ActualizarReceta(Recetas entidad)
        {
            return this.IClientesAplicacion.ActualizarReceta(entidad);
        }

        [HttpPost]
        public Recetas BorrarReceta(Recetas entidad)
        {
            return this.IClientesAplicacion.BorrarReceta(entidad);
        }


        //-----------------DetallesRecetas---------------------
        [HttpPost]
        public List<DetallesRecetas> ConsultarDetallesRecetas()
        {
            return this.IClientesAplicacion.ConsultarDetallesRecetas();
        }

        [HttpPost]
        public DetallesRecetas InsertarDetallesReceta(DetallesRecetas entidad)
        {
            return this.IClientesAplicacion.InsertarDetallesReceta(entidad);
        }

        [HttpPost]
        public DetallesRecetas ActualizarDetallesReceta(DetallesRecetas entidad)
        {
            return this.IClientesAplicacion.ActualizarDetallesReceta(entidad);
        }

        [HttpPost]
        public DetallesRecetas BorrarDetallesReceta(DetallesRecetas entidad)
        {
            return this.IClientesAplicacion.BorrarDetallesReceta(entidad);
        }


    }
}
