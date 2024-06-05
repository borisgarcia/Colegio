using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Service.Dtos;

public record AlumnoDto(Guid Id, [Required] string Nombre, [Required] string Apellidos, Genero Genero, DateTime FechaNacimiento);
public record ProfesorDto(Guid Id, [Required] string Nombre, [Required] string Apellidos, Genero Genero);
public record GradoDto(Guid Id, string Nombre, Guid ProfesorId);
public record AlumnoGradoDto(Guid Id, Guid GradoId, Guid AlumnoId, string Seccion);
