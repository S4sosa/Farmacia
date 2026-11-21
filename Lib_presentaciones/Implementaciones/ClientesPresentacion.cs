using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Presentacion.interfaces;

namespace Lib_Farmacia_Presentacion.implementaciones
{
    public class ClientesPresentacion : IClientesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ClientesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public List<Clientes> ConsultarClientes()
        {
            var task = this.IComunicaciones.Ejecutar<List<Clientes>>(
                "Clientes/ConsultarClientes",
                null!);
            task.Wait();
            return task.Result;
        }

        public List<Clientes> BuscarCliente(Clientes entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Clientes>>(
                "Clientes/BuscarCliente",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Clientes InsertarCliente(Clientes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var task = this.IComunicaciones.Ejecutar<Clientes>(
                "Clientes/InsertarCliente",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Clientes ActualizarCliente(Clientes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Clientes>(
                "Clientes/ActualizarCliente",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Clientes BorrarCliente(Clientes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Clientes>(
                "Clientes/BorrarCliente",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Recetas> ConsultarRecetas()
        {
            var task = this.IComunicaciones.Ejecutar<List<Recetas>>(
                "Clientes/ConsultarRecetas",
                null!);
            task.Wait();
            return task.Result;
        }

        public Recetas InsertarReceta(Recetas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var task = this.IComunicaciones.Ejecutar<Recetas>(
                "Clientes/InsertarReceta",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Recetas ActualizarReceta(Recetas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Recetas>(
                "Clientes/ActualizarReceta",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Recetas BorrarReceta(Recetas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Recetas>(
                "Clientes/BorrarReceta",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesRecetas> ConsultarDetallesRecetas()
        {
            var task = this.IComunicaciones.Ejecutar<List<DetallesRecetas>>(
                "Clientes/ConsultarDetallesRecetas",
                null!);
            task.Wait();
            return task.Result;
        }

        public DetallesRecetas InsertarDetallesReceta(DetallesRecetas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var task = this.IComunicaciones.Ejecutar<DetallesRecetas>(
                "Clientes/InsertarDetallesReceta",
                entidad);
            task.Wait();
            return task.Result;
        }

        public DetallesRecetas ActualizarDetallesReceta(DetallesRecetas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<DetallesRecetas>(
                "Clientes/ActualizarDetallesReceta",
                entidad);
            task.Wait();
            return task.Result;
        }

        public DetallesRecetas BorrarDetallesReceta(DetallesRecetas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<DetallesRecetas>(
                "Clientes/BorrarDetallesReceta",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}