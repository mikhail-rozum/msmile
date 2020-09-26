namespace MSmile.Services.DataServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using MSmile.Db.Infrastructure;
    using MSmile.Dto.Dto;
    using MSmile.Services.Exceptions;

    /// <summary>
    /// Base service with CRUD operations.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TDto">Dto type</typeparam>
    public abstract class BaseCrudService<TEntity, TDto> : BaseService
        where TEntity : class, IEntityWithId
        where TDto : BaseDto
    {
        /// <inheritdoc />
        protected BaseCrudService(IMapper mapper, IServiceProvider serviceProvider)
            : base(mapper, serviceProvider)
        {
        }

        /// <summary>
        /// Get all objects.
        /// </summary>
        /// <returns>Dtos.</returns>
        public List<TDto> GetAll()
        {
            return this.ExecuteInDb(
                uow => uow.GetRepository<TEntity>()
                    .Get()
                    .ProjectTo<TDto>(this.Mapper.ConfigurationProvider)
                    .ToList());
        }

        /// <summary>
        /// Gets all object.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <returns>Dtos.</returns>
        public List<TDto> GetAll(int page, int pageSize)
        {
            return this.ExecuteInDb(
                uow => uow.GetRepository<TEntity>()
                    .Get()
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ProjectTo<TDto>(this.Mapper.ConfigurationProvider)
                    .ToList());
        }

        /// <summary>
        /// Gets object.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Object.</returns>
        public TDto Get(long id)
        {
            return this.ExecuteInDb(uow =>
                uow.GetRepository<TEntity>()
                   .Get()
                   .Where(x => x.Id == id)
                   .ProjectTo<TDto>(this.Mapper.ConfigurationProvider)
                   .FirstOrDefault());
        }

        /// <summary>
        /// Adds object.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <returns>Dto.</returns>
        public TDto Add(TDto dto)
        {
            dto.Id = default;

            var entity = this.Mapper.Map<TEntity>(dto);
            return this.ExecuteInDb(
                uow =>
                {
                    uow.GetRepository<TEntity>().Add(entity);
                    uow.Save();

                    return this.Mapper.Map<TDto>(entity);
                });
        }

        /// <summary>
        /// Updates object.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <returns>Dto.</returns>
        public TDto Update(TDto dto)
        {
            return this.ExecuteInDb(
                uow =>
                {
                    var repository = uow.GetRepository<TEntity>();
                    var entity = repository
                        .Get()
                        .SingleOrDefault(x => x.Id == dto.Id)
                        ?? throw new BusinessException(MessageConstants.Common.EntityNotFound);

                    this.Mapper.Map(dto, entity);
                    repository.Update(entity);
                    uow.Save();

                    return this.Mapper.Map<TDto>(entity);
                });
        }

        /// <summary>
        /// Deletes object.
        /// </summary>
        /// <param name="id">Id.</param>
        public void Delete(long id)
        {
            this.ExecuteInDb(
                uow =>
                {
                    var repository = uow.GetRepository<TEntity>();
                    var entity = repository
                        .Get()
                        .FirstOrDefault(x => x.Id == id)
                        ?? throw new BusinessException(MessageConstants.Common.EntityNotFound);

                    repository.Delete(entity);

                    uow.Save();
                });
        }
    }
}
