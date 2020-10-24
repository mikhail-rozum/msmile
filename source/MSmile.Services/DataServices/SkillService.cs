namespace MSmile.Services.DataServices
{
    using System;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Db.Infrastructure;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Skill service.
    /// </summary>
    public class SkillService : BaseCrudService<Skill, SkillDto>
    {
        /// <inheritdoc />
        public SkillService(IMapper mapper, IServiceProvider serviceProvider, IRepository<Skill> skillRepository)
            : base(mapper, serviceProvider, skillRepository)
        {
        }
    }
}