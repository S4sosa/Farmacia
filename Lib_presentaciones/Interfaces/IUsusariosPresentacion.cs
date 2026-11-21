using Lib_Farmacia_Aplicacion.entidades;

namespace Lib_Farmacia_Presentacion.interfaces
{
    public interface IUsuariosPresentacion
    {
        Usuarios? BuscarPorCredenciales(string correo, string contrasena);
        Auditorias RegistrarAuditoria(Auditorias entidad);
    }
}