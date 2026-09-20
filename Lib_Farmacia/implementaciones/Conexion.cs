using Farmacia_libreria.interfaces;
using Farmacia_libreria.entidades;
using Microsoft.EntityFrameworkCore;

namespace Farmacia_libreria.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<Personas>? Personas { get; set; }
        public DbSet<Cargos>? Cargos { get; set; }
        public DbSet<Categorias>? Categorias { get; set; }
        public DbSet<Presentaciones>? Presentaciones { get; set; }
        public DbSet<MetodosPagos>? MetodosPagos { get; set; }
        public DbSet<Laboratorios>? Laboratorios { get; set; }
        public DbSet<Sucursales>? Sucursales { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Compras>? Compras { get; set; }
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<Lotes>? Lotes { get; set; }
        public DbSet<Medicamentos>? Medicamentos { get; set; }
        public DbSet<Recetas>? Recetas { get; set; }
        public DbSet<Ventas>? Ventas { get; set; }
        public DbSet<DetallesCompras>? DetallesCompras { get; set; }
        public DbSet<DetallesRecetas>? DetallesRecetas { get; set; }
        public DbSet<DetallesVentas>? DetallesVentas { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }

    }
}
