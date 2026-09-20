namespace Farmacia_libreria.entidades
{
    public class Compras
    {
        public int Id { get; set; }
        public int laboratorio { get; set; }
        [ForeignKey("laboratorio")] public Laboratorios? _laboratorio { get; set; }
        public DateTime fecha { get; set; }
        public Decimal total { get; set; }
        public List<DetallesCompras>? detallesCompras { get; set; }

    }
}
