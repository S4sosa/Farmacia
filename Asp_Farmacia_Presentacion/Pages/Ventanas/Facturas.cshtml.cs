using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    public class FacturasModel : PageModel
    {
        private IVentasPresentacion IVentasPresentacion;
        private IParametrosPresentacion IParametrosPresentacion;

        public FacturasModel(IVentasPresentacion IVentasPresentacion,
            IParametrosPresentacion IParametrosPresentacion)
        {
            this.IVentasPresentacion = IVentasPresentacion;
            this.IParametrosPresentacion = IParametrosPresentacion;
        }

        [BindProperty] public List<Facturas> Lista { get; set; } = new();
        [BindProperty] public Facturas? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public decimal TotalVenta(int id) =>
            ListaVentas.Where(x => x.Id == id).Select(x => x.total).FirstOrDefault();

        // Listas para los desplegables y para mostrar nombres en la tabla
        public List<Ventas> ListaVentas { get; set; } = new();
        public List<MetodosPagos> ListaMetodosPagos { get; set; } = new();

        public List<SelectListItem> OpcionesVentas =>
            ListaVentas.Select(x => new SelectListItem("#" + x.Id + " - " + (x._cliente?._persona?.nombre ?? "") + " " + (x._cliente?._persona?.apellidos ?? "") + " - " + x.fecha.ToShortDateString(), x.Id.ToString())).ToList();
        public List<SelectListItem> OpcionesMetodosPagos =>
            ListaMetodosPagos.Select(x => new SelectListItem(x.nombre ?? "", x.Id.ToString())).ToList();

        public string NombreVentas(int? id) =>
            ListaVentas.Where(x => x.Id == id).Select(x => "#" + x.Id + " - " + (x._cliente?._persona?.nombre ?? "") + " " + (x._cliente?._persona?.apellidos ?? "") + " - " + x.fecha.ToShortDateString()).FirstOrDefault() ?? "";
        public string NombreMetodosPagos(int? id) =>
            ListaMetodosPagos.Where(x => x.Id == id).Select(x => x.nombre ?? "").FirstOrDefault() ?? "";

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

                Lista = this.IVentasPresentacion.ConsultarFacturas();
                ListaVentas = this.IVentasPresentacion.ConsultarVentas();
                ListaMetodosPagos = this.IParametrosPresentacion.ConsultarMetodosPagos();
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
                Actual = new Facturas();
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
                    Actual = this.IVentasPresentacion.InsertarFactura(Actual!);
                else
                    Actual = this.IVentasPresentacion.ActualizarFactura(Actual!);
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
                this.IVentasPresentacion.BorrarFactura(Actual!);
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
