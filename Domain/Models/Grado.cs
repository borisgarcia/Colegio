﻿namespace Domain.Models
{
    public class Grado : BaseEntity
    {
        public string Nombre { get; set; }
        public Guid ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
    }
}
