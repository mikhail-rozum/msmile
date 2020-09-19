namespace MSmile.Services
{
    using System;
    using System.Threading.Tasks;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Db.Infrastructure;
    using MSmile.Dto.Dto;

    /// <summary>
    /// Skill service.
    /// </summary>
    public class SkillService : BaseService
    {
        private readonly Repository<Skill> skillRepository;

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="skillRepository">Repository.</param>
        /// <param name="mapper">Mapper.</param>
        public SkillService(Repository<Skill> skillRepository, IMapper mapper)
            : base(mapper)
        {
            this.skillRepository = skillRepository;
        }

        /// <summary>
        /// Adds Skill.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <returns>Dto.</returns>
        public Task<SkillDto> AddAsync(SkillDto dto)
        {
            // TODO: Implement this after including validation on dtos
            throw new NotImplementedException();
        }
    }
}