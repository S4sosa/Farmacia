using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Presentacion.interfaces;

namespace Lib_Farmacia_Presentacion.implementaciones
{
    public class ParametrosPresentacion : IParametrosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ParametrosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public List<Cargos> ConsultarCargos()
        {
            var task = this.IComunicaciones.Ejecutar<List<Cargos>>(
                "Parametros/ConsultarCargos",
                null!);
            task.Wait();
            return task.Result;
        }

        public Cargos InsertarCargo(Cargos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var task = this.IComunicaciones.Ejecutar<Cargos>(
                "Parametros/InsertarCargo",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Cargos ActualizarCargo(Cargos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Cargos>(
                "Parametros/ActualizarCargo",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Cargos BorrarCargo(Cargos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Cargos>(
                "Parametros/BorrarCargo",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Categorias> ConsultarCategorias()
        {
            var task = this.IComunicaciones.Ejecutar<List<Categorias>>(
                "Parametros/ConsultarCategorias",
                null!);
            task.Wait();
            return task.Result;
        }

        public Categorias InsertarCategoria(Categorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var task = this.IComunicaciones.Ejecutar<Categorias>(
                "Parametros/InsertarCategoria",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Categorias ActualizarCategoria(Categorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Categorias>(
                "Parametros/ActualizarCategoria",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Categorias BorrarCategoria(Categorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Categorias>(
                "Parametros/BorrarCategoria",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Presentaciones> ConsultarPresentaciones()
        {
            var task = this.IComunicaciones.Ejecutar<List<Presentaciones>>(
                "Parametros/ConsultarPresentaciones",
                null!);
            task.Wait();
            return task.Result;
        }

        public Presentaciones InsertarPresentacion(Presentaciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var task = this.IComunicaciones.Ejecutar<Presentaciones>(
                "Parametros/InsertarPresentacion",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Presentaciones ActualizarPresentacion(Presentaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Presentaciones>(
                "Parametros/ActualizarPresentacion",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Presentaciones BorrarPresentacion(Presentaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Presentaciones>(
                "Parametros/BorrarPresentacion",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<MetodosPagos> ConsultarMetodosPagos()
        {
            var task = this.IComunicaciones.Ejecutar<List<MetodosPagos>>(
                "Parametros/ConsultarMetodosPagos",
                null!);
            task.Wait();
            return task.Result;
        }

        public MetodosPagos InsertarMetodoPago(MetodosPagos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var task = this.IComunicaciones.Ejecutar<MetodosPagos>(
                "Parametros/InsertarMetodoPago",
                entidad);
            task.Wait();
            return task.Result;
        }

        public MetodosPagos ActualizarMetodoPago(MetodosPagos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<MetodosPagos>(
                "Parametros/ActualizarMetodoPago",
                entidad);
            task.Wait();
            return task.Result;
        }

        public MetodosPagos BorrarMetodoPago(MetodosPagos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<MetodosPagos>(
                "Parametros/BorrarMetodoPago",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Laboratorios> ConsultarLaboratorios()
        {
            var task = this.IComunicaciones.Ejecutar<List<Laboratorios>>(
                "Parametros/ConsultarLaboratorios",
                null!);
            task.Wait();
            return task.Result;
        }

        public Laboratorios InsertarLaboratorio(Laboratorios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var task = this.IComunicaciones.Ejecutar<Laboratorios>(
                "Parametros/InsertarLaboratorio",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Laboratorios ActualizarLaboratorio(Laboratorios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Laboratorios>(
                "Parametros/ActualizarLaboratorio",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Laboratorios BorrarLaboratorio(Laboratorios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Laboratorios>(
                "Parametros/BorrarLaboratorio",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Roles> ConsultarRoles()
        {
            var task = this.IComunicaciones.Ejecutar<List<Roles>>(
                "Parametros/ConsultarRoles",
                null!);
            task.Wait();
            return task.Result;
        }
    }
}
