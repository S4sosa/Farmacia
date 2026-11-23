using System.Text.Json.Serialization;

namespace Lib_Farmacia_Aplicacion.entidades
{
    public class Sucursales
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public string? direccion { get; set; }
        public string? telefono { get; set; }
        public bool activo { get; set; }
        [JsonIgnore]
        public List<Inventarios>? inventarios { get; set; }
    }
}
