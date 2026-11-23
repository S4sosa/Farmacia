using System.Text.Json.Serialization;

namespace Lib_Farmacia_Aplicacion.entidades
{
    public class Productos
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public Decimal precio { get; set; }
        public string? imagen { get; set; }
        public int categoria { get; set; }
        [ForeignKey("categoria")] public Categorias? _categoria { get; set; }
        [JsonIgnore]
        public List<DetallesVentas>? detallesVentas { get; set; }
        public List<Inventarios>? inventarios { get; set; }
        public List<Lotes>? lotes { get; set; }
        public List<Medicamentos>? medicamentos { get; set; }
        public List<DetallesCompras>? detallesCompras { get; set; }
    }
}
