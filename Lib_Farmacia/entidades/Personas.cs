namespace Farmacia_libreria.entidades
{
    public class Personas
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public string? apellidos { get; set; }
        public string? documento { get; set; }
        public string? telefono { get; set; }
        public List<Clientes>? clientes { get; set; }
        public List<Empleados>? empleados { get; set; }
    }
}
