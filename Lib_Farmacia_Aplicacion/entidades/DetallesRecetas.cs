using System.Text.Json.Serialization;

namespace Lib_Farmacia_Aplicacion.entidades
{
    public class DetallesRecetas
    {
        public int Id { get; set; }
        public int receta { get; set; }
        [JsonIgnore]
        [ForeignKey("receta")] public Recetas? _receta { get; set; }
        public int medicamento { get; set; }
        [ForeignKey("medicamento")] public Medicamentos? _medicamento { get; set; }
        public int cantidad { get; set; }
    }
}