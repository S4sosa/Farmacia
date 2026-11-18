namespace Farmacia_libreria.entidades
{
    public class Roles
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public List<Usuarios>? usuarios { get; set; }
    }
}