using Lib_Farmacia_Aplicacion.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.interfaces
{
    public interface IComprasAplicacion
    {
        List<Compras> ConsultarCompras();
        Compras InsertarCompra(Compras entidad);
        Compras ActualizarCompra(Compras entidad);
        Compras BorrarCompra(Compras entidad);

        List<DetallesCompras> ConsultarDetallesCompras();
        DetallesCompras InsertarDetallesCompra(DetallesCompras entidad);
        DetallesCompras ActualizarDetallesCompra(DetallesCompras entidad);
        DetallesCompras BorrarDetallesCompra(DetallesCompras entidad);
    }
}
