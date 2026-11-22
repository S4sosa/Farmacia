using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Presentacion.interfaces;

namespace Lib_Farmacia_Presentacion.implementaciones
{
    public class UsuariosPresentacion : IUsuariosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public UsuariosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Usuarios? BuscarPorCredenciales(CredencialesDto credenciales)
        {
            var task = this.IComunicaciones.Ejecutar<Usuarios?>(
                "Usuarios/BuscarPorCredenciales",
                credenciales);
            task.Wait();
            return task.Result;
        }

        public Auditorias RegistrarAuditoria(Auditorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var task = this.IComunicaciones.Ejecutar<Auditorias>(
                "Usuarios/RegistrarAuditoria",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}
