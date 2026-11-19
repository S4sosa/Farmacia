namespace Lib_Farmacia_Aplicacion.entidades
{
    public class Facturas
    {
        public int Id { get; set; }
        public int venta { get; set; }
        [ForeignKey("venta")] public Ventas? _venta { get; set; }
        public int metodoPago { get; set; }
        [ForeignKey("metodoPago")] public MetodosPagos? _metodoPago { get; set; }
    }

}