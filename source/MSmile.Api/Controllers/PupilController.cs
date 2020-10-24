namespace MSmile.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using MSmile.Dto.Dto;
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
        public Task<List<PupilDto>> GetAll([FromServices] PupilService service)
        {
            return service.GetAll();
        }

        /// <summary>
        /// Get all the pupils.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <param name="page">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <returns>Pupils.</returns>
        [HttpGet("getAll")]
        public Task<List<PupilDto>> GetAll([FromServices] PupilService service, int page, int pageSize)
        {
            return service.GetAll(page, pageSize);
        }

        /// <summary>
        /// Get the pupil.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <param name="id">Id</param>
        /// <returns>Pupil.</returns>
        [HttpGet("{id}")]
        public Task<PupilDto> Get([FromServices] PupilService service, [FromRoute] long id)
        {
            return service.Get(id);
        }

        /// <summary>
        /// Adds Pupil.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPost]
        public Task<PupilDto> Add([FromBody] PupilDto dto, [FromServices] PupilService service)
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
        public Task<PupilDto> Update([FromBody] PupilDto dto, [FromServices] PupilService service)
        {
            return service.Update(dto);
        }

        /// <summary>
        /// Deletes the Pupil.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="service">Pupils service.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, [FromServices] PupilService service)
        {
            await service.Delete(id);
            return this.Ok();
        }
    }
}
