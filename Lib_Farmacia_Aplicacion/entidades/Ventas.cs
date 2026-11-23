using System.Text.Json.Serialization;

namespace Lib_Farmacia_Aplicacion.entidades
{
    public class Ventas
    {
        public int Id { get; set; }
        public int cliente { get; set; }
        [ForeignKey("cliente")] public Clientes? _cliente { get; set; }
        public DateTime fecha { get; set; }
        public Decimal total { get; set; }
        public List<DetallesVentas>? detallesVentas { get; set; }
        [JsonIgnore]
        public List<Facturas>? facturas { get; set; }
    }
}