using Microsoft.AspNetCore.Mvc;
using Repositories;
using Service;
using Service.Dtos;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly IService<AlumnoDto> _alumnoService;

        public AlumnosController(IService<AlumnoDto> alumnoService)
        {
            _alumnoService = alumnoService;
        }

        [HttpGet("get-all-alumnos")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var alumnos = await _alumnoService.GetAllAsync(cancellationToken);
                return Ok(alumnos);
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error getting alumnos."
                });

            }
        }

        [HttpGet("get-alumno/{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var alumno = await _alumnoService.GetByIdAsync(cancellationToken, id);
                return Ok(alumno);
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error getting alumno."
                });

            }
        }

        [HttpPost("add-alumno")]
        public async Task<IActionResult> SaveAlumno([FromBody] AlumnoDto dto, CancellationToken cancellationToken)
        {
            try
            {
                await _alumnoService.CreateAsync(dto, cancellationToken);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error creating alumno."
                });

            }
        }

        [HttpPut("update-alumno")]
        public async Task<IActionResult> Put(AlumnoDto dto, CancellationToken cancellationToken)
        {
            try
            {
                await _alumnoService.UpdateAsync(dto, cancellationToken);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error updating alumno."
                });
            }
        }

        [HttpDelete("delete-alumno/{id}")]
        public async Task<IActionResult> DeleteAlumno(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _alumnoService.DeleteAsync(cancellationToken, id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Error deleting alumno."
                });
            }
        }
    }
}
