using Domain.Enums;

namespace Domain.Models
{
    public class Profesor : BaseEntity
    {
        public required string Nombre { get; set; }
        public required string Apellidos { get; set; }
        public Genero Genero { get; set; }
    }
}
