namespace Farmacia_libreria.entidades
{
    public class Inventarios
    {
        public int Id { get; set; }
        public int producto { get; set; }
        [ForeignKey("producto")] public Productos? _producto { get; set; }
        public int sucursal { get; set; }
        [ForeignKey("sucursal")] public Sucursales? _sucursal { get; set; }
        public int cantidad { get; set; }
    }

}
