using Lib_Farmacia_Aplicacion.entidades;

namespace Lib_Farmacia_Presentacion.interfaces
{
    public interface IVentasPresentacion
    {
        List<Ventas> ConsultarVentas();
        Ventas InsertarVenta(Ventas entidad);
        Ventas ActualizarVenta(Ventas entidad);
        Ventas BorrarVenta(Ventas entidad);
        List<DetallesVentas> ConsultarDetallesVentas();
        DetallesVentas InsertarDetallesVenta(DetallesVentas entidad);
        DetallesVentas ActualizarDetallesVenta(DetallesVentas entidad);
        DetallesVentas BorrarDetallesVenta(DetallesVentas entidad);
        List<Facturas> ConsultarFacturas();
        Facturas InsertarFactura(Facturas entidad);
        Facturas ActualizarFactura(Facturas entidad);
        Facturas BorrarFactura(Facturas entidad);
    }
}