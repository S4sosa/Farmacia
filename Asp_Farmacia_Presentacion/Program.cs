using Lib_Farmacia_Presentacion.implementaciones;
using Lib_Farmacia_Presentacion.interfaces;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSession(); // Agregamos el servicio de sesiones para poder usarlo en el login.

builder.Services.AddControllers();
builder.Services.AddScoped<IComunicaciones, Comunicaciones>();
builder.Services.AddScoped<IPersonalPresentacion, PersonalPresentacion>();
builder.Services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
builder.Services.AddScoped<ISucursalesPresentacion, SucursalesPresentacion>();
builder.Services.AddScoped<IInventarioPresentacion, InventarioPresentacion>();
builder.Services.AddScoped<IComprasPresentacion, ComprasPresentacion>();
builder.Services.AddScoped<IParametrosPresentacion, ParametrosPresentacion>();
builder.Services.AddScoped<IProductosPresentacion, ProductosPresentacion>();
builder.Services.AddScoped<IVentasPresentacion, VentasPresentacion>();
builder.Services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();      // ← agregar esta línea
app.UseRouting();
app.UseSession(); // Agregar esta línea para habilitar el uso de sesiones, util en el login.
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.Run();
