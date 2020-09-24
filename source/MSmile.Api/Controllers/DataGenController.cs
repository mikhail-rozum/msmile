namespace MSmile.Api.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using MSmile.Dto.Dto;
    using MSmile.Services;
    using MSmile.Services.DataServices;

    /// <summary>
    /// Generates test data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DataGenController : Controller
    {
        /// <summary>
        /// Generates employees and insert them to database.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <param name="count">Amount.</param>
        /// <returns>Employees.</returns>
        [HttpGet("employees")]
        public List<EmployeeDto> GenerateEmployees([FromServices] DataGenerationService service, int count)
        {
            return service.GenerateEmployees(count);
        }

        /// <summary>
        /// Generates parents and insert them to database.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <param name="count">Amount.</param>
        /// <returns>Parents.</returns>
        [HttpGet("parents")]
        public List<ParentDto> GenerateParents([FromServices] DataGenerationService service, int count)
        {
            return service.GenerateParents(count);
        }
    }
}
