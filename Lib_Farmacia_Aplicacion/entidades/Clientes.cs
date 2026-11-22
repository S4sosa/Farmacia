using System.Text.Json.Serialization;

namespace Lib_Farmacia_Aplicacion.entidades
{
    public class Clientes
    {
        public int Id { get; set; }
        public int persona { get; set; }
        [ForeignKey("persona")] public Personas? _persona { get; set; }
        public DateTime fechaRegistro { get; set; }
        public bool activo { get; set; }

        [JsonIgnore]
        public List<Recetas>? recetas { get; set; }

        [JsonIgnore]
        public List<Ventas>? ventas { get; set; }
    }
}