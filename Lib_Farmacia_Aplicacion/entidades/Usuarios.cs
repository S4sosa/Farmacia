namespace Lib_Farmacia_Aplicacion.entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public string? correo { get; set; }
        public string? contrasena { get; set; }
        public int rol { get; set; }
        [ForeignKey("rol")] public Roles? _rol { get; set; }
        public int? cliente { get; set; } //NULLABLE porque el administrador no es un cliente 
        [ForeignKey("cliente")] public Clientes? _cliente { get; set; }

    }
}