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

        public ProductosModel(IProductosPresentacion IProductosPresentacion)
        {
            this.IProductosPresentacion = IProductosPresentacion;
            this.Filtro = new Productos();
        }

        [BindProperty] public List<Productos> Lista { get; set; } = new();
        [BindProperty] public Productos? Filtro { get; set; }

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (String.IsNullOrEmpty(variable_session))
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
    }
}
