using Lib_Farmacia_Aplicacion.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.nucleo
{
    public static class Validaciones
    {

        public static bool ValidarCargos(Cargos entidad)
        {
            return string.IsNullOrEmpty(entidad.nombre);
        }

        public static bool ValidarCategorias(Categorias entidad)
        { 
            return string.IsNullOrEmpty(entidad.nombre);
        }

        public static bool ValidarClientes(Clientes entidad)
        { 
            return entidad.persona == 0;
            //No se valida fechaRegistro ni activo porque se asignan al crear el registro
            //Con DateTime.now y True por obvias razones. 
        }

        public static bool ValidarCompras(Compras entidad)
        {
            return entidad.laboratorio == 0 ||
                entidad.total == 0; 
            //No se valida fecha por DateTime.now 
        }

        public static bool ValidarDetallesCompras(DetallesCompras entidad)
        {
            return entidad.compra == 0 ||
                entidad.producto == 0 ||
                entidad.cantidad == 0 ||
                entidad.precio == 0; 
        }

        public static bool ValidarDetallesRecetas(DetallesRecetas entidad)
        {
            return entidad.receta == 0 ||
                entidad.medicamento == 0 ||
                entidad.cantidad == 0;
        }

        public static bool ValidarDetallesVentas(DetallesVentas entidad)
        {
            return entidad.venta == 0 ||
                entidad.producto == 0 ||
                entidad.cantidad == 0; 
        }

        public static bool ValidarEmpleados(Empleados entidad)
        {
            return entidad.persona == 0 ||
                entidad.cargo == 0; 
        }

        public static bool ValidarFacturas(Facturas entidad)
        {
            return entidad.venta == 0 ||
                entidad.metodoPago == 0; 
        }

        public static bool ValidarInventarios(Inventarios entidad) 
        {
            return entidad.producto == 0 ||
                entidad.sucursal == 0 ||
                entidad.cantidad == 0;
        }

        public static bool ValidarLaboratorios(Laboratorios entidad)
        {
            return string.IsNullOrEmpty(entidad.nombre);
        }

        public static bool ValidarLotes(Lotes entidad)
        {
            return entidad.producto == 0 ||
                String.IsNullOrEmpty(entidad.numLote) ||
                entidad.fechaVencimiento == default;
            //default en DateTime equivale a 01/01/0001 -- Se le asigna a una fecha cuando no se pone. 
        }

        public static bool ValidarMedicamentos(Medicamentos entidad)
        {
            return entidad.producto == 0 ||
                entidad.presentacion == 0; 
        }

        public static bool ValidarMetodosPago(MetodosPagos entidad)
        { 
            return string.IsNullOrEmpty(entidad.nombre);
        }

        public static bool ValidarPersonas(Personas entidad)
        {
            return String.IsNullOrEmpty(entidad.nombre) ||
                String.IsNullOrEmpty(entidad.apellidos) ||
                String.IsNullOrEmpty(entidad.documento);
            //No validamos el telefono porque una persona podria no tenerlo. 
        }

        public static bool ValidarPresentaciones(Presentaciones entidad)
        {
            return String.IsNullOrEmpty(entidad.nombre);
        }

        public static bool ValidarProductos(Productos entidad)
        {
            return String.IsNullOrEmpty(entidad.nombre) ||
                entidad.precio == 0 ||
                entidad.categoria == 0;
        }

        public static bool ValidarRecetas(Recetas entidad)
        {
            return entidad.cliente == 0 ||
                String.IsNullOrEmpty(entidad.medicoNombre) ||
                entidad.fechaEmision == default;
        }

        public static bool ValidarRoles(Roles entidad)
        {
            return String.IsNullOrEmpty(entidad.nombre);
        }

        public static bool ValidarSucursales(Sucursales entidad)
        {
            return String.IsNullOrEmpty(entidad.nombre) ||
                String.IsNullOrEmpty(entidad.direccion);
            //No validamos el telefono porque una sucursal podria no tenerlo.
        }

        public static bool ValidarUsuarios(Usuarios entidad)
        {
            return String.IsNullOrEmpty(entidad.nombre) ||
                String.IsNullOrEmpty(entidad.correo) ||
                String.IsNullOrEmpty(entidad.contrasena) ||
                entidad.rol == 0; 
            //No validamos cliente porque podria ser el administrador. 
        }

        public static bool ValidarVentas(Ventas entidad)
        {
            return entidad.cliente == 0 ||
                entidad.total == 0; 
            //DateTime.Now
        }
    }
}
