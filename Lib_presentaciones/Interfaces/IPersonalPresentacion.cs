using Lib_Farmacia_Aplicacion.entidades;

namespace Lib_Farmacia_Presentacion.interfaces
{
    public interface IPersonalPresentacion
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
