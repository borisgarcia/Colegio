using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Repository
{
    public class AlumnoGradoRepository : BaseRepository<AlumnoGrado>
    {
        private readonly ColegioDataContext _dataContext;

        public AlumnoGradoRepository(ColegioDataContext context, 
            ColegioDataContext dataContext) : base(context)
        {
            _dataContext = dataContext;
        }

        public override async Task<IReadOnlyList<AlumnoGrado>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dataContext.AlumnoGrados
                .Include(x => x.Grado)
                .Include(x => x.Alumno)
                .ToListAsync(cancellationToken);
        }

        public override async Task<AlumnoGrado> GetByIdAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return await _dataContext.AlumnoGrados
                .Include(x => x.Grado)
                    .ThenInclude(g => g.Profesor)
                .Include(x => x.Alumno)
                .FirstOrDefaultAsync(x => x.Id == (Guid)keyValues[0], cancellationToken);
        }
    }
}
