using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Models
{
    public class Alumno : BaseEntity
    {
        public required string Nombre { get; set; }
        public required string Apellidos { get; set; }
        public Genero Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public ICollection<AlumnoGrado> AlumnoGrados { get; set; }

        public class EntityConfiguration : IEntityTypeConfiguration<Alumno>
        {
            public void Configure(EntityTypeBuilder<Alumno> builder)
            {
            
            }
        }

    }
}
