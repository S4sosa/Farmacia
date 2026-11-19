namespace Farmacia_libreria.entidades
{
    public class Auditorias
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }
        public string Descripcion { get; set; }
        public string Resultado { get; set; }

        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; }
    }
}