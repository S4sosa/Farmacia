namespace Farmacia_libreria.entidades
{
    public class MetodosPagos
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public List<Facturas>? facturas { get; set; }
    }
}
