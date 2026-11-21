using Microsoft.AspNetCore.Mvc;
using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;

namespace Asp_Farmacia_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ParametrosController : ControllerBase
    {
        private IParametrosAplicacion IParametrosAplicacion;

        public ParametrosController(IParametrosAplicacion IParametrosAplicacion)
        {
            this.IParametrosAplicacion = IParametrosAplicacion;
        }


        //-----------------Cargos---------------------
        [HttpPost]
        public List<Cargos> ConsultarCargos()
        {
            return this.IParametrosAplicacion.ConsultarCargos();
        }

        [HttpPost]
        public Cargos InsertarCargo(Cargos entidad)
        {
            return this.IParametrosAplicacion.InsertarCargo(entidad);
        }

        [HttpPost]
        public Cargos ActualizarCargo(Cargos entidad)
        {
            return this.IParametrosAplicacion.ActualizarCargo(entidad);
        }

        [HttpPost]
        public Cargos BorrarCargo(Cargos entidad)
        {
            return this.IParametrosAplicacion.BorrarCargo(entidad);
        }

        //-----------------Categorias---------------------

        [HttpPost]
        public List<Categorias> ConsultarCategorias()
        {
            return this.IParametrosAplicacion.ConsultarCategorias();
        }

        [HttpPost]
        public Categorias InsertarCategoria(Categorias entidad)
        {
            return this.IParametrosAplicacion.InsertarCategoria(entidad);
        }

        [HttpPost]
        public Categorias ActualizarCategoria(Categorias entidad)
        {
            return this.IParametrosAplicacion.ActualizarCategoria(entidad);
        }

        [HttpPost]
        public Categorias BorrarCategoria(Categorias entidad)
        {
            return this.IParametrosAplicacion.BorrarCategoria(entidad);
        }


        //-----------------Presentaciones---------------------

        [HttpPost]
        public List<Presentaciones> ConsultarPresentaciones()
        {
            return this.IParametrosAplicacion.ConsultarPresentaciones();
        }

        [HttpPost]
        public Presentaciones InsertarPresentacion(Presentaciones entidad)
        {
            return this.IParametrosAplicacion.InsertarPresentacion(entidad);
        }

        [HttpPost]
        public Presentaciones ActualizarPresentacion(Presentaciones entidad)
        {
            return this.IParametrosAplicacion.ActualizarPresentacion(entidad);
        }

        [HttpPost]
        public Presentaciones BorrarPresentacion(Presentaciones entidad)
        {
            return this.IParametrosAplicacion.BorrarPresentacion(entidad);
        }


        //-----------------MetodosPagos---------------------

        [HttpPost]
        public List<MetodosPagos> ConsultarMetodosPagos()
        {
            return this.IParametrosAplicacion.ConsultarMetodosPagos();
        }

        [HttpPost]
        public MetodosPagos InsertarMetodoPago(MetodosPagos entidad)
        {
            return this.IParametrosAplicacion.InsertarMetodoPago(entidad);
        }

        [HttpPost]
        public MetodosPagos ActualizarMetodoPago(MetodosPagos entidad)
        {
            return this.IParametrosAplicacion.ActualizarMetodoPago(entidad);
        }

        [HttpPost]
        public MetodosPagos BorrarMetodoPago(MetodosPagos entidad)
        {
            return this.IParametrosAplicacion.BorrarMetodoPago(entidad);
        }


        //-----------------Laboratorios---------------------


        [HttpPost]
        public List<Laboratorios> ConsultarLaboratorios()
        {
            return this.IParametrosAplicacion.ConsultarLaboratorios();
        }

        [HttpPost]
        public Laboratorios InsertarLaboratorio(Laboratorios entidad)
        {
            return this.IParametrosAplicacion.InsertarLaboratorio(entidad);
        }

        [HttpPost]
        public Laboratorios ActualizarLaboratorio(Laboratorios entidad)
        {
            return this.IParametrosAplicacion.ActualizarLaboratorio(entidad);
        }

        [HttpPost]
        public Laboratorios BorrarLaboratorio(Laboratorios entidad)
        {
            return this.IParametrosAplicacion.BorrarLaboratorio(entidad);
        }



        //-----------------Roles---------------------


        [HttpPost]
        public List<Roles> ConsultarRoles()
        {
            return this.IParametrosAplicacion.ConsultarRoles();
        }
        
    }
}

