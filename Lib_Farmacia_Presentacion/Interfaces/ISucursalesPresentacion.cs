using Lib_Farmacia_Aplicacion.entidades;

namespace Lib_Farmacia_Presentacion.interfaces
{
    public interface ISucursalesPresentacion
    {
        List<Sucursales> ConsultarSucursales();
        Sucursales InsertarSucursal(Sucursales entidad);
        Sucursales ActualizarSucursal(Sucursales entidad);
        Sucursales BorrarSucursal(Sucursales entidad);
    }
}
