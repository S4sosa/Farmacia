using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    public class AlmacenModel : PageModel
    {
        private IInventarioPresentacion IInventarioPresentacion;
        private IParametrosPresentacion IParametrosPresentacion;
        private ISucursalesPresentacion ISucursalesPresentacion;

        public AlmacenModel(IInventarioPresentacion IInventarioPresentacion,
            IParametrosPresentacion IParametrosPresentacion,
            ISucursalesPresentacion ISucursalesPresentacion)
        {
            this.IInventarioPresentacion = IInventarioPresentacion;
            this.IParametrosPresentacion = IParametrosPresentacion;
            this.ISucursalesPresentacion = ISucursalesPresentacion;
        }

        [BindProperty] public string TipoSeleccionado { get; set; } = "Medicamentos";
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public List<SelectListItem> Tipos { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Medicamentos", Text = "Medicamentos" },
            new SelectListItem { Value = "Lotes", Text = "Lotes" },
            new SelectListItem { Value = "Inventarios", Text = "Inventario por Sucursal" },
        };

        public bool SoloLectura => false;

        // Una lista y un registro actual por cada tabla
        [BindProperty] public List<Medicamentos> DatosMedicamentos { get; set; } = new();
        [BindProperty] public Medicamentos? ActualMedicamentos { get; set; }
        [BindProperty] public List<Lotes> DatosLotes { get; set; } = new();
        [BindProperty] public Lotes? ActualLotes { get; set; }
        [BindProperty] public List<Inventarios> DatosInventarios { get; set; } = new();
        [BindProperty] public Inventarios? ActualInventarios { get; set; }

        // Listas para los desplegables y para mostrar nombres en la tabla
        public List<Productos> ListaProductos { get; set; } = new();
        public List<Presentaciones> ListaPresentaciones { get; set; } = new();
        public List<Sucursales> ListaSucursales { get; set; } = new();

        public List<SelectListItem> OpcionesProductos =>
            ListaProductos.Select(x => new SelectListItem(x.nombre ?? "", x.Id.ToString())).ToList();
        public List<SelectListItem> OpcionesPresentaciones =>
            ListaPresentaciones.Select(x => new SelectListItem(x.nombre ?? "", x.Id.ToString())).ToList();
        public List<SelectListItem> OpcionesSucursales =>
            ListaSucursales.Select(x => new SelectListItem(x.nombre ?? "", x.Id.ToString())).ToList();

        public string NombreProductos(int? id) =>
            ListaProductos.Where(x => x.Id == id).Select(x => x.nombre ?? "").FirstOrDefault() ?? "";
        public string NombrePresentaciones(int? id) =>
            ListaPresentaciones.Where(x => x.Id == id).Select(x => x.nombre ?? "").FirstOrDefault() ?? "";
        public string NombreSucursales(int? id) =>
            ListaSucursales.Where(x => x.Id == id).Select(x => x.nombre ?? "").FirstOrDefault() ?? "";


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
                    case "Medicamentos":
                        DatosMedicamentos = this.IInventarioPresentacion.ConsultarMedicamentos();
                        ListaProductos = this.IInventarioPresentacion.ConsultarProductos();
                        ListaPresentaciones = this.IParametrosPresentacion.ConsultarPresentaciones();
                        break;
                    case "Lotes":
                        DatosLotes = this.IInventarioPresentacion.ConsultarLotes();
                        ListaProductos = this.IInventarioPresentacion.ConsultarProductos();
                        break;
                    case "Inventarios":
                        DatosInventarios = this.IInventarioPresentacion.ConsultarInventarios();
                        ListaProductos = this.IInventarioPresentacion.ConsultarProductos();
                        ListaSucursales = this.ISucursalesPresentacion.ConsultarSucursales();
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
                    case "Medicamentos":
                        ActualMedicamentos = new Medicamentos();
                        break;
                    case "Lotes":
                        ActualLotes = new Lotes { fechaVencimiento = DateTime.Today.AddYears(1) };
                        break;
                    case "Inventarios":
                        ActualInventarios = new Inventarios();
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
                    case "Medicamentos":
                        if (ActualMedicamentos!.Id == 0) this.IInventarioPresentacion.InsertarMedicamento(ActualMedicamentos!);
                        else this.IInventarioPresentacion.ActualizarMedicamento(ActualMedicamentos!);
                        break;
                    case "Lotes":
                        if (ActualLotes!.Id == 0) this.IInventarioPresentacion.InsertarLote(ActualLotes!);
                        else this.IInventarioPresentacion.ActualizarLote(ActualLotes!);
                        break;
                    case "Inventarios":
                        if (ActualInventarios!.Id == 0) this.IInventarioPresentacion.InsertarInventario(ActualInventarios!);
                        else this.IInventarioPresentacion.ActualizarInventario(ActualInventarios!);
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
                    case "Medicamentos":
                        ActualMedicamentos = DatosMedicamentos.FirstOrDefault(x => x.Id == id);
                        break;
                    case "Lotes":
                        ActualLotes = DatosLotes.FirstOrDefault(x => x.Id == id);
                        break;
                    case "Inventarios":
                        ActualInventarios = DatosInventarios.FirstOrDefault(x => x.Id == id);
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
                    case "Medicamentos":
                        ActualMedicamentos = DatosMedicamentos.FirstOrDefault(x => x.Id == id);
                        break;
                    case "Lotes":
                        ActualLotes = DatosLotes.FirstOrDefault(x => x.Id == id);
                        break;
                    case "Inventarios":
                        ActualInventarios = DatosInventarios.FirstOrDefault(x => x.Id == id);
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
                    case "Medicamentos":
                        if (ActualMedicamentos != null && ActualMedicamentos.Id != 0) this.IInventarioPresentacion.BorrarMedicamento(ActualMedicamentos!);
                        break;
                    case "Lotes":
                        if (ActualLotes != null && ActualLotes.Id != 0) this.IInventarioPresentacion.BorrarLote(ActualLotes!);
                        break;
                    case "Inventarios":
                        if (ActualInventarios != null && ActualInventarios.Id != 0) this.IInventarioPresentacion.BorrarInventario(ActualInventarios!);
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
