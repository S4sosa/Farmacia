using Farmacia_libreria.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Farmacia_libreria.interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }
        DbSet<Personas>? Personas { get; set; }
        DbSet<Cargos>?  Cargos { get; set; }
        DbSet<Categorias>? Categorias { get; set; }
        DbSet<Presentaciones>? Presentaciones { get; set; }
        DbSet<MetodosPagos>? MetodosPagos { get; set; }
        DbSet<Laboratorios>? Laboratorios { get; set; }
        DbSet<Sucursales>? Sucursales { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Productos>? Productos { get; set; }
        DbSet<Compras>? Compras { get; set; }
        DbSet<Inventarios>? Inventarios { get; set; }
        DbSet<Lotes>? Lotes { get; set; }
        DbSet<Medicamentos>? Medicamentos { get; set; }
        DbSet<Recetas>? Recetas { get; set; }
        DbSet<Ventas>? Ventas { get; set; }
        DbSet<DetallesCompras>? DetallesCompras { get; set; }
        DbSet<DetallesRecetas>? DetallesRecetas { get; set; }
        DbSet<DetallesVentas>? DetallesVentas { get; set; }
        DbSet<Facturas>? Facturas { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;   // <- nuevo
        int SaveChanges();                                   // <- nuevo
    }
}
