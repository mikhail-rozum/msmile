namespace MSmile.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using MSmile.Dto.Dto;
    using MSmile.Services.DataServices;

    /// <summary>
    /// Task controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        /// <summary>
        /// Get all the tasks.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <returns>Exercises.</returns>
        [HttpGet]
        public Task<List<ExerciseDto>> GetAll([FromServices] ExerciseService service)
        {
            return service.GetAll();
        }

        /// <summary>
        /// Get all the tasks.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <param name="page">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <returns>Exercises.</returns>
        [HttpGet("getAll")]
        public Task<List<ExerciseDto>> GetAll([FromServices] ExerciseService service, int page, int pageSize)
        {
            return service.GetAll(page, pageSize);
        }

        /// <summary>
        /// Adds Task.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPost]
        public Task<ExerciseDto> Add([FromBody] ExerciseDto dto, [FromServices] ExerciseService service)
        {
            return service.Add(dto);
        }

        /// <summary>
        /// Updates Task.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPut]
        public Task<ExerciseDto> Update([FromBody] ExerciseDto dto, [FromServices] ExerciseService service)
        {
            return service.Update(dto);
        }

        /// <summary>
        /// Deletes the task.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="service">Task service.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, [FromServices] ExerciseService service)
        {
            await service.Delete(id);
            return this.Ok();
        }
    }
}
