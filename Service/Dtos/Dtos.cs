using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Service.Dtos;

public record AlumnoDto(Guid Id, [Required] string Nombre, [Required] string Apellidos, string? NombreCompleto, Genero Genero, DateTime FechaNacimiento, IReadOnlyList<GradoDto>? grados);
public record ProfesorDto(Guid Id, [Required] string Nombre, [Required] string Apellidos, string? NombreCompleto, Genero Genero);
public record GradoDto(Guid Id, string Nombre, Guid ProfesorId, string Profesor);
public record AlumnoGradoDto(Guid Id, Guid GradoId, Guid AlumnoId, string Seccion, string? Grado, string? Alumno);
