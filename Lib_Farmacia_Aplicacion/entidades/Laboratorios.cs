using System.Text.Json.Serialization;

namespace Lib_Farmacia_Aplicacion.entidades
{
    public class Laboratorios
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        [JsonIgnore]
        public List<Compras>? compras { get; set; }
    }
}
