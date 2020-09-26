namespace MSmile.Api.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using MSmile.Dto.Dto;
    using MSmile.Services.DataServices;

    /// <summary>
    /// Lesson controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : Controller
    {
        /// <summary>
        /// Get all the lessons.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <returns>Lessons.</returns>
        [HttpGet]
        public List<LessonDto> GetAll([FromServices] LessonService service)
        {
            return service.GetAll();
        }

        /// <summary>
        /// Get all the lessons.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <param name="page">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <returns>Lessons.</returns>
        [HttpGet("getAll")]
        public List<LessonDto> GetAll([FromServices] LessonService service, int page, int pageSize)
        {
            return service.GetAll(page, pageSize);
        }

        /// <summary>
        /// Get the lesson.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <param name="id">Id</param>
        /// <returns>Lesson.</returns>
        [HttpGet("{id}")]
        public LessonDto Get([FromServices] LessonService service, [FromRoute] long id)
        {
            return service.Get(id);
        }

        /// <summary>
        /// Adds Lesson.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPost]
        public LessonDto Add([FromBody] LessonDto dto, [FromServices] LessonService service)
        {
            return service.Add(dto);
        }

        /// <summary>
        /// Updates Lesson.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPut]
        public LessonDto Update([FromBody] LessonDto dto, [FromServices] LessonService service)
        {
            return service.Update(dto);
        }

        /// <summary>
        /// Deletes the Lesson.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="service">Lesson service.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id, [FromServices] LessonService service)
        {
            service.Delete(id);
            return this.Ok();
        }
    }
}
