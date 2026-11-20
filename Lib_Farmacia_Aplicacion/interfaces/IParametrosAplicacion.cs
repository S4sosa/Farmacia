using Lib_Farmacia_Aplicacion.entidades;
using System.Collections.Generic;

namespace Lib_Farmacia_Aplicacion.interfaces
{
    public interface IParametrosAplicacion
    {
        List<Cargos> ConsultarCargos();
        Cargos InsertarCargo(Cargos entidad);
        Cargos ActualizarCargo(Cargos entidad);
        Cargos BorrarCargo(Cargos entidad);

        List<Categorias> ConsultarCategorias();
        Categorias InsertarCategoria(Categorias entidad);
        Categorias ActualizarCategoria(Categorias entidad);
        Categorias BorrarCategoria(Categorias entidad);

        List<Presentaciones> ConsultarPresentaciones();
        Presentaciones InsertarPresentacion(Presentaciones entidad);
        Presentaciones ActualizarPresentacion(Presentaciones entidad);
        Presentaciones BorrarPresentacion(Presentaciones entidad);

        List<MetodosPagos> ConsultarMetodosPagos();
        MetodosPagos InsertarMetodoPago(MetodosPagos entidad);
        MetodosPagos ActualizarMetodoPago(MetodosPagos entidad);
        MetodosPagos BorrarMetodoPago(MetodosPagos entidad);

        List<Laboratorios> ConsultarLaboratorios();
        Laboratorios InsertarLaboratorio(Laboratorios entidad);
        Laboratorios ActualizarLaboratorio(Laboratorios entidad);
        Laboratorios BorrarLaboratorio(Laboratorios entidad);

        List<Roles> ConsultarRoles();
    }
}
