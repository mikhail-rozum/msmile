namespace MSmile.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using MSmile.Dto.Dto;
    using MSmile.Services;

    /// <summary>
    /// Methods for Skills
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : Controller
    {
        /// <summary>
        /// Adds Skill.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPost]
        public SkillDto Add([FromBody] SkillDto dto, [FromServices] SkillService service)
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
        public SkillDto Update([FromBody] SkillDto dto, [FromServices] SkillService service)
        {
            return service.Update(dto);
        }
    }
}
