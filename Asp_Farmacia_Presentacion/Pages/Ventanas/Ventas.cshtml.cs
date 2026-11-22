using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    public class VentasModel : PageModel
    {
        private IVentasPresentacion IVentasPresentacion;
        private IClientesPresentacion IClientesPresentacion;

        public VentasModel(IVentasPresentacion IVentasPresentacion,
            IClientesPresentacion IClientesPresentacion)
        {
            this.IVentasPresentacion = IVentasPresentacion;
            this.IClientesPresentacion = IClientesPresentacion;
        }

        [BindProperty] public List<Ventas> Lista { get; set; } = new();
        [BindProperty] public List<Clientes> Clientes { get; set; } = new();
        [BindProperty] public Ventas? Actual { get; set; }
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

                var rol = HttpContext.Session.GetString("Rol");
                var todasVentas = this.IVentasPresentacion.ConsultarVentas();

                // Si es cliente, filtra solo sus ventas
                if (rol == "General")
                {
                    var clienteId = HttpContext.Session.GetInt32("ClienteId") ?? 0;
                    Lista = todasVentas.Where(x => x.cliente == clienteId).ToList();
                }
                else
                {
                    Lista = todasVentas;
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
                Formulario = true;
                Actual = new Ventas();
                Clientes = this.IClientesPresentacion.ConsultarClientes();
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
                    Actual = this.IVentasPresentacion.InsertarVenta(Actual!);
                else
                    Actual = this.IVentasPresentacion.ActualizarVenta(Actual!);
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
                Clientes = this.IClientesPresentacion.ConsultarClientes();
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
                this.IVentasPresentacion.BorrarVenta(Actual!);
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
