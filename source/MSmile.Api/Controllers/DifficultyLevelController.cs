namespace MSmile.Api.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using MSmile.Dto.Dto;
    using MSmile.Services.DataServices;

    /// <summary>
    /// Methods for difficulty levels.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyLevelController : Controller
    {
        /// <summary>
        /// Get all the difficulty levels.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <returns>Difficulty levels.</returns>
        [HttpGet]
        public List<DifficultyLevelDto> GetAll([FromServices] DifficultyLevelService service)
        {
            return service.GetAll();
        }

        /// <summary>
        /// Get the difficulty level.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <param name="id">Id</param>
        /// <returns>Difficulty level.</returns>
        [HttpGet("{id}")]
        public DifficultyLevelDto Get([FromServices] DifficultyLevelService service, [FromRoute] long id)
        {
            return service.Get(id);
        }

        /// <summary>
        /// Get all the difficulty levels.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <param name="page">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <returns>Difficulty levels.</returns>
        [HttpGet("getAll")]
        public List<DifficultyLevelDto> GetAll([FromServices] DifficultyLevelService service, int page, int pageSize)
        {
            return service.GetAll(page, pageSize);
        }

        /// <summary>
        /// Adds difficulty levels.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPost]
        public DifficultyLevelDto Add([FromBody] DifficultyLevelDto dto, [FromServices] DifficultyLevelService service)
        {
            return service.Add(dto);
        }

        /// <summary>
        /// Updates Difficulty levels.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPut]
        public DifficultyLevelDto Update([FromBody] DifficultyLevelDto dto, [FromServices] DifficultyLevelService service)
        {
            return service.Update(dto);
        }

        /// <summary>
        /// Deletes the Difficulty levels.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="service">Difficulty levels service.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id, [FromServices] DifficultyLevelService service)
        {
            service.Delete(id);
            return this.Ok();
        }
    }
}
