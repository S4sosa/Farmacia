using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    public class ClientesModel : PageModel
    {
        private IClientesPresentacion IClientesPresentacion;
        private IPersonalPresentacion IPersonalPresentacion;

        public ClientesModel(IClientesPresentacion IClientesPresentacion,
            IPersonalPresentacion IPersonalPresentacion)
        {
            this.IClientesPresentacion = IClientesPresentacion;
            this.IPersonalPresentacion = IPersonalPresentacion;
        }

        [BindProperty] public List<Clientes> Lista { get; set; } = new();
        [BindProperty] public List<Clientes> ListaClientes { get; set; } = new();
        [BindProperty] public List<Recetas> ListaRecetas { get; set; } = new();
        [BindProperty] public Personas? ActualPersona { get; set; }
        [BindProperty] public Clientes? ActualCliente { get; set; }
        [BindProperty] public Recetas? ActualReceta { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool FormularioReceta { get; set; } = false;
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

                Lista = this.IClientesPresentacion.ConsultarClientes();
                ListaRecetas = this.IClientesPresentacion.ConsultarRecetas();
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
                ActualPersona = new Personas();
                ActualCliente = new Clientes();
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
                if (ActualPersona!.Id == 0)
                {
                    ActualPersona = this.IPersonalPresentacion.InsertarPersona(ActualPersona!);
                    ActualCliente!.persona = ActualPersona.Id;
                    ActualCliente = this.IClientesPresentacion.InsertarCliente(ActualCliente!);
                }
                else
                {
                    ActualPersona = this.IPersonalPresentacion.ActualizarPersona(ActualPersona!);
                    ActualCliente = this.IClientesPresentacion.ActualizarCliente(ActualCliente!);
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
                ActualCliente = Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
                ActualPersona = ActualCliente?._persona;
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
                ActualCliente = Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
                ActualPersona = ActualCliente?._persona;
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
                if (ActualCliente!.Id == 0) return;
                this.IClientesPresentacion.BorrarCliente(ActualCliente!);
                this.IPersonalPresentacion.BorrarPersona(ActualPersona!);
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

        // ── RECETAS ──────────────────────────────────────────
        public void OnPostBtNuevaReceta()
        {
            try
            {
                FormularioReceta = true;
                ActualReceta = new Recetas();
                ActualReceta.fechaEmision = DateTime.Today;   // ← agregar aquí
                ListaClientes = this.IClientesPresentacion.ConsultarClientes();
                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtGuardarReceta()
        {
            try
            {
                if (ActualReceta!.Id == 0)
                    ActualReceta = this.IClientesPresentacion.InsertarReceta(ActualReceta!);
                else
                    ActualReceta = this.IClientesPresentacion.ActualizarReceta(ActualReceta!);
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

        public void OnPostBtEditarReceta(string data)
        {
            try
            {
                FormularioReceta = true;
                OnPostBtConsultar();
                ActualReceta = ListaRecetas.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
                ActualReceta ??= new Recetas();               // ← agregar aquí
                ListaClientes = this.IClientesPresentacion.ConsultarClientes();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtBorrarReceta(string data)
        {
            try
            {
                OnPostBtConsultar();
                var receta = ListaRecetas.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
                if (receta != null)
                    this.IClientesPresentacion.BorrarReceta(receta);
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
