namespace Farmacia_libreria.entidades
{
    public class Recetas
    {
        public int Id { get; set; }
        public int cliente { get; set; }
        [ForeignKey("cliente")] public Clientes? _cliente { get; set; }
        public string? medicoNombre { get; set; }
        public DateTime fechaEmision { get; set; }
        public List<DetallesRecetas>? detallesRecetas { get; set; }
    }
}