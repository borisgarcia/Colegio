using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly IService<ProfesorDto> _profesorService;

        public ProfesorController(IService<ProfesorDto> profesorService)
        {
            _profesorService = profesorService;
        }

        [HttpGet("get-all-profesores")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var profesores = await _profesorService.GetAllAsync(cancellationToken);
                return Ok(profesores);
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error getting profesores."
                });

            }
        }

        [HttpGet("get-profesor/{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var profesor = await _profesorService.GetByIdAsync(cancellationToken, id);
                return Ok(profesor);
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error getting profesor."
                });

            }
        }

        [HttpPost("add-profesor")]
        public async Task<IActionResult> SaveProfesor([FromBody] ProfesorDto dto, CancellationToken cancellationToken)
        {
            try
            {
                await _profesorService.CreateAsync(dto, cancellationToken);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error creating profesor."
                });

            }
        }

        [HttpPut("update-profesor")]
        public async Task<IActionResult> Put(ProfesorDto dto, CancellationToken cancellationToken)
        {
            try
            {
                await _profesorService.UpdateAsync(dto, cancellationToken);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error updating profesor."
                });
            }
        }

        [HttpDelete("delete-profesor/{id}")]
        public async Task<IActionResult> DeleteProfesor(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _profesorService.DeleteAsync(cancellationToken, id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error deleting profesor."
                });
            }
        }
    }
}
