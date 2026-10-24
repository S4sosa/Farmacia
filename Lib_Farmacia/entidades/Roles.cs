namespace Farmacia_libreria.entidades
{
    public class Roles
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public List<Permisos> Permisos { get; set; }
        public List<Usuarios> Usuarios { get; set; }
    }
}