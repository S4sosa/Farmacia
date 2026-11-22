using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Farmacia_Servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosAplicacion IUsuariosAplicacion;

        public UsuariosController(IUsuariosAplicacion IUsuariosAplicacion)
        {
            this.IUsuariosAplicacion = IUsuariosAplicacion;
        }


        //-----------------Usuarios---------------------
        [HttpPost]
        public Usuarios? BuscarPorCredenciales(CredencialesDto credenciales)
        {
            return this.IUsuariosAplicacion.BuscarPorCredenciales(credenciales);
        }

        [HttpPost]
        public Auditorias RegistrarAuditoria(Auditorias entidad)
        {
            return this.IUsuariosAplicacion.RegistrarAuditoria(entidad);
        }

    }
}
