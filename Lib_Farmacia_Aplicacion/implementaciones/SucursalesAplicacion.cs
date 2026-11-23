using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Lib_Farmacia_Aplicacion.nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.implementaciones
{
    public class SucursalesAplicacion : ISucursalesAplicacion
    {
        private IConexion IConexion;

        public SucursalesAplicacion(IConexion Iconexion)
        {
            this.IConexion = Iconexion;
        }

        public List<Sucursales> ConsultarSucursales()
        {
            return this.IConexion.Sucursales!.ToList();
        }

        public Sucursales InsertarSucursal(Sucursales entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("ya se guardó");
            if (Validaciones.ValidarSucursales(entidad))
                throw new Exception("Falta información");

            this.IConexion.Sucursales!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Sucursales ActualizarSucursal(Sucursales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarSucursales(entidad))
                throw new Exception("Falta información");

            var entry = this.IConexion.Entry<Sucursales>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Sucursales BorrarSucursal(Sucursales entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var inventarios = this.IConexion.Inventarios!
                .Where(x => x.sucursal == entidad.Id)
                .ToList();
            this.IConexion.Inventarios!.RemoveRange(inventarios);

            entidad.inventarios = null;
            this.IConexion.Sucursales!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
