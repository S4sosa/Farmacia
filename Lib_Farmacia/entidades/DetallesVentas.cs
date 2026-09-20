namespace Farmacia_libreria.entidades
{
    public class DetallesVentas
    {
        public int Id { get; set; }
        public int venta { get; set; }
        [ForeignKey("venta")] public Ventas? _venta { get; set; }
        public int producto { get; set; }
        [ForeignKey("producto")] public Productos? _producto { get; set; }
        public int cantidad { get; set; }
    }
}