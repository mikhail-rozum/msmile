namespace MSmile.Api.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using MSmile.Dto.Dto;
    using MSmile.Services;

    /// <summary>
    /// Methods for employees.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        /// <summary>
        /// Get all the employees.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <returns>Employees.</returns>
        [HttpGet]
        public List<EmployeeDto> GetAll([FromServices] EmployeeService service)
        {
            return service.GetAll();
        }

        /// <summary>
        /// Adds Employee.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPost]
        public EmployeeDto Add([FromBody] EmployeeDto dto, [FromServices] EmployeeService service)
        {
            return service.Add(dto);
        }

        /// <summary>
        /// Updates Employee.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPut]
        public EmployeeDto Update([FromBody] EmployeeDto dto, [FromServices] EmployeeService service)
        {
            return service.Update(dto);
        }

        /// <summary>
        /// Deletes the Employee.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="service">Employees service.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id, [FromServices] EmployeeService service)
        {
            service.Delete(id);
            return this.Ok();
        }
    }
}
