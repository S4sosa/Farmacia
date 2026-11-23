using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    public class AuditoriasModel : PageModel
    {
        private IUsuariosPresentacion IUsuariosPresentacion;

        public AuditoriasModel(IUsuariosPresentacion IUsuariosPresentacion)
        {
            this.IUsuariosPresentacion = IUsuariosPresentacion;
        }

        [BindProperty] public List<Auditorias> Lista { get; set; } = new();
        [BindProperty] public Auditorias? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        // Filtro opcional por correo
        [BindProperty] public string? FiltroCorreo { get; set; }

        public List<Auditorias> Filtradas =>
            string.IsNullOrWhiteSpace(FiltroCorreo)
                ? Lista
                : Lista.Where(x => (x.correo ?? "").Contains(FiltroCorreo.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();

        // Listas para los desplegables y para mostrar nombres en la tabla






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

                Lista = this.IUsuariosPresentacion.ConsultarAuditorias();

            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
