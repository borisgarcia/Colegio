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
            base.OnModelCreating(modelBuilder);
        }
    }
}
