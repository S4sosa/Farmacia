namespace Farmacia_libreria.entidades
{
    public class DetallesRecetas
    {
        public int Id { get; set; }
        public int receta { get; set; }
        [ForeignKey("receta")] public Recetas? _receta { get; set; }
        public int medicamento { get; set; }
        [ForeignKey("medicamento")] public Medicamentos? _medicamento { get; set; }
        public int cantidad { get; set; }
    }
}