using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Models
{
    public class Profesor : BaseEntity
    {
        public required string Nombre { get; set; }
        public required string Apellidos { get; set; }
        public Genero Genero { get; set; }
        public ICollection<Grado> Grados { get; set; }

        public class EntityConfiguration : IEntityTypeConfiguration<Profesor>
        {
            public void Configure(EntityTypeBuilder<Profesor> builder)
            {

            }
        }
    }
}
