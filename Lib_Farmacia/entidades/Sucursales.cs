namespace Farmacia_libreria.entidades
{
    public class Sucursales
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public string? direccion { get; set; }
        public string? telefono { get; set; }
        public bool activo { get; set; }
        public List<Inventarios>? inventarios { get; set; }
    }
}
