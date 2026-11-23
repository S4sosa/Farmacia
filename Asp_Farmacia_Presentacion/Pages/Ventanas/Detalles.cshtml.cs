using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    public class DetallesModel : PageModel
    {
        private IComprasPresentacion IComprasPresentacion;
        private IInventarioPresentacion IInventarioPresentacion;
        private IVentasPresentacion IVentasPresentacion;
        private IClientesPresentacion IClientesPresentacion;
        private IParametrosPresentacion IParametrosPresentacion;

        public DetallesModel(IComprasPresentacion IComprasPresentacion,
            IInventarioPresentacion IInventarioPresentacion,
            IVentasPresentacion IVentasPresentacion,
            IClientesPresentacion IClientesPresentacion,
            IParametrosPresentacion IParametrosPresentacion)
        {
            this.IComprasPresentacion = IComprasPresentacion;
            this.IInventarioPresentacion = IInventarioPresentacion;
            this.IVentasPresentacion = IVentasPresentacion;
            this.IClientesPresentacion = IClientesPresentacion;
            this.IParametrosPresentacion = IParametrosPresentacion;
        }

        [BindProperty] public string TipoSeleccionado { get; set; } = "DetallesCompras";
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public List<SelectListItem> Tipos { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "DetallesCompras", Text = "Detalles de Compras" },
            new SelectListItem { Value = "DetallesVentas", Text = "Detalles de Ventas" },
            new SelectListItem { Value = "DetallesRecetas", Text = "Detalles de Recetas" },
            new SelectListItem { Value = "Facturas", Text = "Facturas" },
        };

        public bool SoloLectura => false;

        // Una lista y un registro actual por cada tabla
        [BindProperty] public List<DetallesCompras> DatosDetallesCompras { get; set; } = new();
        [BindProperty] public DetallesCompras? ActualDetallesCompras { get; set; }
        [BindProperty] public List<DetallesVentas> DatosDetallesVentas { get; set; } = new();
        [BindProperty] public DetallesVentas? ActualDetallesVentas { get; set; }
        [BindProperty] public List<DetallesRecetas> DatosDetallesRecetas { get; set; } = new();
        [BindProperty] public DetallesRecetas? ActualDetallesRecetas { get; set; }
        [BindProperty] public List<Facturas> DatosFacturas { get; set; } = new();
        [BindProperty] public Facturas? ActualFacturas { get; set; }

        // Listas para los desplegables y para mostrar nombres en la tabla
        public List<Compras> ListaCompras { get; set; } = new();
        public List<Productos> ListaProductos { get; set; } = new();
        public List<Ventas> ListaVentas { get; set; } = new();
        public List<Recetas> ListaRecetas { get; set; } = new();
        public List<Medicamentos> ListaMedicamentos { get; set; } = new();
        public List<MetodosPagos> ListaMetodosPagos { get; set; } = new();

        public List<SelectListItem> OpcionesCompras =>
            ListaCompras.Select(x => new SelectListItem("#" + x.Id + " - " + (x._laboratorio?.nombre ?? "") + " - " + x.fecha.ToShortDateString(), x.Id.ToString())).ToList();
        public List<SelectListItem> OpcionesProductos =>
            ListaProductos.Select(x => new SelectListItem(x.nombre ?? "", x.Id.ToString())).ToList();
        public List<SelectListItem> OpcionesVentas =>
            ListaVentas.Select(x => new SelectListItem("#" + x.Id + " - " + (x._cliente?._persona?.nombre ?? "") + " " + (x._cliente?._persona?.apellidos ?? "") + " - " + x.fecha.ToShortDateString(), x.Id.ToString())).ToList();
        public List<SelectListItem> OpcionesRecetas =>
            ListaRecetas.Select(x => new SelectListItem("#" + x.Id + " - " + (x._cliente?._persona?.nombre ?? "") + " " + (x._cliente?._persona?.apellidos ?? "") + " - " + x.medicoNombre, x.Id.ToString())).ToList();
        public List<SelectListItem> OpcionesMedicamentos =>
            ListaMedicamentos.Select(x => new SelectListItem((x._producto?.nombre ?? "") + " (" + (x._presentacion?.nombre ?? "") + ")", x.Id.ToString())).ToList();
        public List<SelectListItem> OpcionesMetodosPagos =>
            ListaMetodosPagos.Select(x => new SelectListItem(x.nombre ?? "", x.Id.ToString())).ToList();

        public string NombreCompras(int? id) =>
            ListaCompras.Where(x => x.Id == id).Select(x => "#" + x.Id + " - " + (x._laboratorio?.nombre ?? "") + " - " + x.fecha.ToShortDateString()).FirstOrDefault() ?? "";
        public string NombreProductos(int? id) =>
            ListaProductos.Where(x => x.Id == id).Select(x => x.nombre ?? "").FirstOrDefault() ?? "";
        public string NombreVentas(int? id) =>
            ListaVentas.Where(x => x.Id == id).Select(x => "#" + x.Id + " - " + (x._cliente?._persona?.nombre ?? "") + " " + (x._cliente?._persona?.apellidos ?? "") + " - " + x.fecha.ToShortDateString()).FirstOrDefault() ?? "";
        public string NombreRecetas(int? id) =>
            ListaRecetas.Where(x => x.Id == id).Select(x => "#" + x.Id + " - " + (x._cliente?._persona?.nombre ?? "") + " " + (x._cliente?._persona?.apellidos ?? "") + " - " + x.medicoNombre).FirstOrDefault() ?? "";
        public string NombreMedicamentos(int? id) =>
            ListaMedicamentos.Where(x => x.Id == id).Select(x => (x._producto?.nombre ?? "") + " (" + (x._presentacion?.nombre ?? "") + ")").FirstOrDefault() ?? "";
        public string NombreMetodosPagos(int? id) =>
            ListaMetodosPagos.Where(x => x.Id == id).Select(x => x.nombre ?? "").FirstOrDefault() ?? "";

        public decimal PrecioProducto(int id) =>
            ListaProductos.Where(x => x.Id == id).Select(x => x.precio).FirstOrDefault();
        public decimal TotalVenta(int id) =>
            ListaVentas.Where(x => x.Id == id).Select(x => x.total).FirstOrDefault();

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
                    case "DetallesCompras":
                        DatosDetallesCompras = this.IComprasPresentacion.ConsultarDetallesCompras();
                        ListaCompras = this.IComprasPresentacion.ConsultarCompras();
                        ListaProductos = this.IInventarioPresentacion.ConsultarProductos();
                        break;
                    case "DetallesVentas":
                        DatosDetallesVentas = this.IVentasPresentacion.ConsultarDetallesVentas();
                        ListaVentas = this.IVentasPresentacion.ConsultarVentas();
                        ListaProductos = this.IInventarioPresentacion.ConsultarProductos();
                        break;
                    case "DetallesRecetas":
                        DatosDetallesRecetas = this.IClientesPresentacion.ConsultarDetallesRecetas();
                        ListaRecetas = this.IClientesPresentacion.ConsultarRecetas();
                        ListaMedicamentos = this.IInventarioPresentacion.ConsultarMedicamentos();
                        break;
                    case "Facturas":
                        DatosFacturas = this.IVentasPresentacion.ConsultarFacturas();
                        ListaVentas = this.IVentasPresentacion.ConsultarVentas();
                        ListaMetodosPagos = this.IParametrosPresentacion.ConsultarMetodosPagos();
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
                    case "DetallesCompras":
                        ActualDetallesCompras = new DetallesCompras();
                        break;
                    case "DetallesVentas":
                        ActualDetallesVentas = new DetallesVentas();
                        break;
                    case "DetallesRecetas":
                        ActualDetallesRecetas = new DetallesRecetas();
                        break;
                    case "Facturas":
                        ActualFacturas = new Facturas();
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
                    case "DetallesCompras":
                        if (ActualDetallesCompras!.Id == 0) this.IComprasPresentacion.InsertarDetallesCompra(ActualDetallesCompras!);
                        else this.IComprasPresentacion.ActualizarDetallesCompra(ActualDetallesCompras!);
                        break;
                    case "DetallesVentas":
                        if (ActualDetallesVentas!.Id == 0) this.IVentasPresentacion.InsertarDetallesVenta(ActualDetallesVentas!);
                        else this.IVentasPresentacion.ActualizarDetallesVenta(ActualDetallesVentas!);
                        break;
                    case "DetallesRecetas":
                        if (ActualDetallesRecetas!.Id == 0) this.IClientesPresentacion.InsertarDetallesReceta(ActualDetallesRecetas!);
                        else this.IClientesPresentacion.ActualizarDetallesReceta(ActualDetallesRecetas!);
                        break;
                    case "Facturas":
                        if (ActualFacturas!.Id == 0) this.IVentasPresentacion.InsertarFactura(ActualFacturas!);
                        else this.IVentasPresentacion.ActualizarFactura(ActualFacturas!);
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
                    case "DetallesCompras":
                        ActualDetallesCompras = DatosDetallesCompras.FirstOrDefault(x => x.Id == id);
                        break;
                    case "DetallesVentas":
                        ActualDetallesVentas = DatosDetallesVentas.FirstOrDefault(x => x.Id == id);
                        break;
                    case "DetallesRecetas":
                        ActualDetallesRecetas = DatosDetallesRecetas.FirstOrDefault(x => x.Id == id);
                        break;
                    case "Facturas":
                        ActualFacturas = DatosFacturas.FirstOrDefault(x => x.Id == id);
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
                    case "DetallesCompras":
                        ActualDetallesCompras = DatosDetallesCompras.FirstOrDefault(x => x.Id == id);
                        break;
                    case "DetallesVentas":
                        ActualDetallesVentas = DatosDetallesVentas.FirstOrDefault(x => x.Id == id);
                        break;
                    case "DetallesRecetas":
                        ActualDetallesRecetas = DatosDetallesRecetas.FirstOrDefault(x => x.Id == id);
                        break;
                    case "Facturas":
                        ActualFacturas = DatosFacturas.FirstOrDefault(x => x.Id == id);
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
                    case "DetallesCompras":
                        if (ActualDetallesCompras != null && ActualDetallesCompras.Id != 0) this.IComprasPresentacion.BorrarDetallesCompra(ActualDetallesCompras!);
                        break;
                    case "DetallesVentas":
                        if (ActualDetallesVentas != null && ActualDetallesVentas.Id != 0) this.IVentasPresentacion.BorrarDetallesVenta(ActualDetallesVentas!);
                        break;
                    case "DetallesRecetas":
                        if (ActualDetallesRecetas != null && ActualDetallesRecetas.Id != 0) this.IClientesPresentacion.BorrarDetallesReceta(ActualDetallesRecetas!);
                        break;
                    case "Facturas":
                        if (ActualFacturas != null && ActualFacturas.Id != 0) this.IVentasPresentacion.BorrarFactura(ActualFacturas!);
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
