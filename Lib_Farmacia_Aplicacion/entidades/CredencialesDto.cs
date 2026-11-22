using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.entidades
{

    // DTO (Data Transfer Object) para transportar las credenciales del login.
    // No es una entidad de la BD, no tiene DbSet ni pruebas unitarias.
    // Solo existe para recibir correo y contrasena desde el controller en BuscarPorCredenciales
    public class CredencialesDto
    {
        public string? correo { get; set; }
        public string? contrasena { get; set; }
    }
}