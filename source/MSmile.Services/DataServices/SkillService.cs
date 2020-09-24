namespace MSmile.Services.DataServices
{
    using System;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Skill service.
    /// </summary>
    public class SkillService : BaseCrudService<Skill, SkillDto>
    {
        /// <inheritdoc />
        public SkillService(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
        }
    }
}