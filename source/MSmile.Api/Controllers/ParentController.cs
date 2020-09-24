namespace MSmile.Api.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using MSmile.Dto.Dto;
    using MSmile.Services;
    using MSmile.Services.DataServices;

    /// <summary>
    /// Methods for parents.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : Controller
    {
        /// <summary>
        /// Get all the parents.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <returns>Parents.</returns>
        [HttpGet]
        public List<ParentDto> GetAll([FromServices] ParentService service)
        {
            return service.GetAll();
        }

        /// <summary>
        /// Adds Parent.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPost]
        public ParentDto Add([FromBody] ParentDto dto, [FromServices] ParentService service)
        {
            return service.Add(dto);
        }

        /// <summary>
        /// Updates Parent.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPut]
        public ParentDto Update([FromBody] ParentDto dto, [FromServices] ParentService service)
        {
            return service.Update(dto);
        }

        /// <summary>
        /// Deletes the Parent.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="service">Parent service.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id, [FromServices] ParentService service)
        {
            service.Delete(id);
            return this.Ok();
        }
    }
}
