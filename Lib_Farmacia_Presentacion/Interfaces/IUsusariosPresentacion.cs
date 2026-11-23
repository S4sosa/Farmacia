using Lib_Farmacia_Aplicacion.entidades;

namespace Lib_Farmacia_Presentacion.interfaces
{
    public interface IUsuariosPresentacion
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