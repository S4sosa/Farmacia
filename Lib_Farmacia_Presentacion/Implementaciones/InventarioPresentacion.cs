using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;

namespace Lib_Farmacia_Presentacion.implementaciones
{
    public class InventarioPresentacion : IInventarioPresentacion
    {
        private IComunicaciones IComunicaciones;

        public InventarioPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public List<Productos> ConsultarProductos()
        {
            var task = this.IComunicaciones.Ejecutar<List<Productos>>(
                "Inventario/ConsultarProductos",
                null!);
            task.Wait();
            return task.Result;
        }

        public List<Productos> BuscarProducto(Productos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Productos>>(
                "Inventario/BuscarProducto",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Productos InsertarProducto(Productos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validaciones.ValidarProductos(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Productos>(
                "Inventario/InsertarProducto",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Productos ActualizarProducto(Productos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validaciones.ValidarProductos(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Productos>(
                "Inventario/ActualizarProducto",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Productos BorrarProducto(Productos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Productos>(
                "Inventario/BorrarProducto",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Medicamentos> ConsultarMedicamentos()
        {
            var task = this.IComunicaciones.Ejecutar<List<Medicamentos>>(
                "Inventario/ConsultarMedicamentos",
                null!);
            task.Wait();
            return task.Result;
        }

        public Medicamentos InsertarMedicamento(Medicamentos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var task = this.IComunicaciones.Ejecutar<Medicamentos>(
                "Inventario/InsertarMedicamento",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Medicamentos ActualizarMedicamento(Medicamentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Medicamentos>(
                "Inventario/ActualizarMedicamento",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Medicamentos BorrarMedicamento(Medicamentos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Medicamentos>(
                "Inventario/BorrarMedicamento",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Lotes> ConsultarLotes()
        {
            var task = this.IComunicaciones.Ejecutar<List<Lotes>>(
                "Inventario/ConsultarLotes",
                null!);
            task.Wait();
            return task.Result;
        }

        public Lotes InsertarLote(Lotes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validaciones.ValidarLotes(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Lotes>(
                "Inventario/InsertarLote",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Lotes ActualizarLote(Lotes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validaciones.ValidarLotes(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Lotes>(
                "Inventario/ActualizarLote",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Lotes BorrarLote(Lotes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Lotes>(
                "Inventario/BorrarLote",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Inventarios> ConsultarInventarios()
        {
            var task = this.IComunicaciones.Ejecutar<List<Inventarios>>(
                "Inventario/ConsultarInventarios",
                null!);
            task.Wait();
            return task.Result;
        }

        public Inventarios InsertarInventario(Inventarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validaciones.ValidarInventarios(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Inventarios>(
                "Inventario/InsertarInventario",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Inventarios ActualizarInventario(Inventarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            if (Validaciones.ValidarInventarios(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Inventarios>(
                "Inventario/ActualizarInventario",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Inventarios BorrarInventario(Inventarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Inventarios>(
                "Inventario/BorrarInventario",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}
