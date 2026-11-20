using Lib_Farmacia_Aplicacion.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.interfaces
{
    public interface IProductosAplicacion
    {
        List<Productos> ConsultarProductos(Productos entidad);
    }
}
