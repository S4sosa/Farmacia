using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lib_Farmacia_Aplicacion.implementaciones
{
    public class ProductosAplicacion : IProductosAplicacion
    {
        private IConexion IConexion;

        public ProductosAplicacion(IConexion Iconexion)
        {
            this.IConexion = Iconexion;
        }

        public List<Productos> ConsultarProductos()
        { 
            return this.IConexion.Productos!
                .Include(x => x._categoria)
                .ToList();
        }

        public List<Productos> BuscarProducto(string nombre)
        {
            return this.IConexion.Productos!
                .Include(x => x._categoria)
                .Where(x => x.nombre != null && x.nombre.Contains(nombre))
                .ToList();
        }
    }
}
