namespace Farmacia_libreria.entidades
{
    public class DetallesCompras
    {
        public int Id { get; set; }
        public int compra { get; set; }
        [ForeignKey("compra")] public Compras? _compra { get; set; }
        public int producto { get; set; }
        [ForeignKey("producto")] public Productos? _producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
    }
}
