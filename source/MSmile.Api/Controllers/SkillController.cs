namespace MSmile.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using MSmile.Dto.Dto;
    using MSmile.Services.DataServices;

    /// <summary>
    /// Methods for Skills
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : Controller
    {
        /// <summary>
        /// Get all the skills.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <returns>Skills.</returns>
        [HttpGet]
        public Task<List<SkillDto>> GetAll([FromServices] SkillService service)
        {
            return service.GetAll();
        }

        /// <summary>
        /// Get all the skills.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <param name="page">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <returns>Skills.</returns>
        [HttpGet("getAll")]
        public Task<List<SkillDto>> GetAll([FromServices] SkillService service, int page, int pageSize)
        {
            return service.GetAll(page, pageSize);
        }

        /// <summary>
        /// Get the skill.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <param name="id">Id.</param>
        /// <returns>Skill.</returns>
        [HttpGet("{id}")]
        public Task<SkillDto> Get([FromServices] SkillService service, [FromRoute] long id)
        {
            return service.Get(id);
        }

        /// <summary>
        /// Adds Skill.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPost]
        public Task<SkillDto> Add([FromBody] SkillDto dto, [FromServices] SkillService service)
        {
            return service.Add(dto);
        }

        /// <summary>
        /// Updates Skill.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPut]
        public Task<SkillDto> Update([FromBody] SkillDto dto, [FromServices] SkillService service)
        {
            return service.Update(dto);
        }

        /// <summary>
        /// Deletes the skill.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="service">Skill service.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id, [FromServices] SkillService service)
        {
            await service.Delete(id);
            return this.Ok();
        }
    }
}
