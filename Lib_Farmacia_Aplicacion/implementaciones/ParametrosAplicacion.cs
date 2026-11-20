using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Lib_Farmacia_Aplicacion.nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.implementaciones
{
    public class ParametrosAplicacion : IParametrosAplicacion
    {
        private IConexion IConexion;

        public ParametrosAplicacion(IConexion Iconexion)
        { 
            this.IConexion = Iconexion;
        }

        // --------- CARGOS ---------

        public List<Cargos> ConsultarCargos()
        {
            return this.IConexion.Cargos!.ToList(); 
        }

        public Cargos InsertarCargo(Cargos entidad)
        {
            if(entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarCargos(entidad))
                throw new Exception("Falta Información");

            this.IConexion.Cargos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad; 

        }

        public Cargos ActualizarCargo(Cargos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarCargos(entidad))
                throw new Exception("Falta Información");

            var entry = this.IConexion.Entry<Cargos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Cargos BorrarCargo(Cargos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Cargos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        // --------- CATEGORIAS ---------

        public List<Categorias> ConsultarCategorias()
        {
            return this.IConexion.Categorias!.ToList();
        }

        public Categorias InsertarCategoria(Categorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarCategorias(entidad))
                throw new Exception("Falta Información");

            this.IConexion.Categorias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

        }

        public Categorias ActualizarCategoria(Categorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarCategorias(entidad))
                throw new Exception("Falta Información");

            var entry = this.IConexion.Entry<Categorias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Categorias BorrarCategoria(Categorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Categorias!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }


        // --------- PRESENTACIONES ---------

        public List<Presentaciones> ConsultarPresentaciones()
        {
            return this.IConexion.Presentaciones!.ToList();
        }

        public Presentaciones InsertarPresentacion(Presentaciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarPresentaciones(entidad))
                throw new Exception("Falta Información");

            this.IConexion.Presentaciones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

        }

        public Presentaciones ActualizarPresentacion(Presentaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarPresentaciones(entidad))
                throw new Exception("Falta Información");

            var entry = this.IConexion.Entry<Presentaciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Presentaciones BorrarPresentacion(Presentaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Presentaciones!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        // --------- METODOSPAGO ---------

        public List<MetodosPagos> ConsultarMetodosPagos()
        {
            return this.IConexion.MetodosPagos!.ToList();
        }

        public MetodosPagos InsertarMetodoPago(MetodosPagos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarMetodosPagos(entidad))
                throw new Exception("Falta Información");

            this.IConexion.MetodosPagos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

        }

        public MetodosPagos ActualizarMetodoPago(MetodosPagos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarMetodosPagos(entidad))
                throw new Exception("Falta Información");

            var entry = this.IConexion.Entry<MetodosPagos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public MetodosPagos BorrarMetodoPago(MetodosPagos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.MetodosPagos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        // --------- LABORATIORIO ---------

        public List<Laboratorios> ConsultarLaboratorios()
        {
            return this.IConexion.Laboratorios!.ToList();
        }

        public Laboratorios InsertarLaboratorio(Laboratorios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarLaboratorios(entidad))
                throw new Exception("Falta información");

            this.IConexion.Laboratorios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Laboratorios ActualizarLaboratorio(Laboratorios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarLaboratorios(entidad))
                throw new Exception("Falta información");

            var entry = this.IConexion.Entry<Laboratorios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Laboratorios BorrarLaboratorio(Laboratorios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Laboratorios!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        // --------- ROLES ---------

        public List<Roles> ConsultarRoles()
        {
            return this.IConexion.Roles!.ToList();
        }
        //Solo con Consultar Porque no se gestionan desde el front, los dos roles(Admi y Cliente) ya estan en la BD 
    }
}
