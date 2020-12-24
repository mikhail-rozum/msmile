namespace MSmile.Services.DataServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Microsoft.EntityFrameworkCore;

    using MSmile.Db.Infrastructure;
    using MSmile.Dto.Dto;
    using MSmile.Services.Exceptions;

    /// <summary>
    /// Base service with CRUD operations.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TDto">Dto type</typeparam>
    public abstract class BaseCrudService<TEntity, TDto>
        where TEntity : class, IEntityWithId
        where TDto : BaseDto
    {
        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="mapper">Mapper.</param>
        /// <param name="serviceProvider">Service provider.</param>
        /// <param name="repository">Repository.</param>
        protected BaseCrudService(IMapper mapper, IServiceProvider serviceProvider, IRepository<TEntity> repository)
        {
            this.Mapper = mapper;
            this.ServiceProvider = serviceProvider;
            this.Repository = repository;
        }

        /// <summary>
        /// Mapper.
        /// </summary>
        protected IMapper Mapper { get; }

        /// <summary>
        /// Service provider.
        /// </summary>
        protected IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Repository.
        /// </summary>
        protected IRepository<TEntity> Repository { get; }

        /// <summary>
        /// Get all objects.
        /// </summary>
        /// <returns>Dtos.</returns>
        public virtual Task<List<TDto>> GetAll()
        {
            return this.Repository
                .Get()
                .ProjectTo<TDto>(this.Mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Gets all object.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <returns>Dtos.</returns>
        public virtual Task<List<TDto>> GetAll(int page, int pageSize)
        {
            return this.Repository
                .Get()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<TDto>(this.Mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Gets object.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Object.</returns>
        public virtual Task<TDto> Get(long id)
        {
            return this.Repository
                .Get()
                .Where(x => x.Id == id)
                .ProjectTo<TDto>(this.Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Adds object.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <returns>Dto.</returns>
        public virtual async Task<TDto> Add(TDto dto)
        {
            dto.Id = default;

            var entity = this.Mapper.Map<TEntity>(dto);
            await this.Repository.AddAsync(entity);

            var result = await this.Repository
                .Get(x => x.Id == entity.Id)
                .ProjectTo<TDto>(this.Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return result;
        }

        /// <summary>
        /// Updates object.
        /// </summary>
        /// <param name="dto">Dto.</param>
        /// <returns>Dto.</returns>
        public virtual async Task<TDto> Update(TDto dto)
        {
            var entity = await GetEntityForUpdate(dto.Id)
                ?? throw new BusinessException(MessageConstants.Common.EntityNotFound);

            this.Mapper.Map(dto, entity);
            await this.Repository.UpdateAsync(entity);

            var result = await this.Repository
                .Get(x => x.Id == entity.Id)
                .ProjectTo<TDto>(this.Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return result;
        }

        /// <summary>
        /// Deletes object.
        /// </summary>
        /// <param name="id">Id.</param>
        public virtual Task Delete(long id)
        {
            return this.Repository.DeleteAsync(x => x.Id == id);
        }

        /// <summary>
        /// Returns an entity (and child collections if it is necessary) for update.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <remarks>Override this method if you need to update entity's sub-collections.</remarks>
        protected virtual Task<TEntity> GetEntityForUpdate(long id)
        {
            return this.Repository.Get(x => x.Id == id).SingleOrDefaultAsync();
        }
    }
}
