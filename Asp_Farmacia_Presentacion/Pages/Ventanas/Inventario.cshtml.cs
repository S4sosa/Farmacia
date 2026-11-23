using ClosedXML.Excel;
using Lib_Farmacia_Aplicacion.entidades;
using Lib_Farmacia_Aplicacion.nucleo;
using Lib_Farmacia_Presentacion.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Farmacia_Presentacion.Pages.Ventanas
{
    public class InventarioModel : PageModel
    {
        private IInventarioPresentacion IInventarioPresentacion;
        private IParametrosPresentacion IParametrosPresentacion;
        private IWebHostEnvironment IWebHostEnvironment;

        public InventarioModel(IInventarioPresentacion IInventarioPresentacion,
            IParametrosPresentacion IParametrosPresentacion,
            IWebHostEnvironment IWebHostEnvironment)
        {
            this.IInventarioPresentacion = IInventarioPresentacion;
            this.IParametrosPresentacion = IParametrosPresentacion;
            this.IWebHostEnvironment = IWebHostEnvironment;
            this.Filtro = new Productos();
        }

        [BindProperty] public List<Productos> Lista { get; set; } = new();
        [BindProperty] public List<Categorias> Categorias { get; set; } = new();
        [BindProperty] public Productos? Actual { get; set; }
        [BindProperty] public Productos? Filtro { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;
        [BindProperty] public IFormFile? ArchivoImagen { get; set; }
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

                if (!string.IsNullOrEmpty(Filtro?.nombre))
                    Lista = this.IInventarioPresentacion.BuscarProducto(Filtro!);
                else
                    Lista = this.IInventarioPresentacion.ConsultarProductos();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public IActionResult OnPostBtExportarExcel()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (String.IsNullOrEmpty(variable_session))
                    return Redirect("/");

                var lista = this.IInventarioPresentacion.ConsultarProductos();

                using var libro = new XLWorkbook();
                var hoja = libro.Worksheets.Add("Productos");

                // Encabezados
                hoja.Cell(1, 1).Value = "Nombre";
                hoja.Cell(1, 2).Value = "Categoría";
                hoja.Cell(1, 3).Value = "Precio";
                hoja.Row(1).Style.Font.Bold = true;

                // Datos
                int fila = 2;
                foreach (var p in lista)
                {
                    hoja.Cell(fila, 1).Value = p.nombre ?? "";
                    hoja.Cell(fila, 2).Value = p._categoria?.nombre ?? "";
                    hoja.Cell(fila, 3).Value = p.precio;
                    hoja.Cell(fila, 3).Style.NumberFormat.Format = "$ #,##0.00";
                    fila++;
                }

                hoja.Columns().AdjustToContents();

                using var stream = new MemoryStream();
                libro.SaveAs(stream);

                return File(stream.ToArray(),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "Productos_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx");
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                OnPostBtConsultar();
                return Page();
            }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Formulario = true;
                Actual = new Productos();
                Categorias = this.IParametrosPresentacion.ConsultarCategorias();
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
                // Si se eligió una imagen, guardarla en wwwroot/imagenes
                if (ArchivoImagen != null && ArchivoImagen.Length > 0)
                {
                    var extension = Path.GetExtension(ArchivoImagen.FileName).ToLower();
                    var permitidas = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
                    if (!permitidas.Contains(extension))
                        throw new Exception("Solo se permiten imágenes");

                    var nombreArchivo = Guid.NewGuid().ToString() + extension;
                    var carpeta = Path.Combine(this.IWebHostEnvironment.WebRootPath, "imagenes");
                    Directory.CreateDirectory(carpeta);

                    using (var stream = new FileStream(Path.Combine(carpeta, nombreArchivo), FileMode.Create))
                    {
                        ArchivoImagen.CopyTo(stream);
                    }

                    Actual!.imagen = nombreArchivo;
                }

                if (Actual!.Id == 0)
                    Actual = this.IInventarioPresentacion.InsertarProducto(Actual!);
                else
                    Actual = this.IInventarioPresentacion.ActualizarProducto(Actual!);
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
                Categorias = this.IParametrosPresentacion.ConsultarCategorias();
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
                this.IInventarioPresentacion.BorrarProducto(Actual!);
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
