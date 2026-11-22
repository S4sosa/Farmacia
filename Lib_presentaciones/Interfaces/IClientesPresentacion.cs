using Lib_Farmacia_Aplicacion.entidades;

namespace Lib_Farmacia_Presentacion.interfaces
{
    public interface IClientesPresentacion
    {
        List<Clientes> ConsultarClientes();
        List<Clientes> BuscarCliente(Clientes entidad);
        Clientes InsertarCliente(Clientes entidad);
        Clientes ActualizarCliente(Clientes entidad);
        Clientes BorrarCliente(Clientes entidad);
        List<Recetas> ConsultarRecetas();
        Recetas InsertarReceta(Recetas entidad);
        Recetas ActualizarReceta(Recetas entidad);
        Recetas BorrarReceta(Recetas entidad);
        List<DetallesRecetas> ConsultarDetallesRecetas();
        DetallesRecetas InsertarDetallesReceta(DetallesRecetas entidad);
        DetallesRecetas ActualizarDetallesReceta(DetallesRecetas entidad);
        DetallesRecetas BorrarDetallesReceta(DetallesRecetas entidad);
    }
}
