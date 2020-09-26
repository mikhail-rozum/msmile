namespace MSmile.Services.DataServices
{
    using System;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Task service.
    /// </summary>
    public class TaskService : BaseCrudService<Task, TaskDto>
    {
        /// <inheritdoc />
        public TaskService(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
        }
    }
}
