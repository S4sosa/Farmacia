using Lib_Farmacia_Aplicacion.implementaciones;
using Lib_Farmacia_Aplicacion.interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
//Se agrega todos los AddScope de las interfaces y clases de cada pagina -- Para que cuando se pida una interfaz
//se entregue la aplicacion correspondiente
builder.Services.AddScoped<IConexion, Conexion>();
builder.Services.AddScoped<IParametrosAplicacion, ParametrosAplicacion>();
builder.Services.AddScoped<IProductosAplicacion, ProductosAplicacion>();
builder.Services.AddScoped<ISucursalesAplicacion, SucursalesAplicacion>();
builder.Services.AddScoped<IClientesAplicacion, ClientesAplicacion>();
builder.Services.AddScoped<IPersonalAplicacion, PersonalAplicacion>();
builder.Services.AddScoped<IComprasAplicacion, ComprasAplicacion>();
builder.Services.AddScoped<IVentasAplicacion, VentasAplicacion>();
builder.Services.AddScoped<IInventarioAplicacion, InventarioAplicacion>();
builder.Services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "");
app.Run();
