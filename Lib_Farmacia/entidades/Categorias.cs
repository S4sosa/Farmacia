namespace Farmacia_libreria.entidades
{
    public class Categorias
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public List<Productos>? productos { get; set; }
    }
}