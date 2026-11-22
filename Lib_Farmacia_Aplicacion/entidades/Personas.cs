using System.Text.Json.Serialization;

namespace Lib_Farmacia_Aplicacion.entidades
{
    public class Personas
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public string? apellidos { get; set; }
        public string? documento { get; set; }
        public string? telefono { get; set; }

        [JsonIgnore]
        public List<Clientes>? clientes { get; set; }

        [JsonIgnore]
        public List<Empleados>? empleados { get; set; }
    }
}
