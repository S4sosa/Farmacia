namespace Farmacia_libreria.entidades
{
    public class Empleados
    {
        public int Id { get; set; }
        public int persona { get; set; }
        [ForeignKey("persona")] public Personas? _persona { get; set; }
        public int cargo { get; set; }
        [ForeignKey("cargo")] public Cargos? _cargo { get; set; }
    }
}
