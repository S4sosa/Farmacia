using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Presentacion.interfaces;

namespace Lib_Farmacia_Presentacion.implementaciones
{
    public class PersonalPresentacion : IPersonalPresentacion
    {
        private IComunicaciones IComunicaciones;

        public PersonalPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public List<Personas> ConsultarPersonas()
        {
            var task = this.IComunicaciones.Ejecutar<List<Personas>>(
                "Personal/ConsultarPersonas",
                null!);
            task.Wait();
            return task.Result;
        }

        public Personas InsertarPersona(Personas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var task = this.IComunicaciones.Ejecutar<Personas>(
                "Personal/InsertarPersona",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Personas ActualizarPersona(Personas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Personas>(
                "Personal/ActualizarPersona",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Personas BorrarPersona(Personas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Personas>(
                "Personal/BorrarPersona",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Empleados> ConsultarEmpleados()
        {
            var task = this.IComunicaciones.Ejecutar<List<Empleados>>(
                "Personal/ConsultarEmpleados",
                null!);
            task.Wait();
            return task.Result;
        }

        public Empleados InsertarEmpleado(Empleados entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var task = this.IComunicaciones.Ejecutar<Empleados>(
                "Personal/InsertarEmpleado",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Empleados ActualizarEmpleado(Empleados entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Empleados>(
                "Personal/ActualizarEmpleado",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Empleados BorrarEmpleado(Empleados entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Empleados>(
                "Personal/BorrarEmpleado",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}
