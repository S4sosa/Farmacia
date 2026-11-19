using Lib_Farmacia_Aplicacion.implementaciones;
using Lib_Farmacia_Aplicacion.interfaces;
using Microsoft.EntityFrameworkCore;

try
{
    IConexion conexion = new Conexion();
    conexion.StringConexion = "server=localhost;database=farmacia_db;Integrated Security=True;TrustServerCertificate=true;";
    var lista = conexion.Personas!.ToList();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("Farmacia_Consola");