namespace MSmile.Db.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Task = System.Threading.Tasks.Task;

    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Adds entity into DB.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public Task AddAsync(TEntity entity);

        /// <summary>
        /// Adds entities into DB.
        /// </summary>
        /// <param name="entities">Entities.</param>
        public Task AddAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates entity in DB.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Deletes entity from DB.
        /// </summary>
        /// <param name="filter">Filter.</param>
        public Task DeleteAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Returns IQueryable interface for entities.
        /// </summary>
        /// <returns>IQueryable.</returns>
        public IQueryable<TEntity> Get();

        /// <summary>
        /// Return entities by given filter.
        /// </summary>
        /// <param name="filter">Filter.</param>
        /// <returns>Entities.</returns>
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Returns the first entity that matches the filter.
        /// </summary>
        /// <param name="filter">Filter.</param>
        /// <returns>Entity.</returns>
        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Returns the first entity that matches the filter.
        /// </summary>
        /// <param name="filter">Filter.</param>
        /// <returns>Entity.</returns>
        public Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Returns single entity that matches the filter.
        /// </summary>
        /// <param name="filter">Filter.</param>
        /// <returns>Entity.</returns>
        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Returns single entity that matches the filter.
        /// </summary>
        /// <param name="filter">Filter.</param>
        /// <returns>Entity.</returns>
        public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Checks if there are any entities that matches the filter.
        /// </summary>
        /// <param name="filter">Filter.</param>
        /// <returns>Result.</returns>
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>Number of entities that were modified.</returns>
        public Task<int> SaveChangesAsync();
    }
}
