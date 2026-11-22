using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Lib_Farmacia_Aplicacion.nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.implementaciones
{
    public class VentasAplicacion : IVentasAplicacion
    {
        private IConexion IConexion;

        public VentasAplicacion(IConexion Iconexion)
        {
            this.IConexion = Iconexion;
        }

        //-------------VENTAS--------------

        public List<Ventas> ConsultarVentas()
        {
            return this.IConexion.Ventas!
                .Include(x => x._cliente)
                .ThenInclude(x => x!._persona)
                .Include(x => x.detallesVentas!)
                .ThenInclude(x => x._producto)
                .ToList();
        }

        public List<Ventas> BuscarVenta(Ventas entidad)
        {
            return this.IConexion.Ventas!
                .Include(x => x._cliente)
                .ThenInclude(x => x!._persona)
                .Include(x => x.detallesVentas!)
                .ThenInclude(x => x._producto)
                .Where(x => x.cliente == entidad.cliente)
                .ToList();
        }

        public Ventas InsertarVenta(Ventas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarVentas(entidad))
                throw new Exception("Falta Información");

            entidad.fecha = DateTime.Now;
            this.IConexion.Ventas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

        }

        public Ventas ActualizarVenta(Ventas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarVentas(entidad))
                throw new Exception("Falta Información");

            var entry = this.IConexion.Entry<Ventas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Ventas BorrarVenta(Ventas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            // 1. Borrar primero lo que depende de la venta
            var detalles = this.IConexion.DetallesVentas!
                .Where(x => x.venta == entidad.Id)
                .ToList();
            this.IConexion.DetallesVentas!.RemoveRange(detalles);

            var facturas = this.IConexion.Facturas!
                .Where(x => x.venta == entidad.Id)
                .ToList();
            this.IConexion.Facturas!.RemoveRange(facturas);

            // 2. Quitar las listas relacionadas para que EF no intente borrarlas dos veces
            entidad.detallesVentas = null;
            entidad.facturas = null;
            entidad._cliente = null;

            // 3. Borrar la venta
            this.IConexion.Ventas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }


        //-------------DETALLESVENTAS--------------

        public List<DetallesVentas> ConsultarDetallesVentas()
        {
            return this.IConexion.DetallesVentas!
                .Include(x => x._venta)
                .Include(x => x._producto)
                .ToList();
        }

        public DetallesVentas InsertarDetallesVenta(DetallesVentas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarDetallesVentas(entidad))
                throw new Exception("Falta Información");

            this.IConexion.DetallesVentas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

        }

        public DetallesVentas ActualizarDetallesVenta(DetallesVentas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarDetallesVentas(entidad))
                throw new Exception("Falta Información");

            var entry = this.IConexion.Entry<DetallesVentas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public DetallesVentas BorrarDetallesVenta(DetallesVentas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.DetallesVentas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }


        //-------------FACTURAS--------------

        public List<Facturas> ConsultarFacturas()
        {
            return this.IConexion.Facturas!
                .Include(x=> x._venta)
                .Include(x => x._metodoPago)
                .ToList();
        }

        public Facturas InsertarFactura(Facturas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarFacturas(entidad))
                throw new Exception("Falta Información");

            this.IConexion.Facturas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

        }

        public Facturas ActualizarFactura(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarFacturas(entidad))
                throw new Exception("Falta Información");

            var entry = this.IConexion.Entry<Facturas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Facturas BorrarFactura(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Facturas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}
