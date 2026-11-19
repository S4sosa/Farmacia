using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.entidades
{
    public class Auditorias
    {
        public int Id { get; set; }
        public string? correo { get; set; }
        public DateTime fecha { get; set; }
        public bool exitoso { get; set; }
    }
}
