namespace MSmile.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using MSmile.Db.Entities;
    using MSmile.Dto.Dto;
    using MSmile.Services.Exceptions;

    /// <summary>
    /// Difficulty level service.
    /// </summary>
    public class DifficultyLevelService : BaseService
    {
        /// <inheritdoc />
        public DifficultyLevelService(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
        }

        /// <summary>
        /// Get all difficulty levels.
        /// </summary>
        /// <returns>Difficulty levels.</returns>
        public List<DifficultyLevelDto> GetAll()
        {
            return this.ExecuteInDb(
                uow => uow.DifficultyLevelRepository
                    .Get()
                    .ProjectTo<DifficultyLevelDto>(this.Mapper.ConfigurationProvider)
                    .ToList());
        }

        /// <summary>
        /// Gets difficulty level.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>Difficulty level.</returns>
        public DifficultyLevelDto Get(long id)
        {
            return this.ExecuteInDb(uow => 
                uow.DifficultyLevelRepository
                   .Get()
                   .Where(x => x.Id == id)
                   .ProjectTo<DifficultyLevelDto>(this.Mapper.ConfigurationProvider)
                   .FirstOrDefault());
        }

        /// <summary>
        /// Adds difficulty level.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <returns>Dto.</returns>
        public DifficultyLevelDto Add(DifficultyLevelDto dto)
        {
            dto.Id = default;

            var entity = this.Mapper.Map<DifficultyLevel>(dto);
            return this.ExecuteInDb(
                uow =>
                {
                    uow.DifficultyLevelRepository.Add(entity);
                    uow.Save();

                    return this.Mapper.Map<DifficultyLevelDto>(entity);
                });
        }

        /// <summary>
        /// Updates difficulty level.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <returns>Dto.</returns>
        public DifficultyLevelDto Update(DifficultyLevelDto dto)
        {
            return this.ExecuteInDb(
                uow =>
                {
                    var entity = uow.DifficultyLevelRepository
                        .Get()
                        .SingleOrDefault(x => x.Id == dto.Id)
                        ?? throw new BusinessException(MessageConstants.Common.EntityNotFound);

                    this.Mapper.Map(dto, entity);
                    uow.DifficultyLevelRepository.Update(entity);
                    uow.Save();

                    return this.Mapper.Map<DifficultyLevelDto>(entity);
                });
        }

        /// <summary>
        /// Deletes difficulty level.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Delete(long id)
        {
            this.ExecuteInDb(
                uow =>
                {
                    var entity = uow.DifficultyLevelRepository
                        .Get()
                        .FirstOrDefault(x => x.Id == id)
                        ?? throw new BusinessException(MessageConstants.Common.EntityNotFound);

                    uow.DifficultyLevelRepository.Delete(entity);

                    uow.Save();
                });
        }
    }
}
