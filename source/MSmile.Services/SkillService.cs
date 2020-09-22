namespace MSmile.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

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
        /// <param name="serviceProvider">Service provider.</param>
        public SkillService(Repository<Skill> skillRepository, IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
            this.skillRepository = skillRepository;
        }

        /// <summary>
        /// Get all the Skills.
        /// </summary>
        /// <returns>Skills.</returns>
        public List<SkillDto> GetAll()
        {
            return this.ExecuteInDb(
                (uow) => uow.SkillRepository
                    .Get()
                    .ProjectTo<SkillDto>(this.Mapper.ConfigurationProvider)
                    .ToList());
        }

        /// <summary>
        /// Gets Skill.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>Skill.</returns>
        public SkillDto Get(long id)
        {
            return this.ExecuteInDb(
                (uow) =>
                {
                    var result = this.Mapper.Map<SkillDto>(uow.SkillRepository.Get().FirstOrDefault(x => x.Id == id));
                    return result;
                });
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

        /// <summary>
        /// Deletes Skill.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Delete(long id)
        {
            this.ExecuteInDb(
                uow =>
                {
                    var entity = uow.SkillRepository
                        .Get()
                        .FirstOrDefault(x => x.Id == id)
                        ?? throw new BusinessException(MessageConstants.Common.EntityNotFound);

                    uow.SkillRepository.Delete(entity);

                    uow.Save();
                });
        }
    }
}