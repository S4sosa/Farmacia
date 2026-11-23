using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    public class ProductosModel : PageModel
    {
        private IProductosPresentacion IProductosPresentacion;
        private IVentasPresentacion IVentasPresentacion;

        public ProductosModel(IProductosPresentacion IProductosPresentacion,
            IVentasPresentacion IVentasPresentacion)
        {
            this.IProductosPresentacion = IProductosPresentacion;
            this.IVentasPresentacion = IVentasPresentacion;
            this.Filtro = new Productos();
        }

        [BindProperty] public List<Productos> Lista { get; set; } = new();
        [BindProperty] public Productos? Filtro { get; set; }

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                var usuario = HttpContext.Session.GetString("Usuario");
                var rol = HttpContext.Session.GetString("Rol");

                if (string.IsNullOrEmpty(usuario))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                if(rol != "General")
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                var nombre = Filtro?.nombre;

                if (!string.IsNullOrWhiteSpace(nombre))
                    Lista = this.IProductosPresentacion.BuscarProducto(nombre);
                else
                    Lista = this.IProductosPresentacion.ConsultarProductos();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtComprar(string data)
        {
            try
            {
                //validacion de rol antes de comprar
                var usuario = HttpContext.Session.GetString("Usuario");
                var rol = HttpContext.Session.GetString("Rol");

                if (String.IsNullOrEmpty(usuario) || rol != "General")
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                // Solo un cliente logueado puede comprar
                var clienteId = HttpContext.Session.GetInt32("ClienteId") ?? 0;
                if (clienteId == 0)
                    throw new Exception("Solo los clientes pueden comprar");

                // Buscar el producto que se eligió
                OnPostBtConsultar();
                var productoId = Convert.ToInt32(data);
                var producto = Lista.FirstOrDefault(x => x.Id == productoId);
                if (producto == null)
                    throw new Exception("Producto no encontrado");

                // Cantidad escrita en la fila del producto
                int.TryParse(Request.Form["cantidad_" + data], out int cantidad);
                if (cantidad <= 0)
                    throw new Exception("La cantidad debe ser mayor a 0");

                // 1. Crear la venta
                var venta = new Ventas
                {
                    cliente = clienteId,
                    total = producto.precio * cantidad
                };
                venta = this.IVentasPresentacion.InsertarVenta(venta);

                // 2. Crear el detalle de la venta
                var detalle = new DetallesVentas
                {
                    venta = venta.Id,
                    producto = producto.Id,
                    cantidad = cantidad
                };
                this.IVentasPresentacion.InsertarDetallesVenta(detalle);

                ViewData["Mensaje"] = "Compra realizada: " + cantidad + " x " + producto.nombre;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }
    }
}