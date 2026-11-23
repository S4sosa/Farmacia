using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    public class PersonalModel : PageModel
    {
        private IPersonalPresentacion IPersonalPresentacion;
        private IParametrosPresentacion IParametrosPresentacion;

        public PersonalModel(IPersonalPresentacion IPersonalPresentacion,
            IParametrosPresentacion IParametrosPresentacion)
        {
            this.IPersonalPresentacion = IPersonalPresentacion;
            this.IParametrosPresentacion = IParametrosPresentacion;
        }

        [BindProperty] public List<Empleados> Lista { get; set; } = new();
        [BindProperty] public List<Cargos> Cargos { get; set; } = new();
        [BindProperty] public Personas? ActualPersona { get; set; }
        [BindProperty] public Empleados? ActualEmpleado { get; set; }
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

                Lista = this.IPersonalPresentacion.ConsultarEmpleados();
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
                ActualEmpleado = new Empleados();
                Cargos = this.IParametrosPresentacion.ConsultarCargos();
                Lista = this.IPersonalPresentacion.ConsultarEmpleados();
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
                    // Insertar persona primero, luego empleado
                    ActualPersona = this.IPersonalPresentacion.InsertarPersona(ActualPersona!);
                    ActualEmpleado!.persona = ActualPersona.Id;
                    ActualEmpleado = this.IPersonalPresentacion.InsertarEmpleado(ActualEmpleado!);
                }
                else
                {
                    ActualPersona = this.IPersonalPresentacion.ActualizarPersona(ActualPersona!);
                    ActualEmpleado!.persona = ActualPersona.Id;          // ← agregar esta línea
                    ActualEmpleado = this.IPersonalPresentacion.ActualizarEmpleado(ActualEmpleado!);
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
                ActualEmpleado = Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
                ActualPersona = ActualEmpleado?._persona;
                Cargos = this.IParametrosPresentacion.ConsultarCargos();
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
                ActualEmpleado = Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
                ActualPersona = ActualEmpleado?._persona;
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
                if (ActualEmpleado!.Id == 0) return;
                // Borrar empleado primero, luego persona
                this.IPersonalPresentacion.BorrarEmpleado(ActualEmpleado!);
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
    }
}
