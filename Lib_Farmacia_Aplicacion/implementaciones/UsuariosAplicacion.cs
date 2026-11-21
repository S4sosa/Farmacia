using Lib_Farmacia_Aplicacion.interfaces;
using Lib_Farmacia_Aplicacion.entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Lib_Farmacia_Aplicacion.implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private IConexion IConexion;

        public UsuariosAplicacion(IConexion Iconexion)
        {
            this.IConexion = Iconexion;
        }

        public Usuarios? BuscarPorCredenciales(String correo, String contrasena) //Estudiar este metodo
        {
            return this.IConexion.Usuarios!
                .Include(x => x._rol) // se verifica el rol
                .Include(x => x._cliente) // se traen los datos del cliente que incio sesion(si es cliente)
                .FirstOrDefault(x => x.correo == correo && x.contrasena == contrasena); //se verifica correo y contraseña
                                                                                        //-- Se verifican datos planos en la bd
                                                                                        //pero para este proyecto lo dejaremos asi
        }

        public Auditorias RegistrarAuditoria(Auditorias entidad)
        {
            entidad.fecha = DateTime.Now;
            this.IConexion.Auditorias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad; 
        }
    }
}
