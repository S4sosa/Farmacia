namespace Farmacia_libreria.entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public string? correo { get; set; }
        public string? contrasena { get; set; }
        public int rol { get; set; }
        [ForeignKey("rol")] public Roles? _rol { get; set; }
    }
}