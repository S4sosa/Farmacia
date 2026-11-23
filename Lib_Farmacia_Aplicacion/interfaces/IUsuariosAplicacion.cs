using Lib_Farmacia_Aplicacion.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.interfaces
{
    public interface IUsuariosAplicacion
    {

        Usuarios? BuscarPorCredenciales(CredencialesDto credenciales);
        Auditorias RegistrarAuditoria(Auditorias entidad);

        List<Usuarios> ConsultarUsuarios();
        Usuarios InsertarUsuario(Usuarios entidad);
        Usuarios ActualizarUsuario(Usuarios entidad);
        Usuarios BorrarUsuario(Usuarios entidad);

        List<Auditorias> ConsultarAuditorias();

    }
}
