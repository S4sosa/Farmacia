using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Lib_Farmacia_Aplicacion.nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.implementaciones
{
    public class ClientesAplicacion : IClientesAplicacion
    {
        private IConexion IConexion; 

        public ClientesAplicacion(IConexion Iconexion)
        {
            this.IConexion = Iconexion;
        }

        // -------------- Clientes --------------

        public List<Clientes> ConsultarClientes()
        {
            return this.IConexion.Clientes!
                .Include(x => x._persona)
                .ToList();
        }

        public List<Clientes> BuscarCliente(Clientes entidad)
        {
            return this.IConexion.Clientes!
                .Include(x => x._persona)
                .Where(x => x._persona!.nombre!.Contains(entidad._persona!.nombre!) ||
                            x._persona!.documento!.Contains(entidad._persona!.documento!))
                .ToList();
        }

        public Clientes InsertarCliente(Clientes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarClientes(entidad))
                throw new Exception("Falta Información");

            entidad.fechaRegistro = DateTime.Now; //Hay que registrar la hora fehca y crear
            entidad.activo = true; //Hay que registrar como activo al regitra

            this.IConexion.Clientes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

        }

        public Clientes ActualizarCliente(Clientes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarClientes(entidad))
                throw new Exception("Falta información");

            //Hay que proteger la fecha de registro y la actividad, porque no se deben pedir por formualario
            var clienteExistente = this.IConexion.Clientes!.Find(entidad.Id);

            if (clienteExistente is null) // Validacion si no existe el cliente 
                throw new Exception("El cliente no existe");

            // Solo se permite actualizar la persona.
            // fechaRegistro y activo se mantienen protegidos.
            clienteExistente.persona = entidad.persona;


            var entry = this.IConexion.Entry(clienteExistente);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return clienteExistente;
        }

        public Clientes BorrarCliente(Clientes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var cliente = this.IConexion.Clientes!.Find(entidad.Id);
            if (cliente == null)
                throw new Exception("El cliente no existe");

            // ¿Tiene historial?
            bool tieneMovimientos =
                this.IConexion.Recetas!.Any(x => x.cliente == cliente.Id) ||
                this.IConexion.Ventas!.Any(x => x.cliente == cliente.Id) ||
                this.IConexion.Usuarios!.Any(x => x.cliente == cliente.Id);

            if (tieneMovimientos)
            {
                // No se borra: solo se desactiva
                cliente.activo = false;
                this.IConexion.Entry(cliente).State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return cliente;
            }

            // Sin historial: se borra el cliente...
            this.IConexion.Clientes!.Remove(cliente);

            // ...y su persona, solo si nadie más la usa
            bool personaEnUso =
                this.IConexion.Empleados!.Any(x => x.persona == cliente.persona) ||
                this.IConexion.Clientes!.Any(x => x.persona == cliente.persona && x.Id != cliente.Id);

            if (!personaEnUso)
            {
                var persona = this.IConexion.Personas!.Find(cliente.persona);
                if (persona != null)
                    this.IConexion.Personas!.Remove(persona);
            }

            this.IConexion.SaveChanges();
            return cliente;
        }
        // -------------- Recetas --------------

        public List<Recetas> ConsultarRecetas()
        {
            return this.IConexion.Recetas!
                .Include(x => x._cliente)
                .ThenInclude(x => x!._persona)
                .ToList();
        }

        public Recetas InsertarReceta(Recetas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarRecetas(entidad))
                throw new Exception("Falta Información");

            this.IConexion.Recetas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

        }

        public Recetas ActualizarReceta(Recetas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarRecetas(entidad))
                throw new Exception("Falta Información");

            var entry = this.IConexion.Entry<Recetas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Recetas BorrarReceta(Recetas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var detalles = this.IConexion.DetallesRecetas!
                .Where(x => x.receta == entidad.Id)
                .ToList();
            this.IConexion.DetallesRecetas!.RemoveRange(detalles);

            entidad._cliente = null;
            entidad.detallesRecetas = null;

            var entry = this.IConexion.Entry<Recetas>(entidad);
            entry.State = EntityState.Deleted;
            this.IConexion.SaveChanges();
            return entidad;
        }

        // -------------- DetallesRecetas --------------

        public List<DetallesRecetas> ConsultarDetallesRecetas()
        {
            return this.IConexion.DetallesRecetas!.ToList();
        }

        public DetallesRecetas InsertarDetallesReceta(DetallesRecetas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarDetallesRecetas(entidad))
                throw new Exception("Falta Información");

            this.IConexion.DetallesRecetas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;

        }

        public DetallesRecetas ActualizarDetallesReceta(DetallesRecetas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");
            if (Validaciones.ValidarDetallesRecetas(entidad))
                throw new Exception("Falta Información");

            var entry = this.IConexion.Entry<DetallesRecetas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public DetallesRecetas BorrarDetallesReceta(DetallesRecetas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion.DetallesRecetas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}
