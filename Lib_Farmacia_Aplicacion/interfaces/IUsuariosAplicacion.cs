using Lib_Farmacia_Aplicacion.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.interfaces
{
    public interface IUsuariosAplicacion
    {

        Usuarios? BuscarPorCredenciales(String correo, String contrasena);
        Auditorias RegistrarAuditoria(Auditorias entidad);

    }
}
