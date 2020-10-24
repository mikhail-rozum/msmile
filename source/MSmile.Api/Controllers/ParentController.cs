namespace MSmile.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

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
        public Task<List<ParentDto>> GetAll([FromServices] ParentService service)
        {
            return service.GetAll();
        }

        /// <summary>
        /// Get all the parents.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <param name="page">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <returns>Parents.</returns>
        [HttpGet("getAll")]
        public Task<List<ParentDto>> GetAll([FromServices] ParentService service, int page, int pageSize)
        {
            return service.GetAll(page, pageSize);
        }

        /// <summary>
        /// Get the parent level.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <param name="id">Id</param>
        /// <returns>Parent.</returns>
        [HttpGet("{id}")]
        public Task<ParentDto> Get([FromServices] ParentService service, [FromRoute] long id)
        {
            return service.Get(id);
        }

        /// <summary>
        /// Adds Parent.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPost]
        public Task<ParentDto> Add([FromBody] ParentDto dto, [FromServices] ParentService service)
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
        public Task<ParentDto> Update([FromBody] ParentDto dto, [FromServices] ParentService service)
        {
            return service.Update(dto);
        }

        /// <summary>
        /// Deletes the Parent.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="service">Parent service.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, [FromServices] ParentService service)
        {
            await service.Delete(id);
            return this.Ok();
        }
    }
}
