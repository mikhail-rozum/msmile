﻿namespace MSmile.Api.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using MSmile.Dto.Dto;
    using MSmile.Services.DataServices;

    /// <summary>
    /// Task controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        /// <summary>
        /// Get all the tasks.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <returns>Tasks.</returns>
        [HttpGet]
        public List<TaskDto> GetAll([FromServices] TaskService service)
        {
            return service.GetAll();
        }

        /// <summary>
        /// Get all the tasks.
        /// </summary>
        /// <param name="service">Service.</param>
        /// <param name="page">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <returns>Tasks.</returns>
        [HttpGet("getAll")]
        public List<TaskDto> GetAll([FromServices] TaskService service, int page, int pageSize)
        {
            return service.GetAll(page, pageSize);
        }

        /// <summary>
        /// Adds Task.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPost]
        public TaskDto Add([FromBody] TaskDto dto, [FromServices] TaskService service)
        {
            return service.Add(dto);
        }

        /// <summary>
        /// Updates Task.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <param name="service">Service.</param>
        /// <returns>Dto.</returns>
        [HttpPut]
        public TaskDto Update([FromBody] TaskDto dto, [FromServices] TaskService service)
        {
            return service.Update(dto);
        }

        /// <summary>
        /// Deletes the task.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="service">Task service.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id, [FromServices] TaskService service)
        {
            service.Delete(id);
            return this.Ok();
        }
    }
}