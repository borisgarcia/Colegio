namespace Domain.Models
{
    public class AlumnoGrado : BaseEntity
    {
        public Guid AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        public Guid GradoId { get;set; }
        public Grado Grado { get; set; }
        public string Seccion { get; set; }
    }
}
