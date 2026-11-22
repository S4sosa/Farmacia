using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    // Clase auxiliar para unificar las tablas maestras en una sola lista
    public class ParametroItem
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }

    public class ParametrosModel : PageModel
    {
        private IParametrosPresentacion IParametrosPresentacion;

        public ParametrosModel(IParametrosPresentacion IParametrosPresentacion)
        {
            this.IParametrosPresentacion = IParametrosPresentacion;
        }

        [BindProperty] public List<ParametroItem> Lista { get; set; } = new();
        [BindProperty] public ParametroItem? Actual { get; set; }
        [BindProperty] public string TipoSeleccionado { get; set; } = "Cargos";
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public List<SelectListItem> Tipos { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Cargos", Text = "Cargos" },
            new SelectListItem { Value = "Categorias", Text = "Categorías" },
            new SelectListItem { Value = "Presentaciones", Text = "Presentaciones" },
            new SelectListItem { Value = "MetodosPagos", Text = "Métodos de Pago" },
            new SelectListItem { Value = "Laboratorios", Text = "Laboratorios" },
            new SelectListItem { Value = "Roles", Text = "Roles" },
        };

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

                Lista = CargarLista();
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
                Actual = new ParametroItem();
                Lista = CargarLista();
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
                    case "Cargos":
                        var cargo = new Lib_Farmacia_Aplicacion.entidades.Cargos { Id = Actual!.Id, nombre = Actual.Nombre };
                        if (cargo.Id == 0) IParametrosPresentacion.InsertarCargo(cargo);
                        else IParametrosPresentacion.ActualizarCargo(cargo);
                        break;
                    case "Categorias":
                        var categoria = new Lib_Farmacia_Aplicacion.entidades.Categorias { Id = Actual!.Id, nombre = Actual.Nombre };
                        if (categoria.Id == 0) IParametrosPresentacion.InsertarCategoria(categoria);
                        else IParametrosPresentacion.ActualizarCategoria(categoria);
                        break;
                    case "Presentaciones":
                        var presentacion = new Lib_Farmacia_Aplicacion.entidades.Presentaciones { Id = Actual!.Id, nombre = Actual.Nombre };
                        if (presentacion.Id == 0) IParametrosPresentacion.InsertarPresentacion(presentacion);
                        else IParametrosPresentacion.ActualizarPresentacion(presentacion);
                        break;
                    case "MetodosPagos":
                        var metodo = new Lib_Farmacia_Aplicacion.entidades.MetodosPagos { Id = Actual!.Id, nombre = Actual.Nombre };
                        if (metodo.Id == 0) IParametrosPresentacion.InsertarMetodoPago(metodo);
                        else IParametrosPresentacion.ActualizarMetodoPago(metodo);
                        break;
                    case "Laboratorios":
                        var laboratorio = new Lib_Farmacia_Aplicacion.entidades.Laboratorios { Id = Actual!.Id, nombre = Actual.Nombre };
                        if (laboratorio.Id == 0) IParametrosPresentacion.InsertarLaboratorio(laboratorio);
                        else IParametrosPresentacion.ActualizarLaboratorio(laboratorio);
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
                Lista = CargarLista();
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
                Lista = CargarLista();
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

                switch (TipoSeleccionado)
                {
                    case "Cargos":
                        IParametrosPresentacion.BorrarCargo(new Lib_Farmacia_Aplicacion.entidades.Cargos { Id = Actual.Id, nombre = Actual.Nombre });
                        break;
                    case "Categorias":
                        IParametrosPresentacion.BorrarCategoria(new Lib_Farmacia_Aplicacion.entidades.Categorias { Id = Actual.Id, nombre = Actual.Nombre });
                        break;
                    case "Presentaciones":
                        IParametrosPresentacion.BorrarPresentacion(new Lib_Farmacia_Aplicacion.entidades.Presentaciones { Id = Actual.Id, nombre = Actual.Nombre });
                        break;
                    case "MetodosPagos":
                        IParametrosPresentacion.BorrarMetodoPago(new Lib_Farmacia_Aplicacion.entidades.MetodosPagos { Id = Actual.Id, nombre = Actual.Nombre });
                        break;
                    case "Laboratorios":
                        IParametrosPresentacion.BorrarLaboratorio(new Lib_Farmacia_Aplicacion.entidades.Laboratorios { Id = Actual.Id, nombre = Actual.Nombre });
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

        private List<ParametroItem> CargarLista()
        {
            return TipoSeleccionado switch
            {
                "Cargos" => IParametrosPresentacion.ConsultarCargos().Select(x => new ParametroItem { Id = x.Id, Nombre = x.nombre }).ToList(),
                "Categorias" => IParametrosPresentacion.ConsultarCategorias().Select(x => new ParametroItem { Id = x.Id, Nombre = x.nombre }).ToList(),
                "Presentaciones" => IParametrosPresentacion.ConsultarPresentaciones().Select(x => new ParametroItem { Id = x.Id, Nombre = x.nombre }).ToList(),
                "MetodosPagos" => IParametrosPresentacion.ConsultarMetodosPagos().Select(x => new ParametroItem { Id = x.Id, Nombre = x.nombre }).ToList(),
                "Laboratorios" => IParametrosPresentacion.ConsultarLaboratorios().Select(x => new ParametroItem { Id = x.Id, Nombre = x.nombre }).ToList(),
                "Roles" => IParametrosPresentacion.ConsultarRoles().Select(x => new ParametroItem { Id = x.Id, Nombre = x.nombre }).ToList(),
                _ => new List<ParametroItem>()
            };
        }
    }
}
