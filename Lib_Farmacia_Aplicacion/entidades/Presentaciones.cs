namespace Lib_Farmacia_Aplicacion.entidades
{
    public class Presentaciones
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public List<Medicamentos>? medicamentos { get; set; }
    }
}
