using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    public class LotesModel : PageModel
    {
        private IInventarioPresentacion IInventarioPresentacion;

        public LotesModel(IInventarioPresentacion IInventarioPresentacion)
        {
            this.IInventarioPresentacion = IInventarioPresentacion;
        }

        [BindProperty] public List<Lotes> Lista { get; set; } = new();
        [BindProperty] public Lotes? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        // Listas para los desplegables y para mostrar nombres en la tabla
        public List<Productos> ListaProductos { get; set; } = new();

        public List<SelectListItem> OpcionesProductos =>
            ListaProductos.Select(x => new SelectListItem(x.nombre ?? "", x.Id.ToString())).ToList();

        public string NombreProductos(int? id) =>
            ListaProductos.Where(x => x.Id == id).Select(x => x.nombre ?? "").FirstOrDefault() ?? "";

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                // Solo el administrador puede entrar a esta ventana
                var rol = HttpContext.Session.GetString("Rol");
                if (rol != "Administrador")
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Lista = this.IInventarioPresentacion.ConsultarLotes();
                ListaProductos = this.IInventarioPresentacion.ConsultarProductos();
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
                Actual = new Lotes { fechaVencimiento = DateTime.Today.AddYears(1) };
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
                    Actual = this.IInventarioPresentacion.InsertarLote(Actual!);
                else
                    Actual = this.IInventarioPresentacion.ActualizarLote(Actual!);
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
                if (Actual == null || Actual.Id == 0) return;
                this.IInventarioPresentacion.BorrarLote(Actual!);
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
