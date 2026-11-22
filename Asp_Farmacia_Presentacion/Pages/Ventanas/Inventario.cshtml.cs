using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    public class InventarioModel : PageModel
    {
        private IInventarioPresentacion IInventarioPresentacion;
        private IParametrosPresentacion IParametrosPresentacion;

        public InventarioModel(IInventarioPresentacion IInventarioPresentacion,
            IParametrosPresentacion IParametrosPresentacion)
        {
            this.IInventarioPresentacion = IInventarioPresentacion;
            this.IParametrosPresentacion = IParametrosPresentacion;
            this.Filtro = new Productos();
        }

        [BindProperty] public List<Productos> Lista { get; set; } = new();
        [BindProperty] public List<Categorias> Categorias { get; set; } = new();
        [BindProperty] public Productos? Actual { get; set; }
        [BindProperty] public Productos? Filtro { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

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

                if (!string.IsNullOrEmpty(Filtro?.nombre))
                    Lista = this.IInventarioPresentacion.BuscarProducto(Filtro!);
                else
                    Lista = this.IInventarioPresentacion.ConsultarProductos();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Formulario = true;
                Actual = new Productos();
                Categorias = this.IParametrosPresentacion.ConsultarCategorias();
                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Actual!.Id == 0)
                    Actual = this.IInventarioPresentacion.InsertarProducto(Actual!);
                else
                    Actual = this.IInventarioPresentacion.ActualizarProducto(Actual!);
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

        public void OnPostBtEditar(string data)
        {
            try
            {
                Formulario = true;
                OnPostBtConsultar();
                Actual = Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
                Categorias = this.IParametrosPresentacion.ConsultarCategorias();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtPregBorrar(string data)
        {
            try
            {
                Borrar = true;
                OnPostBtConsultar();
                Actual = Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Actual!.Id == 0) return;
                this.IInventarioPresentacion.BorrarProducto(Actual!);
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
