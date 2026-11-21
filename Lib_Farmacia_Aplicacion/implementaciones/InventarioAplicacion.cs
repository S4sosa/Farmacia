using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Lib_Farmacia_Aplicacion.nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.implementaciones
{
    public class InventarioAplicacion : IInventarioAplicacion
    {
        private IConexion IConexion;

        public InventarioAplicacion(IConexion Iconexion)
        {
            this.IConexion = Iconexion;
        }

        //------------- Productos ---------------

        public List<Productos> ConsultarProductos()
        {
            return this.IConexion.Productos!.ToList();
        }

        public List<Productos> BuscarProducto(Productos entidad)
        {
            return this.IConexion.Productos!
                .Include(x => x._categoria)
                .Where(x => x.nombre!.Contains(entidad.nombre!))
                .ToList();
        }

        public Productos InsertarProducto(Productos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarProductos(entidad))
                throw new Exception("Falta Información");

            this.IConexion.Productos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

        }

        public Productos ActualizarProducto(Productos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarProductos(entidad))
                throw new Exception("Falta Información");

            var entry = this.IConexion.Entry<Productos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Productos BorrarProducto(Productos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Productos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        //------------- Medicamentos ---------------

        public List<Medicamentos> ConsultarMedicamentos()
        {
            return this.IConexion.Medicamentos!
                .Include(x =>   x._producto)
                .Include(x => x._presentacion)
                .ToList();
        }

        public Medicamentos InsertarMedicamento(Medicamentos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarMedicamentos(entidad))
                throw new Exception("Falta Información");

            this.IConexion.Medicamentos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

        }

        public Medicamentos ActualizarMedicamento(Medicamentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarMedicamentos(entidad))
                throw new Exception("Falta Información");

            var entry = this.IConexion.Entry<Medicamentos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Medicamentos BorrarMedicamento(Medicamentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Medicamentos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        //------------- Lotes ---------------

        public List<Lotes> ConsultarLotes()
        {
            return this.IConexion.Lotes!
                .Include(x => x._producto)
                .ToList();
        }

        public Lotes InsertarLote(Lotes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarLotes(entidad))
                throw new Exception("Falta Información");

            
            this.IConexion.Lotes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

        }

        public Lotes ActualizarLote(Lotes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarLotes(entidad))
                throw new Exception("Falta Información");

            var entry = this.IConexion.Entry<Lotes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Lotes BorrarLote(Lotes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Lotes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        //------------- Inventarios ---------------

        public List<Inventarios> ConsultarInventarios()
        {
            return this.IConexion.Inventarios!
                .Include(x => x._producto)
                .Include(x => x._sucursal)
                .ToList();
        }

        public Inventarios InsertarInventario(Inventarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarInventarios(entidad))
                throw new Exception("Falta Información");

            this.IConexion.Inventarios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

        }

        public Inventarios ActualizarInventario(Inventarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarInventarios(entidad))
                throw new Exception("Falta Información");

            var entry = this.IConexion.Entry<Inventarios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Inventarios BorrarInventario(Inventarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Inventarios!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}
