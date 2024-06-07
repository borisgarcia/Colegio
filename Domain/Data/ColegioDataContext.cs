using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class ColegioDataContext : DbContext
    {
        public ColegioDataContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<AlumnoGrado> AlumnoGrados { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<Profesor> Profesores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Alumno.EntityConfiguration());
            modelBuilder.ApplyConfiguration(new AlumnoGrado.EntityConfiguration());
            modelBuilder.ApplyConfiguration(new Grado.EntityConfiguration());
            modelBuilder.ApplyConfiguration(new Profesor.EntityConfiguration());

            modelBuilder.Entity<Alumno>().HasData(new List<Alumno>
            {
                new Alumno
                {
                    Id = new Guid("d8323dd7-b47a-44f3-833e-dd66910f9ef2"),
                    Nombre = "Jane",
                    Apellidos = "Doe",
                    FechaNacimiento = DateTime.Now,
                    Genero = Genero.Femenimo
                },
                new Alumno
                {
                    Id = new Guid("2adc4147-1831-42a5-88cd-dda4bae18b0d"),
                    Nombre = "John",
                    Apellidos = "Doe",
                    FechaNacimiento = DateTime.Now,
                    Genero = Genero.Masculino
                }
            });

            modelBuilder.Entity<Profesor>().HasData(new List<Profesor>
            {
                new Profesor
                {
                    Id = new Guid("a4e94be4-753a-469a-bca6-55641df746a7"),
                    Nombre = "Willem",
                    Apellidos = "Dafoe",
                    Genero = Genero.Masculino
                },
                new Profesor
                {
                    Id = new Guid("6c6836f9-6cfc-4619-a4e6-f84b7cf84b96"),
                    Nombre = "Peter",
                    Apellidos = "Parker",
                    Genero = Genero.Masculino
                }
            });

            modelBuilder.Entity<Grado>().HasData(new List<Grado>
            {
                new Grado
                {
                    Id = new Guid("fb0f36cd-98e4-426b-8cad-47425ba09864"),
                    Nombre = "I A",
                    ProfesorId = new Guid("6c6836f9-6cfc-4619-a4e6-f84b7cf84b96")
                },
                new Grado
                {
                    Id = new Guid("70e283fd-491e-476d-ab4f-f542ab810ee6"),
                    Nombre = "II B",
                    ProfesorId = new Guid("a4e94be4-753a-469a-bca6-55641df746a7")
                }
            });

            modelBuilder.Entity<AlumnoGrado>().HasData(new List<AlumnoGrado>
            {
                new AlumnoGrado
                {
                    Id = Guid.NewGuid(),
                    GradoId = new Guid("fb0f36cd-98e4-426b-8cad-47425ba09864"),
                    AlumnoId = new Guid("2adc4147-1831-42a5-88cd-dda4bae18b0d"),
                    Seccion = "1"
                },
                new AlumnoGrado 
                {
                    Id = Guid.NewGuid(),
                    GradoId = new Guid("70e283fd-491e-476d-ab4f-f542ab810ee6"),
                    AlumnoId = new Guid("d8323dd7-b47a-44f3-833e-dd66910f9ef2"),
                    Seccion = "1"
                }
            });
        }
    }
}
