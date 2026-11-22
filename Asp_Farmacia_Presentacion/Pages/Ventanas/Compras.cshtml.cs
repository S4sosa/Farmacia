using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    public class ComprasModel : PageModel
    {
        private IComprasPresentacion IComprasPresentacion;
        private IParametrosPresentacion IParametrosPresentacion;

        public ComprasModel(IComprasPresentacion IComprasPresentacion,
            IParametrosPresentacion IParametrosPresentacion)
        {
            this.IComprasPresentacion = IComprasPresentacion;
            this.IParametrosPresentacion = IParametrosPresentacion;
        }

        [BindProperty] public List<Compras> Lista { get; set; } = new();
        [BindProperty] public List<Laboratorios> Laboratorios { get; set; } = new();
        [BindProperty] public Compras? Actual { get; set; }
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

                Lista = this.IComprasPresentacion.ConsultarCompras();
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
                Actual = new Compras();
                Laboratorios = this.IParametrosPresentacion.ConsultarLaboratorios();
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
                    Actual = this.IComprasPresentacion.InsertarCompra(Actual!);
                else
                    Actual = this.IComprasPresentacion.ActualizarCompra(Actual!);
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
                Laboratorios = this.IParametrosPresentacion.ConsultarLaboratorios();
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
                this.IComprasPresentacion.BorrarCompra(Actual!);
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
