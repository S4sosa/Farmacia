using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Farmacia_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonalController : ControllerBase
    {
        private IPersonalAplicacion IPersonalAplicacion;

        public PersonalController(IPersonalAplicacion IPersonalAplicacion)
        {
            this.IPersonalAplicacion = IPersonalAplicacion;
        }


        //-----------------Personas---------------------
        [HttpPost]
        public List<Personas> ConsultarPersonas()
        {
            return this.IPersonalAplicacion.ConsultarPersonas();
        }

        [HttpPost]
        public Personas InsertarPersona(Personas entidad)
        {
            return this.IPersonalAplicacion.InsertarPersona(entidad);
        }

        [HttpPost]
        public Personas ActualizarPersona(Personas entidad)
        {
            return this.IPersonalAplicacion.ActualizarPersona(entidad);
        }

        [HttpPost]
        public Personas BorrarPersona(Personas entidad)
        {
            return this.IPersonalAplicacion.BorrarPersona(entidad);
        }


        //-----------------Empleados---------------------
        [HttpPost]
        public List<Empleados> ConsultarEmpleados()
        {
            return this.IPersonalAplicacion.ConsultarEmpleados();
        }

        [HttpPost]
        public Empleados InsertarEmpleado(Empleados entidad)
        {
            return this.IPersonalAplicacion.InsertarEmpleado(entidad);
        }

        [HttpPost]
        public Empleados ActualizarEmpleado(Empleados entidad)
        {
            return this.IPersonalAplicacion.ActualizarEmpleado(entidad);
        }

        [HttpPost]
        public Empleados BorrarEmpleado(Empleados entidad)
        {
            return this.IPersonalAplicacion.BorrarEmpleado(entidad);
        }

    }
}