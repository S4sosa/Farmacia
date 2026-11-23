using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    public class SeguridadModel : PageModel
    {
        private IUsuariosPresentacion IUsuariosPresentacion;
        private IParametrosPresentacion IParametrosPresentacion;
        private IClientesPresentacion IClientesPresentacion;

        public SeguridadModel(IUsuariosPresentacion IUsuariosPresentacion,
            IParametrosPresentacion IParametrosPresentacion,
            IClientesPresentacion IClientesPresentacion)
        {
            this.IUsuariosPresentacion = IUsuariosPresentacion;
            this.IParametrosPresentacion = IParametrosPresentacion;
            this.IClientesPresentacion = IClientesPresentacion;
        }

        [BindProperty] public string TipoSeleccionado { get; set; } = "Usuarios";
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public List<SelectListItem> Tipos { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Usuarios", Text = "Usuarios" },
            new SelectListItem { Value = "Roles", Text = "Roles" },
            new SelectListItem { Value = "Auditorias", Text = "Auditorías" },
        };

        public bool SoloLectura => TipoSeleccionado == "Auditorias";

        // Una lista y un registro actual por cada tabla
        [BindProperty] public List<Usuarios> DatosUsuarios { get; set; } = new();
        [BindProperty] public Usuarios? ActualUsuarios { get; set; }
        [BindProperty] public List<Roles> DatosRoles { get; set; } = new();
        [BindProperty] public Roles? ActualRoles { get; set; }
        [BindProperty] public List<Auditorias> DatosAuditorias { get; set; } = new();
        [BindProperty] public Auditorias? ActualAuditorias { get; set; }

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

        // Estos dos roles los usa el login y el menu: no se editan ni se borran
        public bool EsRolDelSistema(string? nombre) =>
            nombre == "Administrador" || nombre == "General";
        // Filtro opcional por correo (solo para Auditorias)
        [BindProperty] public string? FiltroCorreo { get; set; }

        public List<Auditorias> AuditoriasFiltradas =>
            string.IsNullOrWhiteSpace(FiltroCorreo)
                ? DatosAuditorias
                : DatosAuditorias.Where(x => (x.correo ?? "").Contains(FiltroCorreo.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();

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

                switch (TipoSeleccionado)
                {
                    case "Usuarios":
                        DatosUsuarios = this.IUsuariosPresentacion.ConsultarUsuarios();
                        ListaRoles = this.IParametrosPresentacion.ConsultarRoles();
                        ListaClientes = this.IClientesPresentacion.ConsultarClientes();
                        break;
                    case "Roles":
                        DatosRoles = this.IParametrosPresentacion.ConsultarRoles();
                        break;
                    case "Auditorias":
                        DatosAuditorias = this.IUsuariosPresentacion.ConsultarAuditorias();
                        break;
                }
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
                if (SoloLectura) { OnPostBtConsultar(); return; }
                Formulario = true;
                switch (TipoSeleccionado)
                {
                    case "Usuarios":
                        ActualUsuarios = new Usuarios();
                        break;
                    case "Roles":
                        ActualRoles = new Roles();
                        break;
                }
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
                switch (TipoSeleccionado)
                {
                    case "Usuarios":
                        if (ActualUsuarios!.Id == 0) this.IUsuariosPresentacion.InsertarUsuario(ActualUsuarios!);
                        else this.IUsuariosPresentacion.ActualizarUsuario(ActualUsuarios!);
                        break;
                    case "Roles":
                        if (ActualRoles!.Id == 0) this.IParametrosPresentacion.InsertarRol(ActualRoles!);
                        else this.IParametrosPresentacion.ActualizarRol(ActualRoles!);
                        break;
                }
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
                var id = Convert.ToInt32(data);
                switch (TipoSeleccionado)
                {
                    case "Usuarios":
                        ActualUsuarios = DatosUsuarios.FirstOrDefault(x => x.Id == id);
                        if (ActualUsuarios != null) ActualUsuarios.contrasena = null;   // no se muestra la contraseña
                        break;
                    case "Roles":
                        ActualRoles = DatosRoles.FirstOrDefault(x => x.Id == id);
                        break;
                }
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
                var id = Convert.ToInt32(data);
                switch (TipoSeleccionado)
                {
                    case "Usuarios":
                        ActualUsuarios = DatosUsuarios.FirstOrDefault(x => x.Id == id);
                        break;
                    case "Roles":
                        ActualRoles = DatosRoles.FirstOrDefault(x => x.Id == id);
                        break;
                }
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
                switch (TipoSeleccionado)
                {
                    case "Usuarios":
                        if (ActualUsuarios != null && ActualUsuarios.Id != 0) this.IUsuariosPresentacion.BorrarUsuario(ActualUsuarios!);
                        break;
                    case "Roles":
                        if (ActualRoles != null && ActualRoles.Id != 0) this.IParametrosPresentacion.BorrarRol(ActualRoles!);
                        break;
                }
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
