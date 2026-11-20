using Lib_Farmacia_Aplicacion.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.interfaces
{
    public interface IInventarioAplicacion
    {
        List<Productos> ConsultarProductos();
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
