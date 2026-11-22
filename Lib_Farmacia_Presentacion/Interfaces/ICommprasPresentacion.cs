using Lib_Farmacia_Aplicacion.entidades;

namespace Lib_Farmacia_Presentacion.interfaces
{
    public interface IComprasPresentacion
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