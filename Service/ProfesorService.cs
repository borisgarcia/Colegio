using Domain.Models;
using Repositories;
using Service.Dtos;

namespace Service
{
    public class ProfesorService : IService<ProfesorDto>
    {
        private readonly IRepository<Profesor> _repository;

        public ProfesorService(IRepository<Profesor> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(ProfesorDto entity, CancellationToken cancellationToken)
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

        public async Task<IReadOnlyList<ProfesorDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var Profesors = await _repository.GetAllAsync(cancellationToken);

            return Profesors.Select(Map).ToList();
        }

        public async Task<ProfesorDto> GetByIdAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            var profesor = await _repository.GetByIdAsync(cancellationToken, keyValues);
            return Map(profesor);
        }

        public async Task UpdateAsync(ProfesorDto entity, CancellationToken cancellationToken)
        {
            var profesor = await _repository.GetByIdAsync(cancellationToken, entity.Id);

            if (profesor != null)
            {
                profesor.Apellidos = entity.Apellidos;
                profesor.Nombre = entity.Nombre;
                profesor.Genero = entity.Genero;

                _repository.UpdateAsync(profesor, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);
            }
        }

        private Profesor Map(ProfesorDto profesor)
        {
            return new Profesor
            {
                Id = profesor.Id,
                Apellidos = profesor.Apellidos,
                Nombre = profesor.Nombre,
                Genero = profesor.Genero
            };
        }

        private ProfesorDto Map(Profesor profesor)
        {
            return new ProfesorDto(profesor.Id, profesor.Nombre, profesor.Apellidos, profesor.Genero);
        }
    }
}
