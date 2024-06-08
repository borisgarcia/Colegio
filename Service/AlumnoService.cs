using Domain.Models;
using Repositories;
using Service.Dtos;

namespace Service
{
    public class AlumnoService : IService<AlumnoDto>
    {
        private readonly IRepository<Alumno> _repository;
        
        public AlumnoService(IRepository<Alumno> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(AlumnoDto entity, CancellationToken cancellationToken)
        {
            if(entity is not null)
            {
                await _repository.CreateAsync(Map(entity), cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);
            }    
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            await _repository.DeleteAsync(cancellationToken, keyValues);
            await _repository.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<AlumnoDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var alumnos = await _repository.GetAllAsync(cancellationToken);

            return alumnos.Select(Map).ToList();
        }

        public async Task<AlumnoDto> GetByIdAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            var alumno = await _repository.GetByIdAsync(cancellationToken,keyValues);
            return Map(alumno);
        }

        public async Task UpdateAsync(AlumnoDto entity, CancellationToken cancellationToken)
        {
            var alumno = await _repository.GetByIdAsync(cancellationToken, entity.Id);

            if(alumno != null)
            {
                alumno.Apellidos = entity.Apellidos;
                alumno.Nombre = entity.Nombre;
                alumno.Genero = entity.Genero;
                alumno.FechaNacimiento = entity.FechaNacimiento;

                _repository.UpdateAsync(alumno, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);
            }
        }

        private Alumno Map(AlumnoDto alumno)
        {
            return new Alumno
            {
                Id = alumno.Id,
                Apellidos = alumno.Apellidos,
                Nombre = alumno.Nombre,
                Genero = alumno.Genero,
                FechaNacimiento = alumno.FechaNacimiento
            };
        }

        private AlumnoDto Map(Alumno alumno) 
        {
            return new AlumnoDto(alumno.Id, alumno.Nombre, alumno.Apellidos, alumno.NombreCompleto, alumno.Genero, alumno.FechaNacimiento, null);
        }
    }
}
