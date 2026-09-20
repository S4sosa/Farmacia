namespace Farmacia_libreria.entidades
{
    public class Presentaciones
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public List<Medicamentos>? medicamentos { get; set; }
    }
}
