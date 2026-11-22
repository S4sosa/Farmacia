using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Farmacia_Presentacion.Pages
{
    public class IndexModel : PageModel
    {
        private IUsuariosPresentacion IUsuariosPresentacion;

        public IndexModel(IUsuariosPresentacion IUsuariosPresentacion)
        {
            this.IUsuariosPresentacion = IUsuariosPresentacion;
        }

        public bool EstaLogueado = false;
        [BindProperty] public string? Correo { get; set; }
        [BindProperty] public string? Contrasena { get; set; }

        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }

        public void OnPostBtClean()
        {
            try
            {
                Correo = string.Empty;
                Contrasena = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(Correo) &&
                    string.IsNullOrEmpty(Contrasena))
                {
                    OnPostBtClean();
                    return;
                }

                // Buscar usuario en la BD
                var credenciales = new CredencialesDto
                {
                    correo = Correo,
                    contrasena = Contrasena
                };

                var usuario = this.IUsuariosPresentacion.BuscarPorCredenciales(credenciales);

                // Registrar auditoría
                var auditoria = new Auditorias
                {
                    correo = Correo,
                    exitoso = usuario != null
                };
                this.IUsuariosPresentacion.RegistrarAuditoria(auditoria);

                if (usuario == null)
                {
                    OnPostBtClean();
                    return;
                }

                // Guardar sesión
                HttpContext.Session.SetString("Usuario", usuario.nombre!);
                HttpContext.Session.SetString("Rol", usuario._rol!.nombre!);
                if (usuario.cliente != null)
                    HttpContext.Session.SetInt32("ClienteId", usuario.cliente.Value);

                EstaLogueado = true;
                OnPostBtClean();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
