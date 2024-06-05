using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoGradoController : ControllerBase
    {
        private readonly IService<AlumnoGradoDto> _alumnoGradoService;

        public AlumnoGradoController(IService<AlumnoGradoDto> alumnoGradoService)
        {
            _alumnoGradoService = alumnoGradoService;
        }

        [HttpGet("get-all-alumnoGrados")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var alumnoGrados = await _alumnoGradoService.GetAllAsync(cancellationToken);
                return Ok(alumnoGrados);
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error getting alumnoGrados."
                });

            }
        }

        [HttpGet("get-alumnoGrado/{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var alumnoGrado = await _alumnoGradoService.GetByIdAsync(cancellationToken, id);
                return Ok(alumnoGrado);
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error getting alumnoGrado."
                });

            }
        }

        [HttpPost("add-alumnoGrado")]
        public async Task<IActionResult> SaveAlumnoGrado([FromBody] AlumnoGradoDto dto, CancellationToken cancellationToken)
        {
            try
            {
                await _alumnoGradoService.CreateAsync(dto, cancellationToken);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error creating alumnoGrado."
                });

            }
        }

        [HttpPut("update-alumnoGrado")]
        public async Task<IActionResult> Put(AlumnoGradoDto dto, CancellationToken cancellationToken)
        {
            try
            {
                await _alumnoGradoService.UpdateAsync(dto, cancellationToken);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error updating alumnoGrado."
                });
            }
        }

        [HttpDelete("delete-alumnoGrado/{id}")]
        public async Task<IActionResult> DeleteAlumnoGrado(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _alumnoGradoService.DeleteAsync(cancellationToken, id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error deleting alumnoGrado."
                });
            }
        }
    }
}
