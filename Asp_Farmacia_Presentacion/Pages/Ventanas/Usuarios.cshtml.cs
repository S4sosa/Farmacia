using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    public class UsuariosModel : PageModel
    {
        private IUsuariosPresentacion IUsuariosPresentacion;
        private IParametrosPresentacion IParametrosPresentacion;
        private IClientesPresentacion IClientesPresentacion;

        public UsuariosModel(IUsuariosPresentacion IUsuariosPresentacion,
            IParametrosPresentacion IParametrosPresentacion,
            IClientesPresentacion IClientesPresentacion)
        {
            this.IUsuariosPresentacion = IUsuariosPresentacion;
            this.IParametrosPresentacion = IParametrosPresentacion;
            this.IClientesPresentacion = IClientesPresentacion;
        }

        [BindProperty] public List<Usuarios> Lista { get; set; } = new();
        [BindProperty] public Usuarios? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        // Listas para los desplegables y para mostrar nombres en la tabla
        public List<Roles> ListaRoles { get; set; } = new();
        public List<Clientes> ListaClientes { get; set; } = new();

        public List<SelectListItem> OpcionesRoles =>
            ListaRoles.Select(x => new SelectListItem(x.nombre ?? "", x.Id.ToString())).ToList();
        public List<SelectListItem> OpcionesClientes =>
            ListaClientes.Select(x => new SelectListItem((x._persona?.nombre ?? "") + " " + (x._persona?.apellidos ?? ""), x.Id.ToString())).ToList();

        public string NombreRoles(int? id) =>
            ListaRoles.Where(x => x.Id == id).Select(x => x.nombre ?? "").FirstOrDefault() ?? "";
        public string NombreClientes(int? id) =>
            ListaClientes.Where(x => x.Id == id).Select(x => (x._persona?.nombre ?? "") + " " + (x._persona?.apellidos ?? "")).FirstOrDefault() ?? "";

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

                Lista = this.IUsuariosPresentacion.ConsultarUsuarios();
                ListaRoles = this.IParametrosPresentacion.ConsultarRoles();
                ListaClientes = this.IClientesPresentacion.ConsultarClientes();
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
                Actual = new Usuarios();
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
                    Actual = this.IUsuariosPresentacion.InsertarUsuario(Actual!);
                else
                    Actual = this.IUsuariosPresentacion.ActualizarUsuario(Actual!);
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
                if (Actual != null) Actual.contrasena = null;   // no se muestra la contraseña
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
                this.IUsuariosPresentacion.BorrarUsuario(Actual!);
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
