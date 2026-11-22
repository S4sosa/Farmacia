using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;

namespace Lib_Farmacia_Presentacion.implementaciones
{
    public class SucursalesPresentacion : ISucursalesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public SucursalesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public List<Sucursales> ConsultarSucursales()
        {
            var task = this.IComunicaciones.Ejecutar<List<Sucursales>>(
                "Sucursales/ConsultarSucursales",
                null!);
            task.Wait();
            return task.Result;
        }

        public Sucursales InsertarSucursal(Sucursales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validaciones.ValidarSucursales(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Sucursales>(
                "Sucursales/InsertarSucursal",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Sucursales ActualizarSucursal(Sucursales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validaciones.ValidarSucursales(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Sucursales>(
                "Sucursales/ActualizarSucursal",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Sucursales BorrarSucursal(Sucursales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Sucursales>(
                "Sucursales/BorrarSucursal",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}