namespace Farmacia_libreria.entidades
{
    public class Clientes
    {
        public int Id { get; set; }
        public int persona { get; set; }
        [ForeignKey("persona")] public Personas? _persona { get; set; }
        public DateTime fechaRegistro { get; set; }
        public bool activo { get; set; }
        public List<Recetas>? recetas { get; set; }
        public List<Ventas>? ventas { get; set; }
    }
}