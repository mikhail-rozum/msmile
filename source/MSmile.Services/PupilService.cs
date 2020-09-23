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
    /// Pupil service.
    /// </summary>
    public class PupilService : BaseService
    {
        /// <inheritdoc />
        public PupilService(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
        }

        /// <summary>
        /// Get all pupils.
        /// </summary>
        /// <returns>Pupils.</returns>
        public List<PupilDto> GetAll()
        {
            return this.ExecuteInDb(
                uow => uow.PupilRepository
                    .Get()
                    .ProjectTo<PupilDto>(this.Mapper.ConfigurationProvider)
                    .ToList());
        }

        /// <summary>
        /// Gets pupil.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>Pupil.</returns>
        public PupilDto Get(long id)
        {
            return this.ExecuteInDb(uow =>
                uow.PupilRepository
                   .Get()
                   .Where(x => x.Id == id)
                   .ProjectTo<PupilDto>(this.Mapper.ConfigurationProvider)
                   .FirstOrDefault());
        }

        /// <summary>
        /// Adds Pupil.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <returns>Dto.</returns>
        public PupilDto Add(PupilDto dto)
        {
            dto.Id = default;

            var entity = this.Mapper.Map<Pupil>(dto);
            return this.ExecuteInDb(
                uow =>
                {
                    uow.PupilRepository.Add(entity);
                    uow.Save();

                    return this.Mapper.Map<PupilDto>(entity);
                });
        }

        /// <summary>
        /// Updates pupil.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <returns>Dto.</returns>
        public PupilDto Update(PupilDto dto)
        {
            return this.ExecuteInDb(
                uow =>
                {
                    var entity = uow.PupilRepository
                        .Get()
                        .SingleOrDefault(x => x.Id == dto.Id)
                        ?? throw new BusinessException(MessageConstants.Common.EntityNotFound);

                    this.Mapper.Map(dto, entity);
                    uow.PupilRepository.Update(entity);
                    uow.Save();

                    return this.Mapper.Map<PupilDto>(entity);
                });
        }

        /// <summary>
        /// Deletes pupil.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void Delete(long id)
        {
            this.ExecuteInDb(
                uow =>
                {
                    var entity = uow.PupilRepository
                        .Get()
                        .FirstOrDefault(x => x.Id == id)
                        ?? throw new BusinessException(MessageConstants.Common.EntityNotFound);

                    uow.PupilRepository.Delete(entity);

                    uow.Save();
                });
        }
    }
}
