namespace Lib_Farmacia_Aplicacion.entidades
{
    public class Lotes
    {
        public int Id { get; set; }
        public int producto { get; set; }
        [ForeignKey("producto")] public Productos? _producto { get; set; }
        public string? numLote { get; set; }
        public DateTime fechaVencimiento { get; set; }
    }
}
