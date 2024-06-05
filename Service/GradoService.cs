﻿using Domain.Models;
using Repositories;
using Service.Dtos;

namespace Service
{
    public class GradoService : IService<GradoDto>
    {
        private readonly IRepository<Grado> _repository;

        public GradoService(IRepository<Grado> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(GradoDto entity, CancellationToken cancellationToken)
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

        public async Task<IReadOnlyList<GradoDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var grados = await _repository.GetAllAsync(cancellationToken);

            return grados.Select(Map).ToList();
        }

        public async Task<GradoDto> GetByIdAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            var grado = await _repository.GetByIdAsync(cancellationToken, keyValues);
            return Map(grado);
        }

        public async Task UpdateAsync(GradoDto entity, CancellationToken cancellationToken)
        {
            var grado = await _repository.GetByIdAsync(cancellationToken, entity.Id);

            if (grado != null)
            {
                grado.Nombre = entity.Nombre;
                grado.ProfesorId = entity.ProfesorId;

                _repository.UpdateAsync(grado, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);
            }
        }

        private Grado Map(GradoDto grado)
        {
            return new Grado
            {
                Id = grado.Id,
                ProfesorId = grado.ProfesorId,
                Nombre = grado.Nombre
            };
        }

        private GradoDto Map(Grado grado)
        {
            return new GradoDto(grado.Id, grado.Nombre, grado.ProfesorId);
        }
    }
}