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

        [HttpPost]
        public List<Usuarios> ConsultarUsuarios()
        {
            return this.IUsuariosAplicacion.ConsultarUsuarios();
        }

        [HttpPost]
        public Usuarios InsertarUsuario(Usuarios entidad)
        {
            return this.IUsuariosAplicacion.InsertarUsuario(entidad);
        }

        [HttpPost]
        public Usuarios ActualizarUsuario(Usuarios entidad)
        {
            return this.IUsuariosAplicacion.ActualizarUsuario(entidad);
        }

        [HttpPost]
        public Usuarios BorrarUsuario(Usuarios entidad)
        {
            return this.IUsuariosAplicacion.BorrarUsuario(entidad);
        }


        //-----------------Auditorias---------------------
        [HttpPost]
        public List<Auditorias> ConsultarAuditorias()
        {
            return this.IUsuariosAplicacion.ConsultarAuditorias();
        }

    }
}
