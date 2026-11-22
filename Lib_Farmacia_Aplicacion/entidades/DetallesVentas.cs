using System.Text.Json.Serialization;

namespace Lib_Farmacia_Aplicacion.entidades
{
    public class DetallesVentas
    {
        public int Id { get; set; }
        public int venta { get; set; }
        [JsonIgnore]
        [ForeignKey("venta")] public Ventas? _venta { get; set; }
        public int producto { get; set; }
        [ForeignKey("producto")] public Productos? _producto { get; set; }
        public int cantidad { get; set; }
    }
}