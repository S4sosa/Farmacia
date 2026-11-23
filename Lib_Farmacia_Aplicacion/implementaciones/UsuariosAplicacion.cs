using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Lib_Farmacia_Aplicacion.nucleo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private IConexion IConexion;

        public UsuariosAplicacion(IConexion Iconexion)
        {
            this.IConexion = Iconexion;
        }

        public Usuarios? BuscarPorCredenciales(CredencialesDto credenciales)
        {
            return this.IConexion.Usuarios!
                .Include(x => x._rol)
                .Include(x => x._cliente) // se traen los datos del cliente que incio sesion(si es cliente)
                .FirstOrDefault(x => x.correo == credenciales.correo &&         // se verifica correo y contraseña
                                     x.contrasena == credenciales.contrasena);  //-- Se verifican datos planos en la bd
        }                                                                       //pero para este proyecto lo dejaremos asi    
        
        public Auditorias RegistrarAuditoria(Auditorias entidad)
        {
            entidad.fecha = DateTime.Now;
            this.IConexion.Auditorias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad; 
        }

        //-------------- Usuarios (ventana de administracion) --------------

        public List<Usuarios> ConsultarUsuarios()
        {
            return this.IConexion.Usuarios!
                .Include(x => x._rol)
                .Include(x => x._cliente)
                .ThenInclude(x => x!._persona)
                .ToList();
        }

        public Usuarios InsertarUsuario(Usuarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardó");
            if (Validaciones.ValidarUsuarios(entidad))
                throw new Exception("Falta Información");
            if (this.IConexion.Usuarios!.Any(x => x.correo == entidad.correo))
                throw new Exception("Ya existe un usuario con ese correo");

            entidad._rol = null;
            entidad._cliente = null;
            this.IConexion.Usuarios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Usuarios ActualizarUsuario(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var usuario = this.IConexion.Usuarios!.Find(entidad.Id);
            if (usuario == null)
                throw new Exception("El usuario no existe");

            // Si no se escribe una contraseña nueva, se conserva la actual
            if (String.IsNullOrEmpty(entidad.contrasena))
                entidad.contrasena = usuario.contrasena;

            if (Validaciones.ValidarUsuarios(entidad))
                throw new Exception("Falta Información");
            if (this.IConexion.Usuarios!.Any(x => x.correo == entidad.correo && x.Id != entidad.Id))
                throw new Exception("Ya existe un usuario con ese correo");

            usuario.nombre = entidad.nombre;
            usuario.correo = entidad.correo;
            usuario.contrasena = entidad.contrasena;
            usuario.rol = entidad.rol;
            usuario.cliente = entidad.cliente;

            this.IConexion.Entry(usuario).State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return usuario;
        }

        public Usuarios BorrarUsuario(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var usuario = this.IConexion.Usuarios!.Find(entidad.Id);
            if (usuario == null)
                throw new Exception("El usuario no existe");

            // No dejar el sistema sin ningun administrador
            var rolAdmin = this.IConexion.Roles!.FirstOrDefault(x => x.nombre == "Administrador");
            if (rolAdmin != null && usuario.rol == rolAdmin.Id &&
                this.IConexion.Usuarios!.Count(x => x.rol == rolAdmin.Id) <= 1)
                throw new Exception("No se puede borrar el único administrador");

            this.IConexion.Usuarios!.Remove(usuario);
            this.IConexion.SaveChanges();
            return usuario;
        }

        //-------------- Auditorias (solo consulta) --------------

        public List<Auditorias> ConsultarAuditorias()
        {
            return this.IConexion.Auditorias!
                .OrderByDescending(x => x.fecha)
                .ToList();
        }
    }
}
