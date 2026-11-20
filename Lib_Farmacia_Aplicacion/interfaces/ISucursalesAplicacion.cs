using Lib_Farmacia_Aplicacion.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.interfaces
{
    public interface ISucursalesAplicacion
    {
        List<Sucursales> ConsultarSucursales();
        Sucursales InsertarSucursal(Sucursales entidad);
        Sucursales ActualizarSucursal(Sucursales entidad);
        Sucursales BorrarSucursal(Sucursales entidad);

    }
}
