namespace MSmile.Services.DataServices
{
    using System;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Db.Infrastructure;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Exercise service.
    /// </summary>
    public class ExerciseService : BaseCrudService<Exercise, ExerciseDto>
    {
        /// <inheritdoc />
        public ExerciseService(IMapper mapper, IServiceProvider serviceProvider, IRepository<Exercise> exerciseRepository)
            : base(mapper, serviceProvider, exerciseRepository)
        {
        }
    }
}
