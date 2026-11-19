namespace Lib_Farmacia_Aplicacion.entidades
{
    public class MetodosPagos
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public List<Facturas>? facturas { get; set; }
    }
}
