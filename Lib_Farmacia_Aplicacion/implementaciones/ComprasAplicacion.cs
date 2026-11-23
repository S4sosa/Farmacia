using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Lib_Farmacia_Aplicacion.nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.implementaciones
{
    public class ComprasAplicacion : IComprasAplicacion
    {
        private IConexion IConexion;

        public ComprasAplicacion(IConexion Iconexion)
        {
            this.IConexion = Iconexion;
        }

        //------------COMPRAS-------------

        public List<Compras> ConsultarCompras()
        {
            return this.IConexion.Compras!
                .Include(x => x._laboratorio)
                .Include(x => x.detallesCompras!)
                .ThenInclude(x => x._producto)
                .ToList();
        }

        public Compras InsertarCompra(Compras entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarCompras(entidad))
                throw new Exception("Falta Información");


            entidad.fecha = DateTime.Now;
            this.IConexion.Compras!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

        }

        public Compras ActualizarCompra(Compras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarCompras(entidad))
                throw new Exception("Falta Información");

            var entry = this.IConexion.Entry<Compras>(entidad);
            entry.State = EntityState.Modified;
            entry.Property(x => x.fecha).IsModified = false;   // ← agregar: conserva la fecha original
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Compras BorrarCompra(Compras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Compras!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }



        //-------------DetalleCompras-------------

        public List<DetallesCompras> ConsultarDetallesCompras()
        {
            return this.IConexion.DetallesCompras!.ToList();
        }

        public DetallesCompras InsertarDetallesCompra(DetallesCompras entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarDetallesCompras(entidad))
                throw new Exception("Falta Información");

            this.IConexion.DetallesCompras!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

        }

        public DetallesCompras ActualizarDetallesCompra(DetallesCompras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarDetallesCompras(entidad))
                throw new Exception("Falta Información");

            var entry = this.IConexion.Entry<DetallesCompras>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public DetallesCompras BorrarDetallesCompra(DetallesCompras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.DetallesCompras!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }



    }
}
