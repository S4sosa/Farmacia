using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    public class MedicamentosModel : PageModel
    {
        private IInventarioPresentacion IInventarioPresentacion;
        private IParametrosPresentacion IParametrosPresentacion;

        public MedicamentosModel(IInventarioPresentacion IInventarioPresentacion,
            IParametrosPresentacion IParametrosPresentacion)
        {
            this.IInventarioPresentacion = IInventarioPresentacion;
            this.IParametrosPresentacion = IParametrosPresentacion;
        }

        [BindProperty] public List<Medicamentos> Lista { get; set; } = new();
        [BindProperty] public Medicamentos? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        // Listas para los desplegables y para mostrar nombres en la tabla
        public List<Productos> ListaProductos { get; set; } = new();
        public List<Presentaciones> ListaPresentaciones { get; set; } = new();

        public List<SelectListItem> OpcionesProductos =>
            ListaProductos.Select(x => new SelectListItem(x.nombre ?? "", x.Id.ToString())).ToList();
        public List<SelectListItem> OpcionesPresentaciones =>
            ListaPresentaciones.Select(x => new SelectListItem(x.nombre ?? "", x.Id.ToString())).ToList();

        public string NombreProductos(int? id) =>
            ListaProductos.Where(x => x.Id == id).Select(x => x.nombre ?? "").FirstOrDefault() ?? "";
        public string NombrePresentaciones(int? id) =>
            ListaPresentaciones.Where(x => x.Id == id).Select(x => x.nombre ?? "").FirstOrDefault() ?? "";

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

                Lista = this.IInventarioPresentacion.ConsultarMedicamentos();
                ListaProductos = this.IInventarioPresentacion.ConsultarProductos();
                ListaPresentaciones = this.IParametrosPresentacion.ConsultarPresentaciones();
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
                Actual = new Medicamentos();
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
                    Actual = this.IInventarioPresentacion.InsertarMedicamento(Actual!);
                else
                    Actual = this.IInventarioPresentacion.ActualizarMedicamento(Actual!);
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
                this.IInventarioPresentacion.BorrarMedicamento(Actual!);
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
