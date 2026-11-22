using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Presentacion.interfaces;

namespace Lib_Farmacia_Presentacion.implementaciones
{
    public class ProductosPresentacion : IProductosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ProductosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public List<Productos> ConsultarProductos()
        {
            var task = this.IComunicaciones.Ejecutar<List<Productos>>(
                "Productos/ConsultarProductos",
                null!);
            task.Wait();
            return task.Result;
        }
    }
}
