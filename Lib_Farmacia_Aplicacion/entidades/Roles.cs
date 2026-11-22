using System.Text.Json.Serialization;

namespace Lib_Farmacia_Aplicacion.entidades
{
    public class Roles
    {
        public int Id { get; set; }
        public string? nombre { get; set; }

        [JsonIgnore]
        public List<Usuarios>? usuarios { get; set; }
    }
}