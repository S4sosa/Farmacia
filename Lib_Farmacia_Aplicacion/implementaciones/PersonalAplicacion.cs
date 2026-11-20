using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Lib_Farmacia_Aplicacion.nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.implementaciones
{
    public class PersonalAplicacion : IPersonalAplicacion
    {
        private IConexion IConexion;

        public PersonalAplicacion(IConexion Iconexion)
        {
            this.IConexion = Iconexion;
        }

        // -------- Personas ------------

        public List<Personas> ConsultarPersonas()
        {
            return this.IConexion.Personas!.ToList();
        }

        public Personas InsertarPersona(Personas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarPersonas(entidad))
                throw new Exception("Falta información");

            this.IConexion.Personas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Personas ActualizarPersona(Personas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarPersonas(entidad))
                throw new Exception("Falta información");

            var entry = this.IConexion.Entry<Personas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad; 
        }

        public Personas BorrarPersona(Personas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Personas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad; 
        }

        // -------- Empleados ------------

        public List<Empleados> ConsultarEmpleados()
        {
            return this.IConexion.Empleados!
                .Include(x => x._persona)
                .Include(x => x._cargo)
                .ToList();
        }

        public Empleados InsertarEmpleado(Empleados entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarEmpleados(entidad))
                throw new Exception("Falta información");

            this.IConexion.Empleados!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Empleados ActualizarEmpleado(Empleados entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarEmpleados(entidad))
                throw new Exception("Falta información");

            var entry = this.IConexion.Entry<Empleados>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Empleados BorrarEmpleado(Empleados entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.Empleados!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
