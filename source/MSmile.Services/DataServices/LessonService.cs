namespace MSmile.Services.DataServices
{
    using System;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Db.Infrastructure;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Service for lessons.
    /// </summary>
    public class LessonService : BaseCrudService<Lesson, LessonDto>
    {
        /// <inheritdoc />
        public LessonService(IMapper mapper, IServiceProvider serviceProvider, IRepository<Lesson> lessonRepository)
            : base(mapper, serviceProvider, lessonRepository)
        {
        }
    }
}
