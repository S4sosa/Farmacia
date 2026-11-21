using Lib_Farmacia_Aplicacion.entidades;

namespace Lib_Farmacia_Presentacion.interfaces
{
    public interface IInventarioPresentacion
    {
        List<Productos> ConsultarProductos();
        List<Productos> BuscarProducto(Productos entidad);
        Productos InsertarProducto(Productos entidad);
        Productos ActualizarProducto(Productos entidad);
        Productos BorrarProducto(Productos entidad);
        List<Medicamentos> ConsultarMedicamentos();
        Medicamentos InsertarMedicamento(Medicamentos entidad);
        Medicamentos ActualizarMedicamento(Medicamentos entidad);
        Medicamentos BorrarMedicamento(Medicamentos entidad);
        List<Lotes> ConsultarLotes();
        Lotes InsertarLote(Lotes entidad);
        Lotes ActualizarLote(Lotes entidad);
        Lotes BorrarLote(Lotes entidad);
        List<Inventarios> ConsultarInventarios();
        Inventarios InsertarInventario(Inventarios entidad);
        Inventarios ActualizarInventario(Inventarios entidad);
        Inventarios BorrarInventario(Inventarios entidad);
    }
}