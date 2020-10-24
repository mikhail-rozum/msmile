namespace MSmile.Services.DataServices
{
    using System;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Db.Infrastructure;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Difficulty level service.
    /// </summary>
    public class DifficultyLevelService : BaseCrudService<DifficultyLevel, DifficultyLevelDto>
    {
        /// <inheritdoc />
        public DifficultyLevelService(IMapper mapper, IServiceProvider serviceProvider, IRepository<DifficultyLevel> difficultyLevelRepository)
            : base(mapper, serviceProvider, difficultyLevelRepository)
        {
        }
    }
}
