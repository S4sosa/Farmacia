namespace Farmacia_libreria.entidades
{
    public class Medicamentos
    {
        public int Id { get; set; }
        public int producto { get; set; }
        [ForeignKey("producto")] public Productos? _producto { get; set; }
        public int presentacion { get; set; }
        [ForeignKey("presentacion")] public Presentaciones? _presentacion { get; set; }
        public List<DetallesRecetas>? detallesRecetas { get; set; }
    }
}
