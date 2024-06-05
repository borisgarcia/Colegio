using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class Grado : BaseEntity
    {
        public string Nombre { get; set; }
        public Guid ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
        public ICollection<AlumnoGrado> AlumnoGrados { get; set; }

        public class EntityConfiguration : IEntityTypeConfiguration<Grado>
        {
            public void Configure(EntityTypeBuilder<Grado> builder)
            {
                builder.HasOne(g => g.Profesor)
                    .WithMany(p => p.Grados)
                    .HasForeignKey(g => g.ProfesorId);
            }
        }
    }
}
