using System.Text.Json.Serialization;

namespace Lib_Farmacia_Aplicacion.entidades
{
    public class Medicamentos
    {
        public int Id { get; set; }
        public int producto { get; set; }
        [ForeignKey("producto")] public Productos? _producto { get; set; }
        public int presentacion { get; set; }
        [ForeignKey("presentacion")] public Presentaciones? _presentacion { get; set; }
        [JsonIgnore]
        public List<DetallesRecetas>? detallesRecetas { get; set; }
    }
}
