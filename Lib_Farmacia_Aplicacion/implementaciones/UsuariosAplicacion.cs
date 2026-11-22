using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
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
    }
}
