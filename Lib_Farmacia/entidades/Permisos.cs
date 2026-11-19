namespace Farmacia_libreria.entidades
{
    public class Permisos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public List<Roles> Roles { get; set; }
    }
}
