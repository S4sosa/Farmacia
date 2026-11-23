using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    public class DetallesRecetasModel : PageModel
    {
        private IClientesPresentacion IClientesPresentacion;
        private IInventarioPresentacion IInventarioPresentacion;

        public DetallesRecetasModel(IClientesPresentacion IClientesPresentacion,
            IInventarioPresentacion IInventarioPresentacion)
        {
            this.IClientesPresentacion = IClientesPresentacion;
            this.IInventarioPresentacion = IInventarioPresentacion;
        }

        [BindProperty] public List<DetallesRecetas> Lista { get; set; } = new();
        [BindProperty] public DetallesRecetas? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        // Listas para los desplegables y para mostrar nombres en la tabla
        public List<Recetas> ListaRecetas { get; set; } = new();
        public List<Medicamentos> ListaMedicamentos { get; set; } = new();

        public List<SelectListItem> OpcionesRecetas =>
            ListaRecetas.Select(x => new SelectListItem("#" + x.Id + " - " + (x._cliente?._persona?.nombre ?? "") + " " + (x._cliente?._persona?.apellidos ?? "") + " - " + x.medicoNombre, x.Id.ToString())).ToList();
        public List<SelectListItem> OpcionesMedicamentos =>
            ListaMedicamentos.Select(x => new SelectListItem((x._producto?.nombre ?? "") + " (" + (x._presentacion?.nombre ?? "") + ")", x.Id.ToString())).ToList();

        public string NombreRecetas(int? id) =>
            ListaRecetas.Where(x => x.Id == id).Select(x => "#" + x.Id + " - " + (x._cliente?._persona?.nombre ?? "") + " " + (x._cliente?._persona?.apellidos ?? "") + " - " + x.medicoNombre).FirstOrDefault() ?? "";
        public string NombreMedicamentos(int? id) =>
            ListaMedicamentos.Where(x => x.Id == id).Select(x => (x._producto?.nombre ?? "") + " (" + (x._presentacion?.nombre ?? "") + ")").FirstOrDefault() ?? "";

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

                Lista = this.IClientesPresentacion.ConsultarDetallesRecetas();
                ListaRecetas = this.IClientesPresentacion.ConsultarRecetas();
                ListaMedicamentos = this.IInventarioPresentacion.ConsultarMedicamentos();
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
                Actual = new DetallesRecetas();
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
                    Actual = this.IClientesPresentacion.InsertarDetallesReceta(Actual!);
                else
                    Actual = this.IClientesPresentacion.ActualizarDetallesReceta(Actual!);
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
                this.IClientesPresentacion.BorrarDetallesReceta(Actual!);
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
