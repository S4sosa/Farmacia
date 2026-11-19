namespace Farmacia_libreria.entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }

        public int RolId { get; set; }
        public Roles Rol { get; set; }

        public List<Auditorias> Auditorias { get; set; }
    }
}