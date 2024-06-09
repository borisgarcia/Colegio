using Domain.Models;
using Repositories;
using Service.Dtos;

namespace Service
{
    public class AlumnoGradoService : IService<AlumnoGradoDto>
    {
        private readonly IRepository<AlumnoGrado> _repository;

        public AlumnoGradoService(IRepository<AlumnoGrado> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(AlumnoGradoDto entity, CancellationToken cancellationToken)
        {
            if (entity is not null)
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

        public async Task<IReadOnlyList<AlumnoGradoDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var alumnoGrados = await _repository.GetAllAsync(cancellationToken);

            return alumnoGrados.Select(Map).ToList();
        }

        public async Task<AlumnoGradoDto> GetByIdAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            var alumnoGrado = await _repository.GetByIdAsync(cancellationToken, keyValues);
            return Map(alumnoGrado);
        }

        public async Task UpdateAsync(AlumnoGradoDto entity, CancellationToken cancellationToken)
        {
            var alumnoGrado = await _repository.GetByIdAsync(cancellationToken, entity.Id);

            if (alumnoGrado != null)
            {
                alumnoGrado.Id = entity.Id;
                alumnoGrado.AlumnoId = entity.AlumnoId;
                alumnoGrado.GradoId = entity.GradoId;
                alumnoGrado.Seccion = entity.Seccion;

                _repository.UpdateAsync(alumnoGrado, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);
            }
        }

        private AlumnoGrado Map(AlumnoGradoDto alumnoGrado)
        {
            return new AlumnoGrado
            {
                Id = alumnoGrado.Id,
                AlumnoId = alumnoGrado.AlumnoId,
                GradoId = alumnoGrado.GradoId,
                Seccion = alumnoGrado.Seccion
            };
        }

        private AlumnoGradoDto Map(AlumnoGrado alumnoGrado)
        {
            return new AlumnoGradoDto(alumnoGrado.Id, alumnoGrado.GradoId, alumnoGrado.AlumnoId, alumnoGrado.Seccion, alumnoGrado.Grado.Nombre, alumnoGrado.Alumno.NombreCompleto);
        }
    }
}
