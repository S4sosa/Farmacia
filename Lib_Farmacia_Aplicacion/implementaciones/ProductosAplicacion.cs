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

        public List<Productos> ConsultarProductos(Productos entidad)
        { 
            return this.IConexion.Productos!
                .Include(x => x._categoria)
                .ToList();
        }
    }
}
