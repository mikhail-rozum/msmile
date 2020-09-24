namespace MSmile.Api.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using MSmile.Dto.Dto;
    using MSmile.Services;
    using MSmile.Services.DataServices;

    /// <summary>
    /// Methods for pupils.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PupilController : Controller
    {
        /// <summary>
        /// Get all the pupils.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <returns>Pupils.</returns>
        [HttpGet]
        public List<PupilDto> GetAll([FromServices] PupilService service)
        {
            return service.GetAll();
        }

        /// <summary>
        /// Adds Pupil.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPost]
        public PupilDto Add([FromBody] PupilDto dto, [FromServices] PupilService service)
        {
            return service.Add(dto);
        }

        /// <summary>
        /// Updates Pupil.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPut]
        public PupilDto Update([FromBody] PupilDto dto, [FromServices] PupilService service)
        {
            return service.Update(dto);
        }

        /// <summary>
        /// Deletes the Pupil.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="service">Pupils service.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id, [FromServices] PupilService service)
        {
            service.Delete(id);
            return this.Ok();
        }
    }
}
