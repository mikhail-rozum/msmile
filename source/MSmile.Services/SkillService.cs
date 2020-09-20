namespace MSmile.Services
{
    using System.Linq;

    using AutoMapper;

    using MSmile.Db.Entities;
    using MSmile.Db.Infrastructure;
    using MSmile.Dto.Dto;
    using MSmile.Services.Exceptions;

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
        public SkillDto Add(SkillDto dto)
        {
            dto.Id = default;

            var entity = this.Mapper.Map<Skill>(dto);
            this.skillRepository.Add(entity);
            this.skillRepository.SaveChanges();

            return this.Mapper.Map<SkillDto>(entity);
        }

        /// <summary>
        /// Updates Skill.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <returns>Dto.</returns>
        public SkillDto Update(SkillDto dto)
        {
            var entity = this.skillRepository
                .Get()
                .SingleOrDefault(x => x.Id == dto.Id)
                ?? throw new BusinessException(MessageConstants.Common.EntityNotFound);

            this.Mapper.Map(dto, entity);
            this.skillRepository.Update(entity);
            this.skillRepository.SaveChanges();

            return this.Mapper.Map<SkillDto>(entity);
        }
    }
}