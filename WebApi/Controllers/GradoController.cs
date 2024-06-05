using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradoController : ControllerBase
    {
        private readonly IService<GradoDto> _gradoService;

        public GradoController(IService<GradoDto> gradoService)
        {
            _gradoService = gradoService;
        }

        [HttpGet("get-all-grados")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var grados = await _gradoService.GetAllAsync(cancellationToken);
                return Ok(grados);
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error getting grados."
                });

            }
        }

        [HttpGet("get-grado/{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var grado = await _gradoService.GetByIdAsync(cancellationToken, id);
                return Ok(grado);
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error getting grado."
                });

            }
        }

        [HttpPost("add-grado")]
        public async Task<IActionResult> SaveGrado([FromBody] GradoDto dto, CancellationToken cancellationToken)
        {
            try
            {
                await _gradoService.CreateAsync(dto, cancellationToken);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error creating grado."
                });

            }
        }

        [HttpPut("update-grado")]
        public async Task<IActionResult> Put(GradoDto dto, CancellationToken cancellationToken)
        {
            try
            {
                await _gradoService.UpdateAsync(dto, cancellationToken);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error updating grado."
                });
            }
        }

        [HttpDelete("delete-grado/{id}")]
        public async Task<IActionResult> DeleteGrado(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _gradoService.DeleteAsync(cancellationToken, id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error deleting grado."
                });
            }
        }
    }
}
