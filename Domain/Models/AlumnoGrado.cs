using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class AlumnoGrado : BaseEntity
    {
        public Guid AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        public Guid GradoId { get;set; }
        public Grado Grado { get; set; }
        public string Seccion { get; set; }

        public class EntityConfiguration : IEntityTypeConfiguration<AlumnoGrado>
        {
            public void Configure(EntityTypeBuilder<AlumnoGrado> builder)
            {
                builder.HasOne(g => g.Grado)
                    .WithMany(ag => ag.AlumnoGrados)
                    .HasForeignKey(g => g.GradoId);

                builder.HasOne(a => a.Alumno)
                    .WithMany(g => g.AlumnoGrados)
                    .HasForeignKey(a => a.AlumnoId);
            }
        }
    }
}
