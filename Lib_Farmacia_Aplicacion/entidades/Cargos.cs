using System.Text.Json.Serialization;

namespace Lib_Farmacia_Aplicacion.entidades
{
    public class Cargos
    {
        public int Id { get; set; }
        public string? nombre { get; set; }

        [JsonIgnore]
        public List<Empleados>? empleados { get; set; }
    }
}