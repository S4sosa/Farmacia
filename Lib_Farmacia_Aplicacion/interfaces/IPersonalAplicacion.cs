using Lib_Farmacia_Aplicacion.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Farmacia_Aplicacion.interfaces
{
    public interface IPersonalAplicacion
    {
        List<Personas> ConsultarPersonas();
        Personas InsertarPersona(Personas entidad);
        Personas ActualizarPersona(Personas entidad);
        Personas BorrarPersona(Personas entidad);

        List<Empleados> ConsultarEmpleados();
        Empleados InsertarEmpleado(Empleados entidad);
        Empleados ActualizarEmpleado(Empleados entidad);
        Empleados BorrarEmpleado(Empleados entidad);
    }
}
