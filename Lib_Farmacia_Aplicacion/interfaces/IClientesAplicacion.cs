using Lib_Farmacia_Aplicacion.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.interfaces
{
    public interface IClientesAplicacion
    {
        List<Clientes> ConsultarClientes();
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
